namespace TheLiveTimer.Client
{
    using Xamarin.Forms;

    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();

            this.BindingContext = this.ViewModel = new TimerPageViewModel();
        }

        internal TimerPageViewModel ViewModel { get; private set; }

        internal ClientTimerController Controller
        {
            get { return this.ViewModel.Controller; }
            set { this.ViewModel.Controller = value; }
        }
    }
}
