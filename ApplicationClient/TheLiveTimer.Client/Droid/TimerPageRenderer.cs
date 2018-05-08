[assembly: Xamarin.Forms.ExportRenderer(typeof(TheLiveTimer.Client.TimerPage), typeof(TheLiveTimer.Client.Droid.TimerPageRenderer))]
namespace TheLiveTimer.Client.Droid
{
    using System;
    using Android.Content;
    using Android.Graphics;
    using Android.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class TimerPageRenderer : PageRenderer
    {
        public TimerPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            //if (e.OldElement != null || Element == null)
            //{
            //    return;
            //}

            //try
            //{
            //    SetupUserInterface();
            //    SetupEventHandlers();
            //    AddView(view);
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(@"           ERROR: ", ex.Message);
            //}
        }
    }
}
