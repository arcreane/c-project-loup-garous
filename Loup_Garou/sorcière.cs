using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Sorcière : Personnages
    {
        public Sorcière(String Name) : base(Name) { }


        public override List<string> defense { get; set; } = new List<string>() { "", "" };

        public override string role => "Sorcière";

        public override bool inLife { get; set; } = true;
        public override bool inLove { get; set; } = false;

        }
}
