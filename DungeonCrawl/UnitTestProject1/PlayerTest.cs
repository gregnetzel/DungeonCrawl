using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DungeonCrawl.Models;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for PlayerTest
    /// </summary>
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Player_TestIsDead0hp()
        {
            var myPlayer = new Player();

            myPlayer.HP = 0;

            Assert.IsTrue(myPlayer.IsDead(), "IsDead has errors");
        }
       
        [TestMethod]
        public void Player_TestIsAlive()
        {
            var myPlayer = new Player();

            myPlayer.HP = 2;

            Assert.IsFalse(myPlayer.IsDead(), "IsDead has errors");
        }

        [TestMethod]
        public void Player_TestAddXP()
        {
            var myPlayer = new Player();

            myPlayer.CurrentXP = 0;
            myPlayer.AddXP(50);

            Assert.IsTrue(myPlayer.CurrentXP == 50, "AddXP has errors");
        }

        [TestMethod]
        public void Player_TestLevelUp()
        {
            var myPlayer = new Player();
            myPlayer.CurrentXP = 0;
            myPlayer.Level = 1;

            myPlayer.AddXP(100);

            Assert.IsTrue(myPlayer.Level == 2, "LevelUp has errors");
        }

        [TestMethod]
        public void Player_TestAddItems()
        {
            var myPlayer = new Player();
            Item tempItem = new Item { Name = "Test" };

            myPlayer.GetItem(tempItem);

            Assert.IsTrue(myPlayer.CurrentItems.Count > 0, "GetItems has errors");
        }
    }
}
