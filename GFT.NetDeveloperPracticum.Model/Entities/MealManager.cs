using System;
using System.Collections.Generic;
using System.Linq;
using GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions;
using GFT.NetDeveloperPracticum.Model.Entities.Contracts;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealManager
    {
        /// <summary>
        /// Class Properties
        /// </summary>
        #region Properties

        public EnumMealMorning EnumMealMorning { get; set; }

        public EnumMealNight EnumMealNight { get; set; }

        private List<int> _numbers;

        private string _scheduleMeal;

        private EnumDishesTime _dishesTime; 
        #endregion

        private IScheduleStrategy _schedule;

        public MealManager(IScheduleStrategy schedule, EnumDishesTime dishesTime)
        {
            _schedule = schedule;
            _dishesTime = dishesTime;
        }

        /// <summary>
        /// Method to check and call the factory class
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public MealPlan Manager(string inputValue)
        {
            MealPlan mealPlan = null;

            try
            {
                ConvertInputValues(inputValue);
            }
            catch (Exception)
            {
                throw new ExceptionBySyntax("Error: Incorrect syntax.");
            }            

            //if (_scheduleMeal.Equals("morning", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    mealPlan = new MealFactory(EnumMealMorning, _numbers).Create();
            //    mealPlan.TimeOfday = EnumDishesTime.Morning.ToString();
            //}
            //else if (_scheduleMeal.Equals("night", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    mealPlan = new MealFactory(EnumMealNight, _numbers).Create();
            //    mealPlan.TimeOfday = EnumDishesTime.Night.ToString();
            //}
            //else
            //{
            //    throw new ExceptionGeneric("Error: The inserted text is incorrect.");
            //}

            return _schedule.Meal(_dishesTime, _numbers);
        }

        /// <summary>
        /// Method created for split the input value. This method will be insert the values in a List
        /// </summary>
        /// <param name="inputValue"></param>
        private void ConvertInputValues(string inputValue)
        {
            var values = inputValue.Split(',').ToList();
            if (values.Count > 1)
            {
                _scheduleMeal = ConvertStringAndFillScheduleMeal(values[0]);

                values.RemoveAt(0);

                _numbers = new List<int>();

                values.ForEach(p => _numbers.Add(int.Parse(p)));
            }
            else
            {
                throw new ExceptionGeneric("Error: The inserted text is incorrect.");
            }
        }

        private static string ConvertStringAndFillScheduleMeal(string t)
        {
            return t.Equals("morning", StringComparison.CurrentCultureIgnoreCase)
                ? EnumDishesTime.Morning.ToString()
                : EnumDishesTime.Night.ToString();
        }
    }
}
