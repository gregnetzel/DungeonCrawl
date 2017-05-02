using NUnit.Framework;
using System;
namespace MobileApplication.Test
{
    [TestFixture()]
    public class PlayerTest
    {
		[Test]
		public void TestIsDead()
		{
            var myPlayer = new Player();

            myPlayer.HP = 0;

            Assert.IsTrue(myPlayer.IsDead(), "IsDead has errors");
		}

		[Test]
		public void TestIsAlive()
		{
            var myPlayer = new Player();

            myPlayer.HP = 2;

            Assert.IsFalse(myPlayer.IsDead(), "IsDead has errors");
		}

		[Test]
		public void TestAddXP()
		{
            var myPlayer = new Player();

            myPlayer.CurrentXP = 0;
            myPlayer.AddXP(50);

            Assert.IsTrue(myPlayer.CurrentXP == 50, "AddXP has errors");
		}

		[Test]
		public void TestLevelUp()
		{
            var myPlayer = new Player();
            myPlayer.CurrentXP = 0;
            myPlayer.Level = 1;

            myPlayer.AddXP(100);

            Assert.IsTrue(myPlayer.Level == 2, "LevelUp has errors");
		}

		[Test]
		public void TestAddItemsAdded()
		{
            var myPlayer = new Player { Str = 2 };
            Items tempItem = new Items { Name = "Test", StrValue = 2, InvLoc = 0};

            myPlayer.GetItem(tempItem);

            Assert.IsTrue(myPlayer.CurrentItems.Count > 0 && myPlayer.Str == 4, "GetItems has errors");
		}

		[Test]
		public void TestAddItemsRejected()
		{
            var myPlayer = new Player { Str = 2 };
            Items tempItem = new Items { Name = "Test", StrValue = 3, InvLoc = 0};
            Items tempItem2 = new Items { Name = "Test1", StrValue = 2, InvLoc = 0 };   

			myPlayer.GetItem(tempItem);
            myPlayer.GetItem(tempItem2);

            Assert.IsTrue(myPlayer.CurrentItems[0].Name == "Test" && myPlayer.Str == 5, "GetItems has errors");
		}

		[Test]
		public void TestAddItemsReplaced()
		{
			var myPlayer = new Player { Str = 2 };
			Items tempItem = new Items { Name = "Test", StrValue = 2, InvLoc = 0 };
			Items tempItem2 = new Items { Name = "Test1", StrValue = 3, InvLoc = 0 };

			myPlayer.GetItem(tempItem);
			myPlayer.GetItem(tempItem2);

			Assert.IsTrue(myPlayer.CurrentItems[0].Name == "Test1" && myPlayer.Str == 5, "GetItems has errors");
		}
    }
}
