﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchTimer.Data
{
    public class DbColumn
    {
        public DbColumn(string name, string type) :
            this(name, type, name.Replace(" ", string.Empty))
        {
        }

        public DbColumn(string name, string type, string parameterName)
        {
            this.Name = name;
            this.Type = type;

            var paramName = string.IsNullOrWhiteSpace(parameterName) ? name : parameterName;
            this.ParameterName = paramName.Replace(" ", string.Empty);
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public string ParameterName { get; private set; }

        public override string ToString()
        {
            return "[" + this.Name + "] " + this.Type;
        }
    }
}
