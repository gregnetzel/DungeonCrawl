using NUnit.Framework;
using System;
namespace MobileApplication.Test
{
    [TestFixture()]
    public class ItemsTest
    {
        [Test]
        public void ItemConstructionTest()
        {
            Items testItem = new Items();
            testItem.Name = "TestItem";
            testItem.Type = "Dagger";
            testItem.Description = "This is a TestItem";
            testItem.StrValue = 5;
            testItem.DexValue = 0;
            testItem.SpdValue = 0;
            testItem.HPValue = 0;
            testItem.Image = "abc";
            Assert.IsTrue(testItem.Name == "TestItem" &&
                         testItem.Type == "Dagger" &&
                         testItem.Description == "This is a TestItem" &&
                          testItem.StrValue == 5 &&
                          testItem.DexValue == 0 &&
                          testItem.SpdValue == 0 &&
                          testItem.HPValue == 0 &&
                          testItem.Image == "abc"); 
        }
    }
}
