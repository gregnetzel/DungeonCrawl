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
            myMonster.Dex = 1;
            myMonster.Str = 1;
            myMonster.Spd = 1;
            Assert.IsTrue(myMonster.DropXP() == 6, "DropXP has errors");
        }
        
    }
}
