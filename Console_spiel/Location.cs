using System;
namespace TextRpg
{
    public class Location
    {
        public string Name { get; set; }
        public int RecommendedLevel { get; set; }
        public int ChestChance { get; set; }
        public string Description { get; set; }

        public Location(string name, int level, int chestChance, string description)
        {
            Name = name;
            RecommendedLevel = level;
            ChestChance = chestChance;
            Description = description;
        }

        public void ShowInfo()
        { 
            Console.WriteLine($"Location: {Name}");
            Console.WriteLine($"Recommended Level: {RecommendedLevel}");
            Console.WriteLine($"Chest Chance: {ChestChance}%");
            Console.WriteLine($"Description: {Description}");
        }
    }
}


