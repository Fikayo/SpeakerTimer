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
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(TheLiveTimer.Client.RoundedBoxView), typeof(TheLiveTimer.Client.Droid.RoundedBoxViewRenderer))]
namespace TheLiveTimer.Client.Droid
{
    internal class RoundedBoxViewRenderer : BoxRenderer
    {
        public RoundedBoxViewRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            var rbv = (RoundedBoxView)this.Element;

            Rect bounds = new Rect();
            this.GetDrawingRect(bounds);

            // Set up the box and the paint fill
            Rect box = new Rect();
            box.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

            Paint paint = new Paint()
            {
                Color = rbv.Color.ToAndroid(),
                AntiAlias = true,
            };

            // Draw the box
            canvas.DrawRoundRect(new RectF(box), (float)rbv.CornerRadius, (float)rbv.CornerRadius, paint);

            // Setup the stroke
            paint.Color = rbv.Stroke.ToAndroid();
            paint.StrokeWidth = (float)rbv.StrokeThickness;
            paint.SetStyle(Paint.Style.Stroke);

            // Draw the stroke
            canvas.DrawRoundRect(new RectF(bounds), (float)rbv.CornerRadius, (float)rbv.CornerRadius, paint);

        }
    }
}