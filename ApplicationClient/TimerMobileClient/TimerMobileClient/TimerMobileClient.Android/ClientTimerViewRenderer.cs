
using TheLiveTimer.Client.Droid;

[assembly: Xamarin.Forms.ExportRenderer(typeof(TheLiveTimer.Client.ClientTimerView), typeof(ClientTimerViewRenderer))]
namespace TheLiveTimer.Client.Droid
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Xamarin.Forms.Platform.Android;

    public class ClientTimerViewRenderer : ViewRenderer<ClientTimerView, View>
    {
        View view;

        public ClientTimerViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TheLiveTimer.Client.ClientTimerView> e)
        {
            base.OnElementChanged(e);

            var timerView = e.NewElement;
            if (Control == null)
            {
                //view = new View(Context);
                //view.SetBackgroundColor(Android.Graphics.Color.Black);

                //SetNativeControl(view);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (timerView != null)
            {
                // Subscribe
                view = new View(Context);
                view.SetBackgroundColor(Android.Graphics.Color.Black);

                SetNativeControl(view);
            }
        }
    }
}