using ActionRpg.Server.GameModels.CharacterModels;
using ActionRpg.Server.GameModels.RaceModels;
using ActionRpg.Server.GameServer.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ActionRpg.Server.GameModels.GameConstants;

namespace ActionRpg.Test.GameServer.Generators.CharacterGenerators
{

    [TestClass]
    public class HumanTests
    {
        private static CharacterGen generator = new CharacterGen();

        [TestMethod]
        public void GenerateUndefinedInputHumanTest()
        {
            var human = generator.GenerateCharacter(Race.Human);
            Assert.IsNotNull(human);
            Assert.IsTrue(human.ID.Length > 0);
            Assert.IsTrue(human.Name.Length > 0);
            Assert.AreEqual(human.Race.GetRace(), Race.Human);
        }

        [TestMethod]
        public void GenerateDefinedInputHumanTest()
        {
            var id = Guid.NewGuid().ToString("d");
            var name = Guid.NewGuid().ToString("d");
            var race = new HumanRace();
            var human = generator.GenerateCharacter(new CreateCharacterInput(id, name, race));
            Assert.IsNotNull(human);
            Assert.AreEqual(id, human.ID);
            Assert.AreEqual(name, human.Name);
            Assert.AreEqual(race, human.Race);
        }
    }
}
