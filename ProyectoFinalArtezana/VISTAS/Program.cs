using DAL;
using VISTAS.AuditoriaClieVISTAS;
using VISTAS.ClienteVISTAS;
using VISTAS.DetalleCarritoProductoVISTAS;
using VISTAS.PermisoVISTAS;
using VISTAS.RolPermisoVISTAS;
using VISTAS.RolVISTAS;
using VISTAS.UsuariosVISTAS;

namespace VISTAS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new RolInterfaz());
        }
    }
}