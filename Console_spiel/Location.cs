using System;
using System.Collections.Generic;

 
namespace TextRpg
{
    public class Location
    {
        public string Name { get; set; }

        public int ChestChance { get; set; }
        public string Mobs { get; set; }
        public int LocationID { get; set; }
        public string Chests { get; set; }
        
        //public List<string> Creatures { get; set; } = new(); // Оставляем только список

        // konstruktor
        public Location(string name, int chestChance, string mobs, int locationID)
        {
            Name = name;                    //1st parameter
            ChestChance = chestChance;      //2nd parameter
            Mobs = mobs;                    //3rd parameter
            LocationID = locationID;        //4th parameter
        }

        // Добавили void и исправили типы
        public void SetLocationInfo(string name, int level, int chestChance, string mobs, string chests)
        {
            Name = name;
            ChestChance = chestChance;
            Mobs = mobs;
            Chests = chests;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Location: {Name}");
            Console.WriteLine($"Chests: {Chests}");
            Console.WriteLine($"Chest Chance: {ChestChance}%");
            Console.WriteLine($"Mobs: {Mobs}");
        }
    }
}

