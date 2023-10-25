using SistemaGestionUI;

namespace SistemaGestion
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
            //Application.Run(new frm_Login());

            frm_Login frm_login = new frm_Login();
            frm_login.Show();
            Application.Run(); // quítale el parámetro aquí
        }
    }
}