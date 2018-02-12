namespace TheLiveTimer
{
    using MainApplication = Xamarin.Forms.Application;

    public partial class App : MainApplication
    {
		public App ()
		{
			InitializeComponent();

			MainPage = new TheLiveTimer.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
