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
        public void Test1_When_Ask_Morning_And_The_Itens_Eggs_Toast_Coffee_Then_Show_Eggs_Toast_Coffee()
        {
            Plan = "morning,1,2,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;
            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void Test2_When_Ask_Morning_And_The_Itens_Toast_Eggs_Coffee_Then_Show_Eggs_Toast_Coffee()
        {
            Plan = "morning,2,1,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void Test3_When_Ask_Morning_And_The_Itens_Eggs_Toast_Coffee_Error_Then_Show_Eggs_Toast_Coffee_Error()
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
        public void Test4_When_Ask_Morning_And_The_Itens_Eggs_Toast_Coffee_Coffee_Coffee_Then_Show_Eggs_Toast_Coffee3X()
        {
            Plan = "morning,1,2,3,3,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee(3X)" == result[2]);
        }

        [TestMethod]
        public void Test5_When_Ask_Night_And_The_Itens_Steak_Potato_Wine_Cake_Then_Show_Steak_Potato_Wine_Cake()
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
        public void Test6_When_Ask_Night_And_The_Itens_Steak_Wine_Wine_Then_Show_Steak_Wine()
        {
            Plan = "night,1,3,3";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsTrue("Wine" == result[1]);
        }

        [TestMethod]
        public void Test7_When_Ask_Night_And_The_Itens_Steak_potato_potato_cake_Then_Show_Steak_Potato2X_Cake()
        {
            Plan = "night,1,2,2,4";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsTrue("Potato(2X)" == result[1]);
            Assert.IsTrue("Cake" == result[2]);
        }

        [TestMethod]
        public void Test8_When_Ask_Morning_And_The_Itens_4_Then_Show_Error()
        {
            Plan = "morning,4";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Error" == result[0]);
        }

        [TestMethod]
        public void Test9_When_Ask_Morning_And_The_Itens_Toast_Eggs_Coffee_Eggs_Toast_Coffee_Then_Show_Eggs_Toast_Coffee2X()
        {
            Plan = "morning,2,1,3,1,2,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee(2X)" == result[2]);
        }

        [TestMethod]
        public void Test10_When_Ask_Night_And_The_Itens_Steak_Potato_Potato_Cake_Cake_Then_Show_Steak_Potato2X_Cake()
        {
            Plan = "night,1,2,2,4,4";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Steak" == result[0]);
            Assert.IsTrue("Potato(2X)" == result[1]);
            Assert.IsTrue("Cake" == result[2]);
        }

        [TestMethod]
        public void Test11_When_Ask_Morning_And_The_Itens_Eggs_Toast_Toast_Toast_Coffee_Then_Show_Eggs_Toast_Coffee()
        {
            Plan = "morning,1,2,2,2,3";
            var manager = MealPlan(new MorningMeal(), EnumDishesTime.Morning, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Eggs" == result[0]);
            Assert.IsTrue("Toast" == result[1]);
            Assert.IsTrue("Coffee" == result[2]);
        }

        [TestMethod]
        public void Test12_When_Ask_Night_And_The_Itens_Coffee_Coffee_Coffee_Coffee_Coffee_Coffee_Coffee_Then_Show_Coffee7X()
        {
            Plan = "night,2,2,2,2,2,2,2";
            var manager = MealPlan(new NightMeal(), EnumDishesTime.Night, Plan);
            var result = manager.Menu;

            Assert.IsTrue("Potato(7X)" == result.FirstOrDefault());
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
