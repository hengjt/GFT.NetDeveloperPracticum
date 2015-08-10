using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealFactory
    {
        /// <summary>
        /// Privates Properties
        /// </summary>

        #region Properties
        private readonly dynamic _mealType;

        private readonly List<int> _listMealTypes;

        #endregion

        /// <summary>
        /// Factory Constructor
        /// </summary>
        /// <param name="mealType"></param>
        /// <param name="mealtypes"></param>
        public MealFactory(dynamic mealType, List<int> mealtypes)
        {
            _mealType = mealType;
            _listMealTypes = mealtypes;
        }

        /// <summary>
        /// Factory Method to create the list
        /// </summary>
        /// <returns></returns>
        public MealPlan Create()
        {
            return new MealPlan
                   {
                       Menu = FillMenuList(_mealType)
                   };
        }

        /// <summary>
        /// Method created to fill the List of Dishes
        /// </summary>
        /// <param name="mealTime"></param>
        /// <returns></returns>
        private ICollection<string> FillMenuList(dynamic mealTime)
        {
            ICollection<string> menu = new List<string>();

            var aggrouped = GetAggroupedSummary();
            int count = 0;

            foreach (var item in aggrouped)
            {
                object dishName;

                if (item.Amount > 1 && item.Value < 5)
                {
                    dishName = GetDishName(mealTime, item.Value);

                    var concDishAmount = dishName + "(" + item.Amount + "X)";
                    menu.Add(concDishAmount);
                }
                else if (item.Value < 5)
                {
                    dishName = GetDishName(mealTime, item.Value);
                    menu.Add(dishName.ToString());
                }
            }

            return menu;
        }

        /// <summary>
        /// Method created to aggroup the Dish types
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Summary> GetAggroupedSummary()
        {
            return _listMealTypes.GroupBy(m => m)
                .Select(m => new Summary
                             {
                                 Value = m.Key,
                                 Amount = m.Count()
                             }).OrderBy(o => o.Value);
        }

        /// <summary>
        /// Method created to return the 
        /// </summary>
        /// <param name="dishTime"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Enum GetDishName(dynamic dishTime, int value)
        {
            return dishTime.GetType() == typeof(MealMorning)
                ? (Enum)(MealMorning)value
                : (MealNight)value;
        }
    }
}
