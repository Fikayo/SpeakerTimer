using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TheLiveTimer.Client
{
    public partial class TimerView : ContentView
    {
        public static readonly BindableProperty LandscapeProperty = BindableProperty.Create(
            nameof(this.IsLandscape),
        );


        public TimerView()
        {
            InitializeComponent();

            this.BindingContext = this.ViewModel = new TimerViewModel();
        }

        internal TimerViewModel ViewModel { get; private set; }

        internal ClientTimerController Controller
        {
            get { return this.ViewModel.Controller; }
            set { this.ViewModel.Controller = value; }
        }

        public bool IsLandscape
        {
            get;set;
        }
    }
}
