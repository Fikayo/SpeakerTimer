namespace SpeakerTimer.Application
{
    using System;
    using System.Drawing;

    public static class ColorFader
    {
        public static Color Linear(FadeItem init, FadeItem dest, FadeItem current)
        {
            int fadeIndex = (int)(init.Time - current.Time);
            int steps = (int)(init.Time - dest.Time);
            if (fadeIndex < steps && steps > 1)
            {
                var initR = init.Color.R;
                var initG = init.Color.G;
                var initB = init.Color.B;

                var destR = dest.Color.R;
                var destG = dest.Color.G;
                var destB = dest.Color.B;

                var r = initR + ((fadeIndex * (destR - initR)) / (steps - 1));
                var g = initG + ((fadeIndex * (destG - initG)) / (steps - 1));
                var b = initB + ((fadeIndex * (destB - initB)) / (steps - 1));

                return Color.FromArgb(r, g, b);
            }

            return current.Color;
        }

        public static Color BoundedExponential(FadeItem init, FadeItem dest, FadeItem current)
        {
            int fadeIndex = (int)(init.Time - current.Time);
            int steps = (int)(init.Time - dest.Time);
            if (fadeIndex < steps)
            {
                var exp = 1 - Math.Exp(fadeIndex - steps);

                var initR = init.Color.R;
                var initG = init.Color.G;
                var initB = init.Color.B;

                var destR = dest.Color.R;
                var destG = dest.Color.G;
                var destB = dest.Color.B;

                var r = (int)((initR - destR) * exp + destR);
                var g = (int)((initG - destG) * exp + destG);
                var b = (int)((initB - destB) * exp + destB);

                return Color.FromArgb(r, g, b);
            }

            return current.Color;
        }
    }

    public class FadeItem
    {
        public Color Color { get; set; }
        public double Time { get; set; }
    }

}