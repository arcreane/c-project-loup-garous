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
        List<Personnages> town = new List<Personnages>();
        List<Personnages> allLife = new List<Personnages>();
        List<Personnages> isDead = new List<Personnages>();
        List<Personnages> allLifeDefences = new List<Personnages>();

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

        internal void getRandomCharaters(out Personnages v1, out Personnages v2)
        {
            int generatedIndexOne = random.Next(allLife.Count);
            int generatedIndexTwo;

            do
            {
                generatedIndexTwo = random.Next(allLife.Count);
            } while ((generatedIndexOne == generatedIndexTwo));
            v1 = allLife[generatedIndexOne];
            v2 = allLife[generatedIndexTwo];
        }

        public void initVillage()
        {
            this.scapegoat = new BoucEmissaire(getName(), this);
            this.cupid = new Cupidon(getName(), this);
            this.witch = new Sorcière(getName(), this);
            this.thief = new Voleur(getName(), this);
            this.clairvoyant = new Voyante(getName(), this);
            town.Add(scapegoat);
            town.Add(cupid);
            town.Add(witch);
            town.Add(thief);
            town.Add(clairvoyant);
            Villageois[] villagers = new Villageois[7];
            for (int i = 0; i < 7; i++)
            {
                villagers[i] = new Villageois(getName(), this);
                town.Add(villagers[i]);
            }
            LoupGarou[] werewolf = new LoupGarou[3];
            for (int i = 0; i < 3; i++)
            {
                werewolf[i] = new LoupGarou(getName(), this);
                town.Add(werewolf[i]);
            }
        }


        public List<Personnages> getAllCharacterAlive()
        {
            return allLife;
        }
        public Cupidon getCupid()
        {
            return cupid;
        }
        public Voleur getThief()
        {
            return thief;
        }

        private void removeFromList(Personnages personnage)
        {
            isDead.Add(personnage);
            allLife.Remove(personnage);

        }
        internal void Kill(Personnages personnage)
        {
            removeFromList(personnage);
             Console.WriteLine("Vous avez decidez d'éliminer " + personnage.name + " qui était " + personnage.role);

            if (personnage.inLove != null)
            {
                KillLover(personnage.inLove);
                //for (int n = 0; n < allLife.Count; n++)
                //{
                //    if (allLife.ElementAt(n).name == name)
                //    {
                //        isDead.Add(allLife.ElementAt(n));
                //        allLife.ElementAt(n).inLife = false;
                //        allLife.ElementAt(n).inLove = null;
                //        allLife.RemoveAt(n);
                //        allLife.RemoveAt(l);
                //        break;
                //    }
                //}


            }
        }

        private void KillLover(Personnages personnage)
        {
            removeFromList(personnage);
            Console.WriteLine("Par le chagrin de perdre son ame soeur " + personnage.name + " decide de mettre fin à ces jours et qui était " + personnage.role);
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
