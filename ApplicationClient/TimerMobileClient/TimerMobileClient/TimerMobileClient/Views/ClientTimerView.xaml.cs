namespace TheLiveTimer.Client
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Interaction logic for BasicTimerView.xaml
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientTimerView : ContentView
    {
        public ClientTimerView()
        {
            InitializeComponent();

            this.BindingContext = this.ViewModel = new ClientTimerViewModel();
        }

        internal ClientTimerViewModel ViewModel { get; private set; }
    }
}
