using System.Linq;
using GFT.NetDeveloperPracticum.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GFT.NetDeveloperPracticum.Tests
{

    [TestClass]
    public class MealTest
    {
        public string Plan { get; set; }

        #region Test Methods

        [TestMethod]
        public void ShouldBeReturnedTheMorningDishList()
        {
            Plan = "morning,1,2,3";
            var manager = MealPlan(Plan);
            var result = manager.Menu;
            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedMorningCorrectOrder()
        {
            var manager = new MealManager().Manager("morning,2,1,3");
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedErrorMorningDessert()
        {
            var manager = new MealManager().Manager("morning,1,2,3,4");
            var result = manager.Menu;
            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
            Assert.IsTrue("Error" == result[3]);
        }

        [TestMethod]
        public void ShouldBeReturnedRepeatMorning()
        {
            var manager = new MealManager().Manager("morning,1,2,3,3,3");
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee(3X)" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedTheNightDishList()
        {
            Plan = "night,1,2,3,4";
            var manager = MealPlan(Plan);
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsTrue("Potato" == result[1]);
            Assert.IsTrue("Wine" == result[2]);
            Assert.IsTrue("Cake" == result[3]);
        }

        [TestMethod]
        public void ShouldBeReturnedTheNightDishListMoreTime()
        {
            Plan = "night,1,2,3,3";
            var manager = MealPlan(Plan);
            var result = manager.Menu;

            Assert.IsFalse("Potato" == result[0]);
            Assert.IsTrue("Potato" == result[1]);
            Assert.IsFalse("Cake" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedRepeatNight()
        {
            var manager = new MealManager().Manager("night,1,2,2,4");
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsTrue("Potato(2X)" == result[1]);
            Assert.IsTrue("Cake" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureDessertMorning()
        {
            var manager = new MealManager().Manager("morning,4");
            var result = manager.Menu;

            Assert.IsTrue("Error" == result[0]);
        }

        [TestMethod]
        public void ShouldBeReturnedMorningFailureOrder()
        {
            var manager = new MealManager().Manager("morning,2,1,3");
            var result = manager.Menu;

            Assert.IsFalse("Toast" == result[0]);
            Assert.IsFalse("Eggs" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureRepeatNightDishesError()
        {
            var manager = new MealManager().Manager("night,1,2,2,4");
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsFalse("Potato" == result[1]);
            Assert.IsTrue("Cake" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureRepeatMorning()
        {
            var manager = new MealManager().Manager("morning,1,2,3,3,3");
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsFalse("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureTheMorningDishList()
        {
            Plan = "morning,1,2,3";
            var manager = MealPlan(Plan);
            var result = manager.Menu;
            Assert.IsFalse("Coffee" == result.FirstOrDefault());
        }

        #endregion

        /// <summary>
        /// Method to get the MealPlan
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        private static MealPlan MealPlan(string plan)
        {
            var manager = new MealManager().Manager(plan);
            return manager;
        }

    }
}
