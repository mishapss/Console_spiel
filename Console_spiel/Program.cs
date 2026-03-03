using System;
using TextRpg;

class Programm
{
    static void Main()
    {
        
        var enemy = new Beastman();
        var hero = new Warrior("Hero");
        
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
            
            if (dmgToHero > 46)
            {
                Console.WriteLine("Critical hit!");
                hero.UsePotion();
            }
        
            Console.WriteLine($"Hero has {hero.HP} HP left");
            Console.WriteLine($"Enemy has {enemy.HP} HP left");
            Console.WriteLine("----------");
        }    

        if (hero.IsAlive)
            Console.WriteLine("Hero won");
        else
            Console.WriteLine("Enemy won");
    }
        
}

