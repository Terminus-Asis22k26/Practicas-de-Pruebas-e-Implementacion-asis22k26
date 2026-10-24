using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ==================================================================
 * Área: Seguridad
 * Autores: Lourdes Isabel Melendez Pineda
 * Fecha o ultima edicion: 24/09/2026
 * ==================================================================
 * Propósito : Clase que guarda el id y el nombre de un rol, usada
 * para llevar la lista de roles del usuario en sesión.
 * ===================================================================
 */
namespace CapaControlador_Seguridad.Objetos_de_valor
{
    public class ClsRolInfo
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        // Inicio cambio - Gabriel André Guillén Pocón - 0901-23-1998
        // Indica si el rol tiene un id y un nombre válidos.
        public bool SeguridadFuncEsValido()
        {
            return IdRol > 0 && !string.IsNullOrWhiteSpace(NombreRol);
        }
        // Fin cambio - Gabriel André Guillén Pocón - 0901-23-1998
    }
}
