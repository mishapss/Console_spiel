using System;
using System.Data.Common;
using TextRpg;

class Programm
{
    static void Main()
    {
        Console.WriteLine("--- Connect test to Oracle ---");
        DatabaseManager db = new DatabaseManager();

        try
        {
            List<Location> locations = db.GetLocationsFromDB();

            if (locations == null || locations.Count == 0)
            {
                Console.WriteLine("Result: The lsit is empty. Check, are the data in table LOCATIONS.");
            }
            else
            {
                Console.WriteLine($"Good Locations were found: {locations.Count}");
                foreach (var loc in locations)
                {
                    Console.WriteLine($"- {loc.Name} (mobs: {loc.Mobs})");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Connect error:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\ntip any keyboard to exit");
        Console.ReadKey();
    }
    /*{
        DatabaseManager db = new DatabaseManager();
        List<Location> locations = db.GetLocationsFromDB();

        if (locations.Count == 0)
        {
            Console.WriteLine("Database is empty or connection failed!");
            return;
        }

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

        
      
    }*/

}

