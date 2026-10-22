using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaVista_Consultas.Componentes
{
    public class ClsTableLayoutPanelConsultas : TableLayoutPanel
    {
        /*Inicio de código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
        private int _ActualizacionesVisuales;
        private IntPtr _VentanaOculta;

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr ConsultasFuncEnviarMensaje(IntPtr Ventana, int Mensaje, IntPtr Parametro, IntPtr Datos);

        [DllImport("user32.dll", EntryPoint = "IsWindowVisible")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ConsultasFuncEsVentanaVisible(IntPtr Ventana);

        [DllImport("user32.dll", EntryPoint = "RedrawWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ConsultasFuncRedibujarVentana(IntPtr Ventana, IntPtr Rectangulo, IntPtr Region, uint Opciones);

        public ClsTableLayoutPanelConsultas()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        internal void ConsultasProcOcultarActualizacion()
        {
            if (_ActualizacionesVisuales++ != 0 || !IsHandleCreated || !ConsultasFuncEsVentanaVisible(Handle)) return;
            _VentanaOculta = Handle;
            ConsultasFuncEnviarMensaje(_VentanaOculta, 0x000B, IntPtr.Zero, IntPtr.Zero);
        }

        internal void ConsultasProcRestaurarActualizacion()
        {
            if (--_ActualizacionesVisuales != 0) return;
            IntPtr Ventana = _VentanaOculta;
            _VentanaOculta = IntPtr.Zero;
            if (Ventana == IntPtr.Zero || IsDisposed || Disposing || !IsHandleCreated || Handle != Ventana) return;
            ConsultasFuncEnviarMensaje(Ventana, 0x000B, new IntPtr(1), IntPtr.Zero);
            ConsultasFuncRedibujarVentana(Ventana, IntPtr.Zero, IntPtr.Zero, 0x0485);
        }
        /*Fin del código de Carlos Andres Arriaza Lara 0901-23-13862 el 5/10/2026*/
    }
}
