using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    abstract class Personnages
    {
        protected Village myVillage;

        public Personnages(String newname, Village village)
        {
            name = newname;
            myVillage = village;
        }
        public String name
        {
            get;
            set;
        }

        public abstract List<string> defense
        {
            get;
            set;
        }

        public abstract string role
        {
            get;
            set;

        }
        public abstract bool inLife
        {
            get;
            set;

        }


        public Personnages inLove
        {
            get;
            set;
        } = null;

        protected static void setInLove(Personnages v1, Personnages v2)
        {
            v1.inLove = v2;
            v2.inLove = v1;

            Random random = new Random();
            Personnages[] lovers = new Personnages[2];
            lovers[0] = v1;
            lovers[1] = v2;
            foreach (var lover in lovers)
            {
                int generatedIndexDefencesOne = random.Next(v1.defense.Count);
                lover.defense[generatedIndexDefencesOne] = "Je suis amoureux";
                lover.defense.Add("Je suis lié à une autre personne");
                Console.WriteLine(lover.name);
            }
        }
    }
}
