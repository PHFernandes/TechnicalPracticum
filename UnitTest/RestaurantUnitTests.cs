using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalPracticum;

namespace UnitTest
{
    [TestClass]
    public class RestaurantUnitTests
    {
        [TestMethod]
        public void CheckingCaseSensitiveCondition()
        {
            Assert.AreEqual(Program.EnterOrder("MorNIng,1"), "Eggs");
            Assert.AreEqual(Program.EnterOrder("NigHT,1"), "Steak");

            Assert.AreEqual(Program.EnterOrder("morning,1"), "Eggs");
            Assert.AreEqual(Program.EnterOrder("night,1"), "Steak");
        }

        [TestMethod]
        public void CheckingAtLeastOneSelectionIsPassed()
        {
            Assert.AreEqual(Program.EnterOrder("morning,"), "");
            Assert.AreEqual(Program.EnterOrder("night,"), "");
        }

        [TestMethod]
        public void CheckingReturnOrder()
        {
            Assert.AreNotEqual(Program.EnterOrder("morning,2,1"), "Toast,Eggs");
            Assert.AreEqual(Program.EnterOrder("morning,3,2,1"), "Eggs,Toast,Coffee");
        }

        [TestMethod]
        public void CheckingMultipleOrders()
        {
            Assert.AreEqual(Program.EnterOrder("morning,3,3,3,3,2,1"), "Eggs,Toast,Coffee(x4)");
            Assert.AreEqual(Program.EnterOrder("night,1,2,2,4"), "Steak,Potato(x2),Cake");

            Assert.AreEqual(Program.EnterOrder("morning,1,1"), "");
            Assert.AreEqual(Program.EnterOrder("night,1,1"), "");
        }
    }
}
