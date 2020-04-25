using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loup_Garou
{
    class Village
    {
        private Random random = new Random();
        List<string> name = new List<string>() { "Macron", "Trump", "Kim Jong-un", "Aya Nakamura", "Ninho", "Bad Bunny", "Booba", "Kaaris", "Dominique", "Ariana", "Angèle", "Obama", "Steve Job", "Elon Musk", "Marge Simpson" };

        BoucEmissaire boucEmissaire;
        Cupidon cupidon;
        Sorcière sorcière;
        Voleur voleur;
        Voyante voyante;

        private String getName()
        {
            int generatedIndex = random.Next(name.Count);
            String personnageName = name.ElementAt(generatedIndex);
            name.RemoveAt(generatedIndex);
            return personnageName;
        }

        public void initVillage(List<Personnages> village)
        {
            this.boucEmissaire = new BoucEmissaire(getName());
            this.cupidon = new Cupidon(getName());
            this.sorcière = new Sorcière(getName());
            this.voleur = new Voleur(getName());
            this.voyante = new Voyante(getName());
            village.Add(boucEmissaire);
            village.Add(cupidon);
            village.Add(sorcière);
            village.Add(voleur);
            village.Add(voyante);
            Villageois[] villageois = new Villageois[7];
            for (int i = 0; i < 7; i++)
            {
                villageois[i] = new Villageois(getName());
                village.Add(villageois[i]);
            }
            LoupGarou[] loupGarou = new LoupGarou[3];
            for (int i = 0; i < 3; i++)
            {
                loupGarou[i] = new LoupGarou(getName());
                village.Add(loupGarou[i]);
            }
        }

        public Cupidon getCupidon()
        {
            return cupidon;
        }
        public Voleur getVoleur()
        {
            return voleur;
        }
        public Sorcière getSorcière()
        {
            return sorcière;
        }
        public Voyante getVoyante()
        {
            return voyante;
        }
        public BoucEmissaire getBoucEmissaire()
        {
            return boucEmissaire;
        }
    }
}
