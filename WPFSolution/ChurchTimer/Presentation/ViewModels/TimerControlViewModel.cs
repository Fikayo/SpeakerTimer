using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChurchTimer.Application.Controllers;

namespace ChurchTimer.Presentation.ViewModels
{
    public class TimerControlViewModel : BaseViewModel
    {
        public TimerControlViewModel()
        {
            this.PlayCommand = new CommandHandler(this.PlayTimer);
            this.StopCommand = new CommandHandler(this.StopTimer);
            this.ResetCommand = new CommandHandler(this.ResetTimer);
            this.ToggleLiveCommand = new CommandHandler(this.ToggleLiveState);
        }

        public ICommand PlayCommand { get; private set; }

        public ICommand StopCommand { get; private set; }

        public ICommand ResetCommand { get; private set; }

        public ICommand ToggleLiveCommand { get; private set; }

        public TimerViewController Controller { get; internal set; }

        public bool IsLive { get; set; }
        
        #region Commands

        private void PlayTimer()
        {
            this.Controller.StartTimer();
        }

        private void StopTimer()
        {
            this.Controller.StopTimer();
        }

        private void ResetTimer()
        {
            this.Controller.ResetTimer();
        }

        private void ToggleLiveState()
        {
            this.IsLive = !this.IsLive;
            Console.WriteLine("Is LIve: {0}", this.IsLive);
            if(this.IsLive)
            {
                this.Controller.GoLive();
            }
        }

        #endregion
    }
}
