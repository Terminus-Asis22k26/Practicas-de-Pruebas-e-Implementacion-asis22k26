#!/usr/bin/env python3
"""Validaciones del repositorio: estandarización, código y separación MVC."""
import re
import subprocess
import sys
from pathlib import Path

RAIZ = Path(__file__).resolve().parents[2]
IGNORAR = {".git", "bin", "obj", "packages", "node_modules"}
errores = []
cambiados = None
agregados = None


def archivos(patron, solo_nuevos=False):
    for ruta in RAIZ.rglob(patron):
        partes = ruta.relative_to(RAIZ).parts
        if set(partes) & IGNORAR:
            continue
        lista = agregados if solo_nuevos else cambiados
        if lista is None or "/".join(partes) in lista:
            yield ruta


def cambios_git(base, filtro):
    salida = subprocess.run(
        ["git", "diff", "--name-only", f"--diff-filter={filtro}", f"{base}...HEAD"],
        cwd=RAIZ, capture_output=True, text=True, check=True,
    ).stdout
    return set(salida.split())


def leer(ruta):
    return ruta.read_text(encoding="utf-8-sig", errors="replace")


def rel(ruta):
    return ruta.relative_to(RAIZ).as_posix()


def capa(ruta):
    """Devuelve Vista, Controlador o Modelo según la carpeta Capa* que contiene el archivo."""
    for parte in ruta.relative_to(RAIZ).parts:
        for nombre in ("Vista", "Controlador", "Modelo"):
            if parte.startswith(f"Capa{nombre}_") or parte.startswith(f"Capa_{nombre}_"):
                return nombre
    return None


def proyecto_de(ruta):
    for carpeta in ruta.parents:
        csproj = list(carpeta.glob("*.csproj"))
        if csproj:
            return carpeta, csproj[0]
    return None, None


def existe(base, destino):
    return (base.parent / destino.replace("\\", "/")).exists()


# ---------------------------------------------------------------- código

def revisar_csproj():
    for ruta in archivos("*.csproj"):
        texto = leer(ruta)
        for etiqueta in ("Compile", "EmbeddedResource", "ProjectReference"):
            for destino in re.findall(r'<%s\s+Include="([^"]+)"' % etiqueta, texto):
                if "*" in destino or "$(" in destino:
                    continue
                if not existe(ruta, destino):
                    errores.append(f"[Código] {rel(ruta)}: {etiqueta} apunta a un archivo inexistente -> {destino}")


def revisar_sln():
    patron = re.compile(r'Project\("\{[^}]+\}"\)\s*=\s*"[^"]*",\s*"([^"]+)"')
    for ruta in archivos("*.sln"):
        for destino in patron.findall(leer(ruta)):
            if destino.lower().endswith(".csproj") and not existe(ruta, destino):
                errores.append(f"[Código] {rel(ruta)}: proyecto inexistente en la solución -> {destino}")


def revisar_conflictos():
    marcador = re.compile(r"^(<{7}|>{7})( |$)", re.M)
    for patron in ("*.cs", "*.csproj", "*.sln"):
        for ruta in archivos(patron):
            if marcador.search(leer(ruta)):
                errores.append(f"[Código] {rel(ruta)}: contiene marcadores de conflicto de merge")


TOKENS = re.compile(
    r'//[^\n]*|/\*.*?\*/|\$?@"(?:[^"]|"")*"|"(?:\\.|[^"\\\n])*"|\'(?:\\.|[^\'\\\n])*\'',
    re.S,
)


def sin_comentarios(texto):
    return TOKENS.sub("", texto)


def revisar_llaves():
    for ruta in archivos("*.cs"):
        limpio = sin_comentarios(leer(ruta))
        abiertas, cerradas = limpio.count("{"), limpio.count("}")
        if abiertas != cerradas:
            errores.append(f"[Código] {rel(ruta)}: llaves desbalanceadas ({abiertas} abiertas y {cerradas} cerradas)")


def revisar_registro_en_proyecto():
    for ruta in archivos("*.cs", solo_nuevos=True):
        if capa(ruta) is None or ruta.name.endswith(".Designer.cs"):
            continue
        carpeta, csproj = proyecto_de(ruta)
        if csproj is None:
            continue
        relativo = ruta.relative_to(carpeta).as_posix().replace("/", "\\")
        if f'Include="{relativo}"' not in leer(csproj):
            errores.append(f"[Código] {rel(ruta)}: no está registrado en {csproj.name}")


