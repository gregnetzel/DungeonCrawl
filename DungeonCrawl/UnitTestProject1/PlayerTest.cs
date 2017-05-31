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
            myPlayer.AddXP(20);

            Assert.IsTrue(myPlayer.CurrentXP == 20, "AddXP has errors");
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
            myPlayer.HP = 1;
            tempItem.HPValue = 2;
            myPlayer.GetItem(tempItem);

            Assert.IsTrue(myPlayer.HP == 3, "GetItems has errors");
        }
        [TestMethod]
        public void TestAddItemsAdded()
        {
            var myPlayer = new Player { Str = 2 };
            Item tempItem = new Item { Name = "Test", StrValue = 2};

            myPlayer.GetItem(tempItem);

            Assert.IsTrue(myPlayer.Str == 4, "GetItems has errors");
        }

        [TestMethod]
        public void TestAddItemsRejected()
        {
            var myPlayer = new Player { Str = 2 };
            Item tempItem = new Item { Name = "Test", StrValue = 3 };
            Item tempItem2 = new Item { Name = "Test1", StrValue = 2 };

            myPlayer.GetItem(tempItem);
            myPlayer.GetItem(tempItem2);

            Assert.IsTrue(myPlayer.CurrentItems[0].Name == "Test", "GetItems has errors");
        }
    }
}
