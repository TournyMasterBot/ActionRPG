using ActionRpg.Models.ProfessionModels;
using ActionRpg.Models.RaceModels;

namespace ActionRpg.Models.CharacterModels
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Character : ICharacter
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public IRace Race { get; set; }
        public IProfession Profession { get; set; }


        public Character()
        {

        }


        public Character(string id, string name, IRace race, IProfession profession)
        {
            ID = id;
            Name = name;
            Race = race;
            Profession = profession;
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
