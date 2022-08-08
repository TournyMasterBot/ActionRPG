using ActionRpg.Models.CharacterModels;
using ActionRpg.Models.ProfessionModels;
using ActionRpg.Models.RaceModels;
using ActionRpg.Server.GameServer.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Core.Test.GameServer.Generators.CharacterGenerators
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
            var profession = new WarriorProfession();
            var human = generator.GenerateCharacter(new CreateCharacterInput(id, name, race, profession));
            Assert.IsNotNull(human);
            Assert.AreEqual(id, human.ID);
            Assert.AreEqual(name, human.Name);
            Assert.AreEqual(race, human.Race);
            Assert.AreEqual(profession, human.Profession);
        }
    }
}
