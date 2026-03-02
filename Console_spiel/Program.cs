using System;
using TextRpg;

class Programm
{
    static void Main()
    {
        
        var cow = new Cow();
        var hero = new Warrior("Hero");
        Console.WriteLine(cow.DealDamage());


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