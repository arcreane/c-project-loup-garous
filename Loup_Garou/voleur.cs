using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Voleur : Personnages
    {
        public Voleur(String Name) : base(Name) { }

        public override List<string> defense { get; set; } = new List<string>() { "", "" };

        public override string role => "Voleur";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

    }
}
