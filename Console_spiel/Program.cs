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
        
            Console.WriteLine($"Hero has {hero.HP} HP left");
            Console.WriteLine($"Enemy has {enemy.HP} HP left");
            Console.WriteLine("----------");
        }    

        if (hero.IsAlive)
            Console.WriteLine("Hero won");
        else
            Console.WriteLine("Enemy won");

        /*

        Console.WriteLine("Battle start");
        Console.WriteLine(player);
        Console.WriteLine(enemy);

        while (player.IsAlive && enemy.IsAlive)
        {
            int dmgToEnemy = player.Dealdamage();
            enemy.TakeDamage(dmgToEnemy);
            Console.WriteLine($"player deals {dmgToEnemy} damage");

            if (!enemy.IsAlive)
                break;
            
            int dmgToPlayer = enemy.Dealdamage();
            player.TakeDamage(dmgToPlayer);
            Console.WriteLine($"enemy deals {dmgToEnemy} damage");

            Console.WriteLine(player);
            Console.WriteLine(enemy);
            Console.WriteLine("------------------");
        }

    if (player.IsAlive)
    {
        Console.WriteLine("player wins");
    }
    else
    {
        Console.WriteLine("enemy wins");
    }
        */
    }
}