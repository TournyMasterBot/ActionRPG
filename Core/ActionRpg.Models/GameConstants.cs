namespace ActionRpg.Models
{
    public static class GameConstants
    {
        public enum Race
        {
            Unknown = 0,
            Human = 1,
            Dwarf = 2,
            Elf = 3,
            Fae = 4,
            Minotaur = 5,
            Angel = 6,
            Demon = 7,
            Devil = 8,
            Dragon = 9,
            Giant = 10,
            Gryphon = 11,
            Dog = 12,
            Cat = 13,
            Goblin = 14,
            Orc = 15,
            HobGoblin = 16,
            Halfling = 17,
            Mermaid = 18,
            Troll = 19,
            Cyclops = 20,
            Centaur = 21,
            Dryad = 22,
            Gnome = 23,
        }

        public enum Profession
        {
            Unknown = 0,
            Warrior = 1,
            Mage = 2,
            Cleric = 3,
        }

        public static Dictionary<Race, int> RaceMaxLevel = new Dictionary<Race, int>()
        {
            { Race.Human, 100 },
        };

        public static Dictionary<Profession, int> ProfessionMaxLevel = new Dictionary<Profession, int>()
        {
            { Profession.Warrior, 100 },
            { Profession.Mage, 100 },
            { Profession.Cleric, 100 },
        };
    }
}
