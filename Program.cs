using Personal_finance_app.Forms;

namespace Personal_finance_app
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
            //var loginForm = new LoginForm();
            //if(loginForm.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new MainForm());
            //}

            Application.Run(new MainForm());

        }
    }
}