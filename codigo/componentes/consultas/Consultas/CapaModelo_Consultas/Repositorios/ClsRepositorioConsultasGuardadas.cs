using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using CapaModelo_Consultas.Contratos;
using CapaModelo_Consultas.Entidades;
/*Inicio de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/

namespace CapaModelo_Consultas.Repositorios
{
    public sealed class ClsRepositorioConsultasGuardadas : ClsRepositorio, IRepositorioConsultasGuardadas
    {
        private readonly IRepositorioMetadatos _Metadatos;

        public ClsRepositorioConsultasGuardadas(string CadenaConexion = null) : base(CadenaConexion)
        {
            _Metadatos = new ClsRepositorioMetadatos(CadenaConexion);
        }

        public IList<ClsConsultaGuardada> ConsultasFuncListar(string Tabla)
        {
            ConsultasFuncIdentificador(Tabla);
            List<ClsConsultaGuardada> Consultas = new List<ClsConsultaGuardada>();
            using (OdbcConnection Conexion = ConsultasFuncAbrirConexion())
            using (OdbcCommand Comando = new OdbcCommand("SELECT Pk_Consulta, nombreConsulta, tablaConsulta FROM tblConsulta WHERE tablaConsulta = ? ORDER BY nombreConsulta, Pk_Consulta", Conexion))
            {
                ConsultasProcAgregarParametro(Comando, Tabla);
                using (OdbcDataReader Lector = Comando.ExecuteReader())
                {
                    while (Lector.Read()) Consultas.Add(new ClsConsultaGuardada { Id = Convert.ToInt32(Lector.GetValue(0)), Nombre = Lector.GetString(1), Tabla = Lector.GetString(2) });
                }
            }
            return Consultas;
        }

        public ClsConsultaGuardada ConsultasFuncObtener(int Id, string Tabla)
        {
            using (OdbcConnection Conexion = ConsultasFuncAbrirConexion())
            using (OdbcCommand Comando = new OdbcCommand("SELECT nombreConsulta, queryConsulta FROM tblConsulta WHERE Pk_Consulta = ? AND tablaConsulta = ?", Conexion))
            {
                ConsultasProcAgregarParametro(Comando, Id);
                ConsultasProcAgregarParametro(Comando, Tabla);
                using (OdbcDataReader Lector = Comando.ExecuteReader())
                {
                    if (!Lector.Read()) throw new InvalidOperationException("La definición ya no existe en esta tabla.");
                    return new ClsConsultaGuardada { Id = Id, Nombre = Lector.GetString(0), Tabla = Tabla, Definicion = ClsFormatoDefinicion.ConsultasFuncLeer(Lector.GetString(1), Tabla) };
                }
            }
        }

        public bool ConsultasFuncExisteNombre(string Nombre, int IdExcluir = 0)
        {
            using (OdbcConnection Conexion = ConsultasFuncAbrirConexion())
            using (OdbcCommand Comando = new OdbcCommand("SELECT COUNT(*) FROM tblConsulta WHERE nombreConsulta = ? AND Pk_Consulta <> ?", Conexion))
            {
                ConsultasProcAgregarParametro(Comando, Nombre);
                ConsultasProcAgregarParametro(Comando, IdExcluir);
                return Convert.ToInt64(Comando.ExecuteScalar()) > 0;
            }
        }

        public void ConsultasProcGuardar(ClsConsultaGuardada Consulta)
        {
            ConsultasProcPersistir(Consulta, false);
        }

        public void ConsultasProcActualizar(ClsConsultaGuardada Consulta)
        {
            if (Consulta == null || Consulta.Id <= 0) throw new ArgumentException("Seleccione una consulta guardada.");
            ConsultasProcPersistir(Consulta, true);
        }

        private void ConsultasProcPersistir(ClsConsultaGuardada Consulta, bool Actualizar)
        {
            if (Consulta == null || Consulta.Definicion == null || Consulta.Tabla != Consulta.Definicion.Tabla) throw new ArgumentException("Definición inválida.");
            ConsultasFuncIdentificador(Consulta.Tabla);
            ClsConstructorConsulta.ConsultasFuncConstruir(Consulta.Definicion, _Metadatos.ConsultasFuncObtenerCampos(Consulta.Tabla), null, false);
            IList<ClsCampoConsulta> CamposCatalogo = _Metadatos.ConsultasFuncObtenerCampos("tblConsulta");
            string Definicion = ClsFormatoDefinicion.ConsultasFuncSerializar(Consulta.Definicion);
            ConsultasProcValidarLongitud(CamposCatalogo, "nombreConsulta", Consulta.Nombre);
            ConsultasProcValidarLongitud(CamposCatalogo, "tablaConsulta", Consulta.Tabla);
            ConsultasProcValidarLongitud(CamposCatalogo, "queryConsulta", Definicion);
            if (Encoding.UTF8.GetByteCount(Definicion) > 65535) throw new ArgumentException("La definición supera la capacidad de almacenamiento.");
            using (OdbcConnection Conexion = ConsultasFuncAbrirConexion())
            using (OdbcCommand Comando = new OdbcCommand(Actualizar ? "UPDATE tblConsulta SET nombreConsulta = ?, tablaConsulta = ?, queryConsulta = ? WHERE Pk_Consulta = ? AND tablaConsulta = ?" : "INSERT INTO tblConsulta (nombreConsulta, tablaConsulta, queryConsulta) VALUES (?, ?, ?)", Conexion))
            {
                ConsultasProcAgregarParametro(Comando, Consulta.Nombre);
                ConsultasProcAgregarParametro(Comando, Consulta.Tabla);
                ConsultasProcAgregarParametro(Comando, Definicion);
                if (Actualizar)
                {
                    ConsultasProcAgregarParametro(Comando, Consulta.Id);
                    ConsultasProcAgregarParametro(Comando, Consulta.Tabla);
                }
                try
                {
                    int Afectadas = Comando.ExecuteNonQuery();
                    if (Afectadas != 1)
                    {
                        if (!Actualizar || Afectadas != 0) throw new InvalidOperationException("No se guardó la definición.");
                        using (OdbcCommand Verificar = new OdbcCommand("SELECT COUNT(*) FROM tblConsulta WHERE Pk_Consulta = ? AND tablaConsulta = ? AND nombreConsulta = ? AND queryConsulta = ?", Conexion))
                        {
                            ConsultasProcAgregarParametro(Verificar, Consulta.Id);
                            ConsultasProcAgregarParametro(Verificar, Consulta.Tabla);
                            ConsultasProcAgregarParametro(Verificar, Consulta.Nombre);
                            ConsultasProcAgregarParametro(Verificar, Definicion);
                            if (Convert.ToInt64(Verificar.ExecuteScalar()) != 1) throw new InvalidOperationException("La definición ya no existe o no pertenece a esta tabla.");
                        }
                    }
                    if (!Actualizar)
                    {
                        using (OdbcCommand Identidad = new OdbcCommand("SELECT LAST_INSERT_ID()", Conexion)) Consulta.Id = Convert.ToInt32(Identidad.ExecuteScalar());
                    }
                }
                catch (OdbcException Excepcion)
                {
                    if (Excepcion.Errors.Cast<OdbcError>().Any(Error => Error.NativeError == 1062)) throw new InvalidOperationException("Ya existe una consulta con ese nombre.", Excepcion);
                    throw;
                }
            }
        }

        private static void ConsultasProcValidarLongitud(IList<ClsCampoConsulta> Campos, string Nombre, string Valor)
        {
            ClsCampoConsulta Campo = Campos.FirstOrDefault(Actual => Actual.Nombre == Nombre);
            if (Campo == null || Valor == null || (Campo.Longitud > 0 && Valor.Length > Campo.Longitud)) throw new ArgumentException("El valor no es compatible con la columna " + Nombre + " del catálogo.");
        }

        public void ConsultasProcEliminar(int Id, string Tabla)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException(nameof(Id));
            using (OdbcConnection Conexion = ConsultasFuncAbrirConexion())
            using (OdbcCommand Comando = new OdbcCommand("DELETE FROM tblConsulta WHERE Pk_Consulta = ? AND tablaConsulta = ?", Conexion))
            {
                ConsultasProcAgregarParametro(Comando, Id);
                ConsultasProcAgregarParametro(Comando, Tabla);
                if (Comando.ExecuteNonQuery() != 1) throw new InvalidOperationException("La definición ya no existe o no pertenece a esta tabla.");
            }
        }
    }
}
/*Fin de código de Diana Mishel Loeiza Ramirez 9959-23-3457 el 6/10/2026*/
