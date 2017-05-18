namespace SpeakerTimer
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    public class TimeInputBox : TextBox
    {
        private bool firsttouch;

        public TimeInputBox()
        {
            this.TextAlign = HorizontalAlignment.Center;
            this.Init();
        }

        public event EventHandler TimeChanged;

        public double InputTime { get; set; }

        public void SetTime(double time)
        {
            this.Text = TimeSpan.FromSeconds(time).ToString();
        }

        protected override void OnEnter(EventArgs e)
        {
            this.Init();
            base.OnEnter(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                this.SetTimeFromInput();
                e.Handled = true;
                return;
            }

            if (this.firsttouch)
            {
                this.Text = "00:00:00";
                this.firsttouch = false;
            }

            var backspace = e.KeyChar.Equals((char)Keys.Back);
            if (backspace)
            {
                e.Handled = true;
                var index = this.SelectionStart;
                if (index % 3 == 0)
                {
                    return;
                }

                var text = this.Text;
                text = text.Remove(index - 1, 1);
                this.Text = text;
                this.SelectionStart = index - 1;
                return;
            }

            // Only digits at this newLocation
            if (!char.IsControl(e.KeyChar))
            {
                var index = this.SelectionStart;
                var inputTime = this.Text;
                // Check these are indexes of the colons ':'
                if (index < inputTime.Length && inputTime.Length < 8)
                {
                    inputTime = inputTime.Insert(index, e.KeyChar.ToString());
                    this.Text = inputTime;
                    this.SelectionStart = index + 1;
                }
                else
                {
                    inputTime = inputTime.Replace(":", string.Empty);
                    inputTime = inputTime.TrimStart(new char[] { '0' });
                    inputTime += e.KeyChar;
                    inputTime = inputTime.PadLeft(6, '0');

                    //this.input = this.input.Insert(index, e.KeyChar.ToString());

                    //this.input = this.input.TrimStart(new char[] { '0' });
                    //this.input += e.KeyChar;
                    //this.input = this.input.PadLeft(6, '0');
                    //inputTime = this.input;

                    // Mantain the input as a time string
                    //this.input = this.input.Insert(2, ":");
                    //this.input = this.input.Insert(5, ":");

                    try
                    {
                        this.Text = string.Format("{0}:{1}:{2}", inputTime.Substring(0, 2), inputTime.Substring(2, 2), inputTime.Substring(4, 2));
                        this.SelectionStart = this.Text.Length;
                    }
                    catch
                    {
                    }
                }

                e.Handled = true;
            }            

            base.OnKeyPress(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.SetTimeFromInput();

            base.OnLeave(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            const int duration = 1000;
            ToolTip tooltip = new ToolTip();
            tooltip.Show("Double-click to set the time", this, 0, 0, duration);

            base.OnMouseHover(e);
        }

        private void Init()
        {
            this.firsttouch = true;
            this.Text = "00:00:00";
        }

        private void SetTimeFromInput()
        {
            if (!this.firsttouch)
            {
                try
                {
                    var dt = DateTime.ParseExact(this.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
                    this.InputTime = dt.TimeOfDay.TotalSeconds; MessageBox.Show(this.InputTime + "");
                    this.OnTimeChanged();
                }
                catch (Exception e)
                {
                    // Error getting input...ignore and keep input as is.
                    MessageBox.Show("Input time was not understood or is not supported by this version of the Gregorian Calendar. Please try again.");
                }
            }

            this.SetTime(this.InputTime);
        }

        private void OnTimeChanged()
        {
            var handler = this.TimeChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
