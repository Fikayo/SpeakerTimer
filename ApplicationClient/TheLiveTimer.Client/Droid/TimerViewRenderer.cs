[assembly: Xamarin.Forms.ExportRenderer(typeof(TheLiveTimer.Client.TimerView), typeof(TheLiveTimer.Client.Droid.TimerViewRenderer))]
namespace TheLiveTimer.Client.Droid
{
	using System;
	using System.ComponentModel;
	using Android.Content;
	using Android.Graphics;
	using Android.Views;
	using Xamarin.Forms;
	using Xamarin.Forms.Platform.Android;

	public class TimerViewRenderer : ViewRenderer<TimerView, AndroidTimerView>
    {
        AndroidTimerView timerView;

        public TimerViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimerView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                Console.WriteLine(" --> timer view set -- ");

                this.timerView = new AndroidTimerView(this.Context);
                this.SetNativeControl(this.timerView);
            }

            Console.WriteLine(" --> on element changed -- ");

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
            }

            if (e.NewElement != null)
            {
                // Subscribe to event handlers and set up object
            }
        }

	}
}
