using NUnit.Framework;
using System;
using System.Collections.ObjectModel;

namespace MobileApplication.Test
{
    [TestFixture()]
    public class BattleTest
    {
        [Test]
        public void TestSort() // Need to only test 1 version of sort because everything is the same
        {
            var b = new Battle();
            var p1 = new Player { Spd = 5 };
            var p2 = new Player { Spd = 4 };
            var p3 = new Player { Spd = 7 };
            var p4 = new Player { Spd = 1 };
            b.PlayerParty.Add(p1);
            b.PlayerParty.Add(p2);
            b.PlayerParty.Add(p3);
            b.PlayerParty.Add(p4);

            b.sortArrayP();

            Assert.IsTrue(b.PlayerParty[0].Spd > b.PlayerParty[3].Spd);
        }

        [Test]
        public void TestIsOverFalse()
        {
            var b = new Battle();
            var p1 = new Player { Name = "PTest"};
            var m1 = new Monsters { Name = "MTest" };
            b.PlayerParty.Add(p1);
            b.MonsterParty.Add(m1);

            Assert.IsFalse(b.IsOver());
        }

		[Test]
		public void TestIsOverTrue()
		{
			var b = new Battle();

			Assert.IsTrue(b.IsOver());
		}

        [Test]
        public void TestFight()
        {
            var b = new Battle();
            var p1 = new Player { Level = 2, HP = 10, Str = 5, Dex = 9 };
            var m1 = new Monsters { Level = 2, HP = 10, Dex = 7 };
            b.PlayerParty.Add(p1);
            b.MonsterParty.Add(m1);

            b.Fight(b.PlayerParty[0], b.MonsterParty[0]);

            Assert.IsTrue(b.MonsterParty[0].HP == 3);
        }
    }
}
