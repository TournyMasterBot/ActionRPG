using ActionRpg.Models.ProfessionModels;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Server.GameModels.Helpers
{
    public static class ProfessionHelpers
    {
        public static IProfession? GetProfessionFromInt(int professionSelection)
        {
            if (professionSelection > Enum.GetValues(typeof(Profession)).Length)
            {
                return null;
            }
            var profession = (Profession)professionSelection;
            return GenerateRace(profession);
        }

        public static IProfession? GenerateRace(Profession profession)
        {
            var professions = GeneralHelpers.GetAll<IProfession>().ToArray();
            if (professions.Length == 0)
            {
                return null;
            }

            return professions.FirstOrDefault(x => x?.GetProfession() == profession);
        }

        public static IProfession GenerateRandomProfession()
        {
            var professions = GeneralHelpers.GetAll<IProfession>().ToArray();
            if (professions == null || professions.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(professions));
            }
            var profession = professions[GeneralHelpers.GetRandBetweenTwoNumbers(0, professions.Length - 1)];
            if (profession == null)
            {
                throw new ArgumentOutOfRangeException(nameof(profession));
            }
            return profession;
        }

        public static Profession[] GetAllProfessions()
        {
            return GeneralHelpers.GetEnumItems<Profession>().Where(x => x != Profession.Unknown).ToArray();
        }
    }
}
