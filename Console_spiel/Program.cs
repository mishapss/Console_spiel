using System;
using System.Data.Common;
using TextRpg;

class Programm
{
    static void Main()
    {
        
        List<Location> locations= new List<Location>
        {
            //Location(string name, int level, int chestChance, string description)
            new Location("Greenwood Forest", 1, 20, "A friendly forest filled with undangerous creatures."),

            new Location("Sand Desert", 2, 25, "A scorching desert where sand elementals and ancient predators roam beneath the burning sun."),

            new Location("Ruins of the Forgotten", 3, 30, "Ancient ruins haunted by undead and cursed guardians from a forgotten civilization."),

            new Location("Hive of Aqir", 4, 35, "A massive underground hive filled with Aqir warriors and venomous creatures."),

            new Location("Iron Wastes", 5, 40, "A barren land of rusted machines and roaming iron giants left from ancient wars."),

            new Location("Titan Vault Approach", 6, 45, "The outer halls of an ancient titan vault guarded by powerful constructs and elite enemies."),

            new Location("Ulduar Gate (Boss Zone)", 7, 60, "The entrance to the legendary titan complex Ulduar, where a powerful boss awaits."),

        };

        Console.WriteLine("Choice location:");

        for (int i = 0; i < locations.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {locations[i].Name}");
        }

        int locationChoice = int.Parse(Console.ReadLine());

        Location currentlocation = locations[locationChoice - 1];

        Console.WriteLine($"You travel to {currentlocation.Name}");

        var enemy = new Beastman();
        var hero = new Warrior("Hero");

        currentlocation.ShowInfo();


        Console.WriteLine("A wild Beastman appears! Now you have a choice" +
            "1 - Attack" +
            "2 - Try to run" +
            "What do you gonna do? (1/2)");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            hero.startBattle();
        }

        else if (choice == "2")
        {
            Console.WriteLine("You chose to try to run!");

            bool escaped = hero.TryRunAway();

            if (escaped)
            {
                Console.WriteLine("You escaped successfully!");
                return;
            }

            Console.WriteLine("Failed to escape. You have to fight");
            hero.startBattle();
        }

        else
        {
            Console.WriteLine("Invalid input, you have to fight");
            hero.startBattle();
        }

        
      
    }
        
}

