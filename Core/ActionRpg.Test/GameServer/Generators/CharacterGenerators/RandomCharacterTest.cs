using ActionRpg.Server.GameServer.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Core.Test.GameServer.Generators.CharacterGenerators
{
    [TestClass]
    public class RandomCharacterTest
    {
        private static CharacterGen generator = new CharacterGen();

        [TestMethod]
        public void GenerateRandomClass()
        {
            var character = generator.GenerateCharacter();
            Assert.IsNotNull(character);
            Assert.IsTrue(character.ID.Length > 0);
            Assert.IsTrue(character.Name.Length > 0);
            Assert.IsTrue(character.Race.GetRace() != Race.Unknown);
        }
    }
}
