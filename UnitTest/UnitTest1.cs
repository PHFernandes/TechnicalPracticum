using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalPracticum;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TimeOfDay()
        {
            Assert.AreEqual(Program.EnterOrder("Morning,1"), "Eggs");
            Assert.AreEqual(Program.EnterOrder("Night,1"), "Steak");

            Assert.AreEqual(Program.EnterOrder("morning,1"), "Eggs");
            Assert.AreEqual(Program.EnterOrder("night,1"), "Steak");
        }

        [TestMethod]
        public void AtLeastOnSelection()
        {
            Assert.AreEqual(Program.EnterOrder("morning,"), "Eggs");
            Assert.AreEqual(Program.EnterOrder("night,"), "Steak");
        }

        [TestMethod]
        public void ReturnOrder()
        {
            Assert.AreEqual(Program.EnterOrder("morning,3,2,1"), "Eggs,Toast,Coffee");
        }

        [TestMethod]
        public void MultipleOrders()
        {
            Assert.AreEqual(Program.EnterOrder("morning,3,3,3,3,2,1"), "Eggs,Toast,Coffee(x4)");
            Assert.AreEqual(Program.EnterOrder("night,1,2,2,4"), "Steak,Potato(x2),Cake");

            Assert.AreEqual(Program.EnterOrder("morning,1,1"), "");
            Assert.AreEqual(Program.EnterOrder("night,1,1"), "");
        }
    }
}
