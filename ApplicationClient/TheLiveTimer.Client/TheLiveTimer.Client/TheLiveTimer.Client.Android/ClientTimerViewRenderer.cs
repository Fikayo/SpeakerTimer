//[assembly: Xamarin.Forms.ExportRenderer(typeof(TheLiveTimer.Client.ClientTimerView), typeof(TheLiveTimer.Client.Droid.ClientTimerViewRenderer))]
namespace TheLiveTimer.Client.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using TheLiveTimer.Client;
    using TheLiveTimer.Client.Droid;
    using Xamarin.Forms.Platform.Android;

    public class ClientTimerViewRenderer : ViewRenderer
    {
        View view;
        
        public ClientTimerViewRenderer(Context context) : base(context)
        {
            this.SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<TheLiveTimer.Client.ClientTimerView> e)
        //{
        //    base.OnElementChanged(e);

        //    var timerView = e.NewElement;
        //    if (Control == null)
        //    {
        //        //view = new View(Context);
        //        //view.SetBackgroundColor(Android.Graphics.Color.Black);

        //        //SetNativeControl(view);
        //    }

        //    if (e.OldElement != null)
        //    {
        //        // Unsubscribe
        //    }

        //    if (timerView != null)
        //    {
        //        // Subscribe
        //        view = new View(Context);
        //        view.SetBackgroundColor(Android.Graphics.Color.Black);

        //        SetNativeControl(view);
        //    }
        //}
    }
}