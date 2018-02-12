namespace ChurchTimer
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using DColor = System.Drawing.Color;
    using MColor = System.Windows.Media.Color;
    using MainApplication = System.Windows.Forms.Application;

    public static class Util
    {
        public const int MAX_INPUT_TIME_ALLOWED = 86399;

        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            //SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }

        public static TEnum ToEnum<TEnum>(this string value, TEnum defaultValue = default(TEnum)) where TEnum : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            TEnum result = defaultValue;
            try
            {
                result = (TEnum)Enum.Parse(typeof(TEnum), value, true);
                return result;
            }
            catch
            {
                return result;
            }

            //return Enum.TryParse<TEnum>(value, true, out result) ? result : defaultValue;
        }

        public static DColor FromARGBString(this DColor color)
        {
            if (!color.IsKnownColor && color.A == 0 && color.R == 0 && color.G == 0 && color.B == 0)
            {
                int hex;
                if (int.TryParse(color.Name, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hex))
                {
                    Color newColor = Color.FromArgb(hex);
                    return newColor;
                }
            }

            return color;
        }

        public static MColor ToMediaColor(this DColor color)
        {
            return MColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static string GetFormName(string name)
        {
            return MainApplication.ProductName + " - " + name;
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
