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

        BoucEmissaire scapegoat;
        Cupidon cupid;
        Sorcière witch;
        Voleur thief;
        Voyante clairvoyant;

        private String getName()
        {
            int generatedIndex = random.Next(name.Count);
            String personnageName = name.ElementAt(generatedIndex);
            name.RemoveAt(generatedIndex);
            return personnageName;
        }

        public void initVillage(List<Personnages> town)
        {
            this.scapegoat = new BoucEmissaire(getName());
            this.cupid = new Cupidon(getName());
            this.witch = new Sorcière(getName());
            this.thief = new Voleur(getName());
            this.clairvoyant = new Voyante(getName());
            town.Add(scapegoat);
            town.Add(cupid);
            town.Add(witch);
            town.Add(thief);
            town.Add(clairvoyant);
            Villageois[] villagers = new Villageois[7];
            for (int i = 0; i < 7; i++)
            {
                villagers[i] = new Villageois(getName());
                town.Add(villagers[i]);
            }
            LoupGarou[] werewolf = new LoupGarou[3];
            for (int i = 0; i < 3; i++)
            {
                werewolf[i] = new LoupGarou(getName());
                town.Add(werewolf[i]);
            }
        }

        public Cupidon getCupid()
        {
            return cupid;
        }
        public Voleur getThief()
        {
            return thief;
        }
        public Sorcière getWitch()
        {
            return witch;
        }
        public Voyante getClairvoyant()
        {
            return clairvoyant;
        }
        public BoucEmissaire getScapegoat()
        {
            return scapegoat;
        }
    }
}
