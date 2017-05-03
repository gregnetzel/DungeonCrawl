using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DungeonCrawl.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class BattleTest
    {
        [TestMethod]
        public void Battle_TestBattleOrderSort() // Need to only test 1 version of sort because everything is the same
        {
            var p1 = new Player { Spd = 5 };
            var p2 = new Player { Spd = 4 };
            var p3 = new Player { Spd = 7 };
            var p4 = new Player { Spd = 1 };
            Player[] players = {p1, p2, p3, p4};
            var b = new Battle(players);
            var ao = b.attackOrder;
            //ao[i].CompareTo(ao[j]) CompareTo returns 0 if equal, <0 if ao[i]<ao[j], and >0 if ao[i]>ao[j] 
            Assert.IsTrue(ao[0].CompareTo(ao[1]) >= 0 && ao[1].CompareTo(ao[2]) >= 0 && ao[2].CompareTo(ao[3]) >= 0 && ao[3].CompareTo(ao[4]) >= 0);
        }

        [TestMethod]
        public void Battle_TestIsOverFalse()
        {
            var p1 = new Player { Spd = 5, HP = 1 };
            var p2 = new Player { Spd = 4, HP = 1 };
            var p3 = new Player { Spd = 7, HP = 1 };
            var p4 = new Player { Spd = 1, HP = 1 };
            Player[] players = { p1, p2, p3, p4 };
            var b = new Battle(players);
            b.monsters[0].HP = 1;
            Assert.IsFalse(b.IsOver());
        }

        [TestMethod]
        public void Battle_TestIsOverTrue()
        {
            var p1 = new Player { Spd = 5, HP = 0 };
            var p2 = new Player { Spd = 4, HP = 0 };
            var p3 = new Player { Spd = 7, HP = 0 };
            var p4 = new Player { Spd = 1, HP = 0 };
            Player[] players = { p1, p2, p3, p4 };
            var b = new Battle(players);
            Assert.IsTrue(b.IsOver());
        }
        [TestMethod]
        public void TestFight()
        {
            var p1 = new Player { Spd = 5, HP = 0 };
            var p2 = new Player { Spd = 4, HP = 0 };
            var p3 = new Player { Spd = 7, HP = 0 };
            var p4 = new Player { Spd = 1, HP = 0 };
            Player[] players = { p1, p2, p3, p4 };
            var b = new Battle(players);

            var initHealth = b.monsters[0].HP;
            b.Fight(b.players[0], b.monsters[0]);

            Assert.IsTrue(b.monsters[0].HP < initHealth);
        }
    }
}
