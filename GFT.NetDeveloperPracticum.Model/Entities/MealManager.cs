using System;
using System.Collections.Generic;
using System.Linq;
using GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealManager
    {
        /// <summary>
        /// Class Properties
        /// </summary>
        #region Properties

        public MealMorning MealMorning { get; set; }

        public MealNight MealNight { get; set; }

        private List<int> _numbers;

        private string _scheduleMeal;

        #endregion
        
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

            if (_scheduleMeal.Equals("morning", StringComparison.CurrentCultureIgnoreCase))
            {
                mealPlan = new MealFactory(MealMorning, _numbers).Create();
                mealPlan.TimeOfday = "morning";
            }
            else if (_scheduleMeal.Equals("night", StringComparison.CurrentCultureIgnoreCase))
            {
                mealPlan = new MealFactory(MealNight, _numbers).Create();
                mealPlan.TimeOfday = "night";
            }
            else
            {
                throw new ExceptionGeneric("Error: The inserted text is incorrect.");
            }

            return mealPlan;
        }

        /// <summary>
        /// Method created for split the input value. This method will be insert the values in a List
        /// </summary>
        /// <param name="inputValue"></param>
        private void ConvertInputValues(string inputValue)
        {
            var values = inputValue.Split(',').ToList();

            _scheduleMeal = values[0];

            values.RemoveAt(0);

            _numbers = new List<int>();

            values.ForEach(p => _numbers.Add(int.Parse(p)));
        }
    }
}
