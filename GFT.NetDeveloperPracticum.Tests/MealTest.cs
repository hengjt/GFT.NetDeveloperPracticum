using System.Linq;
using GFT.NetDeveloperPracticum.Model;
using GFT.NetDeveloperPracticum.Model.Entities;
using GFT.NetDeveloperPracticum.Model.Entities.Contracts;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;
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
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;
            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedMorningCorrectOrder()
        {
            Plan = "morning,2,1,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedErrorMorningDessert()
        {
            Plan = "morning,1,2,3,4";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
            Assert.IsTrue("Error" == result[3]);
        }

        [TestMethod]
        public void ShouldBeReturnedRepeatMorning()
        {
            Plan = "morning,1,2,3,3,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee(3X)" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedTheNightDishList()
        {
            Plan = "night,1,2,3,4";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
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
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsFalse("Potato" == result[0]);
            Assert.IsTrue("Potato" == result[1]);
            Assert.IsFalse("Cake" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedRepeatNight()
        {
            Plan = "night,1,2,2,4";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsTrue("Potato(2X)" == result[1]);
            Assert.IsTrue("Cake" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureDessertMorning()
        {
            Plan = "morning,4";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Error" == result[0]);
        }

        [TestMethod]
        public void ShouldBeReturnedMorningFailureOrder()
        {
            Plan = "morning,2,1,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsFalse("Toast" == result[0]);
            Assert.IsFalse("Eggs" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureRepeatNightDishesError()
        {
            Plan = "night,1,2,2,4";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsFalse("Potato" == result[1]);
            Assert.IsTrue("Cake" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureRepeatMorning()
        {
            Plan = "morning,1,2,3,3,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsFalse("Coffee" == result[2]);
        }

        [TestMethod]
        public void ShouldBeReturnedFailureTheMorningDishList()
        {
            Plan = "morning,1,2,3,3,3";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsFalse("Coffee" == result.FirstOrDefault());
        }

        #endregion

        /// <summary>
        /// Method to get the MealPlan
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        private static MealPlan MealPlan(IScheduleStrategy schedule, EnumDishesTime dishesTime, string plan)
        {
            var manager = new MealManager(schedule, dishesTime).Manager(plan);
            return manager;
        }

    }
}
