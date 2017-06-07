namespace SpeakerTimer
{
    using System;
    using System.Configuration;
    using System.IO;
	using System.Windows.Forms;
    using MainApplication = System.Windows.Forms.Application;

    public static class Program
    {
        /// <summary>
        /// The main entry newLocation for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string productDataDir = Directory.CreateDirectory(MainApplication.ProductName).Name;
            string dataDir = Path.Combine(appdata, productDataDir);
            Directory.CreateDirectory(dataDir);
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            AppDomain.CurrentDomain.SetData("ConnectionString", ConfigurationManager.ConnectionStrings["SettingsDatabase"].ConnectionString);

            SpeakerTimer.Data.IModel simpleTimerModel = new SpeakerTimer.Data.Settings.SimpleTimerView();

            MainApplication.EnableVisualStyles();
            MainApplication.SetCompatibleTextRenderingDefault(false);
            MainApplication.Run(new SpeakerTimer.Presentation.ControlPanel());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                MessageBox.Show("Darn!!\r\n" + 
                    "An unknown error has occurred which is resulting in a program crash. Please report the problem start the application again."+
                    "Thank you."+
                "\r\n\r\n" + e.ExceptionObject,
                    MainApplication.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                return;
            }

            MessageBox.Show("An unknown error has occurred. Please report the problem start the application again." +
                    "Thank you.",
                    MainApplication.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
