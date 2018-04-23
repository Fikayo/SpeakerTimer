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

            var timerController = new ClientTimerController(); 
            this.clientCommunicator = new ClientNetworkCommunicator(Port, QueueCapacity);
            this.clientCommunicator.TimerController = timerController;

            var timerPage = new TimerPage();
            timerPage.Controller = timerController;
            timerPage.ViewModel.NetworkCommunicator = this.clientCommunicator;
            MainPage = timerPage;

            System.Console.WriteLine("------- Starting application ----------- ");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            this.clientCommunicator.StartListening();
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
