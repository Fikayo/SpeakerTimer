namespace TheLiveTimer.Client
{
    using Xamarin.Forms;

    public partial class TimerPage : ContentPage
    {
        private double width = 0;
        private double height = 0;

        public TimerPage()
        {
            InitializeComponent();

            this.BindingContext = this.ViewModel = new TimerPageViewModel();
        }

        internal TimerPageViewModel ViewModel { get; private set; }

        internal ClientTimerController Controller
        {
            get { return this.timerView.Controller; }
            set { this.ViewModel.Controller = this.timerView.Controller = value; }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                this.ViewModel.IsLandscapeMode = this.width > this.height;
            }
        }
    }
}
