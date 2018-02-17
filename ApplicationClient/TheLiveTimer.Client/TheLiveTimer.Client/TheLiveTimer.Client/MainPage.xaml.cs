using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TheLiveTimer.Client
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.BindingContext = this.ViewModel = new TimerPageViewModel();
        }

        internal TimerPageViewModel ViewModel { get; private set; }

    }
}
