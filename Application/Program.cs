namespace SpeakerTimer.Application
{
    using System;
	using System.Windows.Forms;
    using SpeakerTimer.Presentation;

    public static class Program
    {
        /// <summary>
        /// The main entry newLocation for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ControlPanel());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                MessageBox.Show("Darn!!\r\n" + 
                    "An unknown error has occurred which is resulting in a program crash. Please report the problem start the application again."+
                    "Thank you."+
                "\r\n\r\n" + e.ExceptionObject,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                return;
            }

            MessageBox.Show("An unknown error has occurred. Please report the problem start the application again." +
                    "Thank you.",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
