namespace ChurchTimer
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
        static void House()
        {
            //string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string productDataDir = Directory.CreateDirectory(MainApplication.ProductName).Name;
            //string dataDir = Path.Combine(appdata, productDataDir);
            //Directory.CreateDirectory(dataDir);
            //AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var success = true;
            //try
            //{
            //    AppDomain.CurrentDomain.SetData("ConnectionString", ConfigurationManager.ConnectionStrings["SettingsDatabase"].ConnectionString);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("There was a problem while loading the config file: " + ex.Message);
            //    success = false;
            //}

            if (success)
            {
                MainApplication.EnableVisualStyles();
                MainApplication.SetCompatibleTextRenderingDefault(false);
                ////MainApplication.Run(new ChurchTimer.Presentation.ControlPanel());

                var controller = new ChurchTimer.Application.Controllers.TimerViewController();
                controller.Settings = ChurchTimer.Application.SimpleTimerSettings.Default;
                controller.Settings.TimerDuration.Duration = 300;

                var timerView = new ChurchTimer.Presentation.BasicTimerView(controller);
                controller.StartTimer();
                MainApplication.Run(new ChurchTimer.Presentation.PresentationTimerForm(timerView));
            }
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
