namespace TheLiveTimer.Client
{
    using System;
    using Xamarin.Forms;

    public class TimerViewOld : View
    {
        public TimerViewOld()
        {
            this.BindingContext = this.ViewModel = new TimerViewModel();
        }

        internal TimerViewModel ViewModel { get; private set; }

        internal ClientTimerController Controller
        {
            get { return this.ViewModel.Controller; }
            set { this.ViewModel.Controller = value; }
        }
    }
}
