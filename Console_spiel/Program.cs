using System;
using System.Data.Common;
using System.Xml.Serialization;
using TextRpg;

class Programm
{
    static void Main()
    {
        Console.WriteLine("--- Connect test to Oracle ---");
        DatabaseManager db = new DatabaseManager();
        List<Location> worldMap = db.GetLocationsFromDB();

        if (worldMap.Count == 0)
        {
            Console.WriteLine("Result: The list is empty. Check, are the data in table LOCATIONS.");
            return;
        }

        bool playing = true;
        while (playing == true)

        {
            Console.Clear();
            Console.WriteLine("---Choice location---");

            for (int i = 0; i < worldMap.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {worldMap[i].Name}");
            }
            Console.WriteLine("0. Exit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    break;
                }

                if (choice > 0 && choice <= worldMap.Count)
                {
                    TravelToLocation(worldMap[choice - 1]);
                }
            }
        }
    }

    static void TravelToLocation(Location location)
    {
        Console.WriteLine("You travel to " + location.Name);
        location.ShowInfo();
    }

}





/*
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

}*/

