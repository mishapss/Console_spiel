using System;

namespace TextRpg
{
    public enum ResourceType
    {
        None,
        Mana,
        Rage,
        Energy,
        Concentration
    }

    public abstract class Character
    {
        public string Name { get; protected set; }

        public int MaxHP { get; protected set; }
        public int HP { get; protected set; }
        public int Shield { get; protected set; }

        public int Mana { get; protected set; }
        public int RageGeneration { get; protected set; }
        public int Energy { get; protected set; }
        public int Concentration { get; protected set; }
        public int Rage { get; protected set; }

        public int Attack { get; protected set; }
        public int Spell { get; protected set; }

        // crit multiplier (e.g. 2.3 means x2.3)
        public double CritHit { get; protected set; }
        public double CritChance { get; protected set; }
        public int PetBonusDamage { get; protected set; }

        protected static readonly Random Rng = new();

        public bool IsAlive
        {
            get { return HP > 0; }
        }

        protected Character(string name)
        {
            Name = name;
        }

        public virtual int DealDamage()
        {
            // base damage: physical + small magic contribution (simple formula)
            int baseDmg = Attack + (int)Math.Round(Spell * 0.35);

            bool isCrit = Rng.NextDouble() < CritChance;
            if (isCrit)
            {
                baseDmg = (int)Math.Round(baseDmg * CritHit);
            }


            // avoid negative / zero damage edge cases
            return Math.Max(1, baseDmg);
        }

        public virtual void TakeDamage(int amount)
        {
            if (amount < 0) return;

            // shield absorbs first
            int absorbed = Math.Min(Shield, amount);
            Shield -= absorbed;

            int left = amount - absorbed;
            HP = Math.Max(0, HP - left);
        }

        public virtual void Heal()
        {
            /*использовать зелье*/

            /*
            1) проверить наличие зелья
            2) спросить действительно ли хочешь использовать зелье
            3) увеличить хр на количество, которое позволяет зелье
            */

            Console.WriteLine("Do you want to use a poison?");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
                Console.WriteLine("Hero uses a heal-poison");

            

            /*использовать еду*/

            /*использовать заклинание по возможности*/
            
            // shield absorbs first
        }
    }

    public class Cow : Character
    {
        public Cow() : base("Cow")
        {
            MaxHP = 150;
            HP = 149;
            Shield = 0;
            Attack = 5;
            Spell = 0;
            CritHit = 1.2;
            CritChance = 0.05;
        }
    }

    public class Beastman : Character
    {
        public Beastman() : base("Beastman")
        {
            MaxHP = 1100;
            HP = 1100;
            Shield = 120;
            Mana = 0;
            Attack = 42;
            Spell = 10;
            CritHit = 2.3;
            CritChance = 0.17;
            RageGeneration = 0;
            Energy = 0;
            Rage = 0;
            Concentration = 0;
            PetBonusDamage = 0;       
        }
    }

    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            MaxHP = 1200;
            HP = 1200;
            Shield = 180;
            Attack = 40;
            Spell = 0;
            CritHit = 2.5;
            CritChance = 0.15;
            RageGeneration = 15;
            PetBonusDamage = 0;
        }
    }

}
