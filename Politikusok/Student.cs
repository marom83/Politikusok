using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politikusok
{
    class Student : Person, ILearn
    {
        private List<Competence> competences;

        static Random rnd = new Random();
        public override byte Age
        {
            protected set
            {
                if (value < 18)
                    throw new TooYoungException();
                base.Age = value;
            }
        }
        public override void GetDrunk(byte level)
        {
            for (int i = level%10; i > 0; i--)
            {
                competences.RemoveAt(rnd.Next(0, competences.Count));
            }
        }

        public bool Learn(Competence competence)
        {
            if (competences.Contains(competence))
                return false;
                competences.Add(competence);
            return true;
        }

        public Student(string name, byte age, List<Competence> competences): base(name, age)
        {
            if (competences.Count == 0)
                throw new Exception();
            this.competences = competences;
        }
    }
}
