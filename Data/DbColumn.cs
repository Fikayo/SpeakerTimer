using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer.Data
{
    public class DbColumn
    {
        public DbColumn(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public override string ToString()
        {
            return "[" + this.Name + "] " + this.Type;
        }
    }
}
