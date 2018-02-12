namespace ChurchTimer.Presentation.ViewModels
{
    using ChurchTimer.Application.Controllers;
    using System.Windows;

    public class ControlPanelViewModel : WindowViewModel
    {
        public ControlPanelViewModel(Window window, TimerViewController controller) : base(window)
        {
            this.Controller = controller;
        }

        public TimerViewController Controller { get; internal set; }

        public string AddTimerText
        {
            get
            {
                var text = " Welcome to {0}. Click here to add a timer to the panel.";
                text += "\nYou can add as many as you like by using the `+` symbol in the top left corner.";
                return text;
            }
        }
    }
}
