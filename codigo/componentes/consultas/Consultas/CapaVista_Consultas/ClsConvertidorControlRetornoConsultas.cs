using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using CapaVista_Consultas.Componentes;

namespace CapaVista_Consultas
{
    //Inicio Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    public sealed class ClsConvertidorControlRetornoConsultas : ReferenceConverter
    {
        public ClsConvertidorControlRetornoConsultas() : base(typeof(Control))
        {
        }

        internal static bool ConsultasFuncCompatible(Control Control)
        {
            return Control is TextBox || Control is RichTextBox || Control is Label || Control is UsrTextBoxConsultas || (Control is ComboBox && ((ComboBox)Control).DropDownStyle != ComboBoxStyle.DropDownList);
        }

        protected override bool IsValueAllowed(ITypeDescriptorContext Contexto, object Valor)
        {
            return Valor == null || (Valor is Control && ConsultasFuncCompatible((Control)Valor));
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext Contexto) { return true; }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext Contexto)
        {
            Consultas Boton = Contexto?.Instance as Consultas;
            Form Formulario = Boton?.FindForm();
            if (Formulario == null)
            {
                IDesignerHost Host = Contexto?.GetService(typeof(IDesignerHost)) as IDesignerHost;
                Formulario = Host?.RootComponent as Form;
            }
            List<Control> Controles = new List<Control>();
            if (Formulario != null) ConsultasProcAgregarControles(Formulario, Controles);
            if (Contexto?.Container != null) Controles.RemoveAll(Control => Control.Site == null);
            return new StandardValuesCollection(new object[] { null }.Concat(Controles.OrderBy(Control => Control.Site?.Name ?? Control.Name, StringComparer.Ordinal).Cast<object>()).ToArray());
        }

        private static void ConsultasProcAgregarControles(Control Padre, List<Control> Controles)
        {
            foreach (Control Hijo in Padre.Controls)
            {
                if (ConsultasFuncCompatible(Hijo)) Controles.Add(Hijo);
                if (!(Hijo is UsrTextBoxConsultas)) ConsultasProcAgregarControles(Hijo, Controles);
            }
        }
        //Fin Diego Fernando Santizo Samayoa 0901-22-15950 05/10/2026
    }
}
