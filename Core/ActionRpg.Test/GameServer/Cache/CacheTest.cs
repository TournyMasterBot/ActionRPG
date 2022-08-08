using ActionRpg.Core.Cache;
using ActionRpg.Models;
using ActionRpg.Models.CharacterModels;
using ActionRpg.Models.RaceModels;
using ActionRpg.Server.GameServer.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionRpg.Core.Test.GameServer.Cache
{
    [TestClass]
    public class CacheTest
    {
        private MemCache cache = new MemCache("ActionRpgTest");
        private static CharacterGen generator = new CharacterGen();

        [TestMethod]
        public void TestGenericCache()
        {
            var setSuccess = cache.Set<int>("test-set", 5);
            Assert.IsTrue(setSuccess);
            var fetch = cache.Get<int>("test-set");
            Assert.IsNotNull(fetch);
            Assert.AreEqual(fetch, 5);
            var deleteSuccess = cache.Delete("test-set");
            Assert.IsTrue(deleteSuccess);
            cache.Set("test-set-1", 5);
            cache.Set("test-set-2", 10);
            cache.Set("test-set-3", 15);
            var fetchArray = cache.GetValues<int>(new[] { "test-set-1", "test-set-2", "test-set-3" });
            Assert.IsTrue(fetchArray.Length == 3);
            var fetchMap = cache.GetMappedValues<int>(new[] { "test-set-1", "test-set-2", "test-set-3" });
            Assert.IsTrue(fetchMap.Count == 3);
            Assert.IsTrue(fetchMap.ContainsKey("test-set-1"));
            Assert.AreEqual(fetchMap["test-set-1"], 5);
            Assert.IsTrue(fetchMap.ContainsKey("test-set-2"));
            Assert.AreEqual(fetchMap["test-set-2"], 10);
            Assert.IsTrue(fetchMap.ContainsKey("test-set-3"));
            Assert.AreEqual(fetchMap["test-set-3"], 15);
        }

        [TestMethod]
        public void TestRaceCache()
        {
            var success = cache.Set("test-race", new HumanRace().GetRace());
            Assert.IsTrue(success);
            var race = cache.Get<GameConstants.Race>("test-race");
            Assert.AreEqual(GameConstants.Race.Human, race);
        }

        [TestMethod]
        public void TestCharacterCache()
        {
            var success = cache.Set("test-generated-character", generator.GenerateCharacter());
            Assert.IsTrue(success);
            var character = cache.Get<Character>("test-generated-character");
            Assert.IsNotNull(character);
            Assert.IsTrue(character.ID.Length > 0);
            Assert.IsTrue(character.Name.Length > 0);
            Assert.IsTrue(character.Profession.GetProfession() != GameConstants.Profession.Unknown);
            Assert.IsTrue(character.Race.GetRace() != GameConstants.Race.Unknown);
        }
    }
}
