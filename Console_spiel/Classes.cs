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
        public int Potions { get; set; } = 1;
        public double ChanceToRun { get; set; } = 0.25;
        public int AttackCounter { get; protected set; } = 0;

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

        public bool TryRunAway()
        {
            double roll = Rng.NextDouble(); // number from 0 to 1
            if (roll < ChanceToRun)
            {
                Console.WriteLine("You escaped");
                return true;
            }
            else 
            {
                return false;
            }
        }

        public virtual void Heal(int amount)
        {
            if (Potions <= 0)
            {
                Console.WriteLine("No Potions left!");
                return;
            }
            HP = Math.Min(MaxHP, HP + amount); // HP + amount, но не больше MaxHP
        }

        public void UsePotion()
        {
             if (Potions <= 0)
            { 
                Console.WriteLine("No Potions left!");
                return;
            }


            Console.WriteLine("Do you want to use a potion?");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {     
                
                if (HP == MaxHP)
                {
                    Console.WriteLine("HP is already full. You can´t use a potion");
                    return;
                }
                else
                {
                    Console.WriteLine("Hero uses a heal-potion");
                    Heal(100);

                    Potions--;

                    Console.WriteLine($"potions left&: {Potions}");
                    Console.WriteLine($"{Name} HP: {HP}/{MaxHP}");
                }
                
            }
        }
            
        public void startBattle()
        {
            var enemy = new Beastman();
            var hero = new Warrior("Hero");

            Console.WriteLine("You choice to fight");

            while (enemy.IsAlive && hero.IsAlive)
            {

                int dmgToEnemy = hero.DealDamage();
                enemy.TakeDamage(dmgToEnemy);
                Console.WriteLine($"hero deals {dmgToEnemy} damage");

                if (!enemy.IsAlive)
                    break;

                int dmgToHero = enemy.DealDamage();
                hero.TakeDamage(dmgToHero);
                Console.WriteLine($"enemy deals {dmgToHero} damage");

                Console.WriteLine($"Hero has {hero.HP} HP left");
                Console.WriteLine($"Enemy has {enemy.HP} HP left");
                Console.WriteLine("----------");
                AttackCounter++;

                if (AttackCounter == 3)
                {
                    hero.UsePotion();
                    AttackCounter = 0; 
                }
                
            }

            if (hero.IsAlive)
                Console.WriteLine("Hero won");
            else
                Console.WriteLine("Enemy won");
        }


            /*использовать еду*/

            /*использовать заклинание по возможности*/

            // shield absorbs first
        
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
