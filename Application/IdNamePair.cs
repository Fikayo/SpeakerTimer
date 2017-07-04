namespace ChurchTimer.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IdNamePair
    {
        public IdNamePair(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        // override object.Equals
        public override bool Equals(object obj)
        {            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            IdNamePair that = obj as IdNamePair;
            return this.Id == that.Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Id * 17;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
