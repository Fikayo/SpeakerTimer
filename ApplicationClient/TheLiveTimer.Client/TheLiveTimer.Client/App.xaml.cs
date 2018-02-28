using Xamarin.Forms;

namespace TheLiveTimer.Client
{
    using TheLiveTimer.Client.Network;

    public partial class App : Application
    {
        private const int Port = 5004;
        private const int UDPPort = 5004;
        private const int QueueCapacity = 20;

        private ClientNetworkCommunicator clientCommunicator;

        public App()
        {
            InitializeComponent();


            this.clientCommunicator = new ClientNetworkCommunicator(Port, QueueCapacity);
            var timerPage = new TimerPage();
            timerPage.Controller = this.clientCommunicator.TimerController;
            MainPage = timerPage;

            System.Console.WriteLine("------- Starting application ----------- ");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            this.clientCommunicator.OpenCommnuication();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