# --------------------------------------------------------- estandarización

ENCABEZADO = re.compile(r"/\*\s*Inicio de c.digo de .+? \d{4}-\d{2}-\d+ el \d{1,2}/\d{1,2}/\d{4}\s*\*/", re.I)
CIERRE = re.compile(r"/\*\s*fin de c.digo de .+? \d{4}-\d{2}-\d+ el \d{1,2}/\d{1,2}/\d{4}\s*\*/", re.I)
TIPO = re.compile(r"\b(?:public|internal)\s+(?:static\s+|sealed\s+|abstract\s+|partial\s+)*(class|interface|enum|struct)\s+(\w+)")
CAMPO_PRIVADO = re.compile(r"^\s*private\s+(?:static\s+|readonly\s+)*[\w<>\[\],\.\? ]+?\s+(\w+)\s*(?:=[^;]*)?;", re.M)


def prefijo_valido(clase, nombre):
    if clase == "interface":
        return re.match(r"I[A-Z]", nombre) is not None
    return re.match(r"(Cls|Frm|Usr)[A-Z]", nombre) is not None


def revisar_estandarizacion():
    for ruta in archivos("*.cs", solo_nuevos=True):
        if capa(ruta) is None or ruta.name.endswith((".Designer.cs", "AssemblyInfo.cs")):
            continue
        texto = leer(ruta)
        if not ENCABEZADO.search(texto) or not CIERRE.search(texto):
            errores.append(f"[Estandarización] {rel(ruta)}: falta el comentario 'Inicio de código' / 'fin de código' con autor, carné y fecha")
        limpio = sin_comentarios(texto)
        for clase, nombre in TIPO.findall(limpio):
            if not prefijo_valido(clase, nombre):
                errores.append(f"[Estandarización] {rel(ruta)}: el tipo '{nombre}' no usa el prefijo Cls/Frm/Usr (o I en interfaces)")
            if nombre != ruta.stem.split(".")[0]:
                errores.append(f"[Estandarización] {rel(ruta)}: el nombre del archivo no coincide con el tipo '{nombre}'")
        for campo in CAMPO_PRIVADO.findall(limpio):
            if not campo.startswith("_"):
                errores.append(f"[Estandarización] {rel(ruta)}: el campo privado '{campo}' debe iniciar con '_'")


# ---------------------------------------------------------------- MVC

BD = r"System\.Data\.Odbc|\bOdbc(Connection|Command)\b|MySql\.Data"
PROHIBIDO = {
    "Vista": [
        (r"\bCapaModelo_\w+", "la Vista no puede acceder al Modelo, solo al Controlador"),
        (BD, "la Vista no puede acceder a la base de datos"),
    ],
    "Controlador": [
        (r"System\.Windows\.Forms|\bMessageBox\b", "el Controlador no puede usar elementos de la Vista"),
        (BD, "el Controlador no puede acceder directamente a la base de datos, solo mediante el Modelo"),
        (r"\bCapaVista_\w+", "el Controlador no puede depender de la Vista"),
    ],
    "Modelo": [
        (r"System\.Windows\.Forms|\bMessageBox\b", "el Modelo no puede usar elementos de la Vista"),
        (r"\bCapa(Vista|Controlador)_\w+", "el Modelo no puede depender de la Vista ni del Controlador"),
    ],
}


def revisar_mvc():
    for ruta in archivos("*.cs"):
        nombre_capa = capa(ruta)
        if nombre_capa is None or ruta.name.endswith(".Designer.cs"):
            continue
        limpio = sin_comentarios(leer(ruta))
        for patron, motivo in PROHIBIDO[nombre_capa]:
            if re.search(patron, limpio):
                errores.append(f"[MVC] {rel(ruta)}: {motivo}")


def main():
    global cambiados, agregados
    if len(sys.argv) > 2 and sys.argv[1] == "--base":
        cambiados = cambios_git(sys.argv[2], "ACMR")
        agregados = cambios_git(sys.argv[2], "A")
        print(f"Validando {len(cambiados)} archivo(s) modificado(s) frente a {sys.argv[2]}")
    revisar_csproj()
    revisar_sln()
    revisar_conflictos()
    revisar_llaves()
    revisar_registro_en_proyecto()
    revisar_estandarizacion()
    revisar_mvc()
    if errores:
        print(f"Se encontraron {len(errores)} problema(s):")
        for error in errores:
            print(f"  - {error}")
        return 1
    print("Validación correcta: estandarización, código y capas MVC sin problemas.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
