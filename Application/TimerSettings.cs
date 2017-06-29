using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer.Application
{
    public abstract class TimerSettings : ITimerSettings
    {
        protected static readonly string DefaultName = "Un-named";

        protected readonly int id;
        protected string name; 

        protected TimerSettings(int id)
        {
            this.id = id;
        }

        public int Id { get { return id; } }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                if (string.IsNullOrEmpty(this.name))
                {
                    this.name = TimerSettings.DefaultName;
                }
            }
        }

        public string FinalMessage { get; set; }

        public bool BlinkOnExpired { get; set; }

        public static bool IsUntitled(string name)
        {
            return name != null && name.Equals(TimerSettings.DefaultName);
        }

        public abstract object Clone();

        protected virtual void SetDefaultSettings()
        {
            this.name = DefaultName;
        }
    }
}
