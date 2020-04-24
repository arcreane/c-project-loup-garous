using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    abstract class Personnages
    {
        public Personnages(String newname)
        {
            name = newname;
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


        public abstract bool inLove
        {
            get;
            set;
        }
    }
}
