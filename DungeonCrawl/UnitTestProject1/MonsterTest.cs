using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DungeonCrawl.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class MonsterTest
    {
        [TestMethod]
        public void Monster_TestDropXP()
        {
            var myMonster = new Monster();
            myMonster.Level = 4;

            Assert.IsTrue(myMonster.DropXP() == 8, "DropXP has errors");
        }

        [TestMethod]
        public void Monster_TestDropItems()
        {
            var myMonster = new Monster();
            Item i = myMonster.DropItem();
            Assert.IsNotNull(i, "DropItems has error");
        }
    }
}
