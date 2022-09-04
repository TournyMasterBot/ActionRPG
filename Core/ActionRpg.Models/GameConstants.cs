namespace ActionRpg.Models
{
    /// <summary>
    /// This file should be kept syncronized with ActionRpg.Client.GameClient.GameModels.GameClientConstants
    /// This file is the source of truth.
    /// Todo : Figure out the best way to sync between files
    /// </summary>
    public static class GameConstants
    {
        public enum SceneType
        {
            Unknown = 0,
            Menu = 1,
            Cutscene = 2,
            Game = 3,
        }

        public enum ZoneType
        {
            Unknown = 0,
            Overworld = 1,
            Instance = 2,
        }

        public enum RegionType
        {
            Unknown = 0,
            Wilderness = 1,
            Kingdom = 2,
            Town = 3,
        }

        public enum RoomType
        {
            Unknown = 0,
            Shop = 1,
        }

        public enum LoadDataType
        {
            Unknown = 0,
            Item = 1,
            Equipment = 2,
            Monster = 3,
            Npc = 4,
            Spell = 5,
            Race = 6,
            Class = 7,
            Specialization = 8,
        }

        public enum ConsumableType
        {
            Unknown = 0,
            Potion = 1,
            Food = 2,
            Drink = 3,
        }

        public enum EquipLocation
        {
            Unknown = 0,
            Helm = 1, // Helmet
            Pauldron = 2, // Shoulder guards
            Cuirass = 3, // Breast plate
            Shirt = 4, // Under shirt
            Cuisses = 5, // Top of legs
            Shoes = 6, // Regular boots / shoes
            Belt = 7, // It goes around the waist and keeps your pants up
            Earring = 8, // It goes in the ear!
            Ring = 9, // Finger earrings
            Gauntlet = 10, // Hand armor
            Greave = 11, // Lower leg armor
            Vambrace = 12, // Lower arm armor
            Gorget = 13, // Neck armor
            Sabaton = 14, // Foot armor
            Scabbard = 15, // Sword sheath
            Glove = 16, // Hand warmers
            Rerebrace = 17, // Bicep protector
            Tasset = 18, // Belt & fancy drape top of legs from waist
        }

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

        public enum SpellDamageType
        {
            Unknown = 0,
            Force = 1,
            Fire = 2,
            Wind = 3,
            Water = 4,
            Earth = 5,
        }
    }
}
