using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politikusok
{
    abstract class Person: IDrunk
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set {
                if (string.IsNullOrEmpty(value))
                    throw new NullReferenceException("A személynév nem lehet null.");
                if(value.Length < 5)
                    throw new TooShortException();
                name = value; }
        }

        private byte age;

        public virtual byte Age
        {
            get { return age; }
            protected set { age = value; }
        }

        protected Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public abstract void GetDrunk(byte level);
    }
}
