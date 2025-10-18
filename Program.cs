using Personal_finance_app.Forms;
using Personal_finance_app.Helpers;

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

            // Init
            if(!DbHelper.InitDatabase())
            {
                MessageBox.Show("Failed to initialize database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}