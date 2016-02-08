namespace SpeakerTimer
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class Util
    {
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetWatermark(/* this */ TextBox textBox, string watermarkText)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }

        public static TEnum ToEnum<TEnum>(/* this */ string value, TEnum defaultValue = default(TEnum)) where TEnum : struct
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

        public static Color FromARGBString(/* this */ Color color)
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
    }
}
