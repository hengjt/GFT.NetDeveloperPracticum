using System;
using System.Collections.Generic;
using System.Linq;
using GFT.NetDeveloperPracticum.Model.Entities.DomainServices;
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

        #region MealFactory Methods
        /// <summary>
        /// Factory Method to create the list
        /// </summary>
        /// <returns></returns>
        public MealPlan Create()
        {
            return new MealPlan
                   {
                       Menu = FillMenuList(_mealType),
                       TimeOfday = _mealType.ToString()
                   };
        }

        /// <summary>
        /// Method created to fill the List of Dishes
        /// </summary>
        /// <param name="mealTime"></param>
        /// <returns></returns>
        private ICollection<string> FillMenuList(EnumDishesTime mealTime)
        {
            ICollection<string> menuList = new List<string>();

            var aggrouped = GetAggroupedSummary();

            foreach (var item in aggrouped)
            {
                object dishName;

                if ((MealServices.IsMorningAndDishTypeIsCoffee(mealTime, item.Value)
                        || (MealServices.IsNightAndDishTypeIsPotato(mealTime, item.Value)))
                        && item.Amount > 1)
                {
                    dishName = GetDishName(mealTime, item.Value);

                    var concDishAmount = dishName + "(" + item.Amount + "X)";
                    menuList.Add(concDishAmount);
                }
                else if (MealServices.IsNotCorrectDish(item.Value))
                {
                    dishName = GetDishName(mealTime, item.Value);
                    menuList.Add(dishName.ToString());
                }
            }

            return menuList;
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
            return (EnumDishesTime)dishTime == EnumDishesTime.Morning
                ? (Enum)(EnumMealMorning)value
                : (EnumMealNight)value;
        }
        #endregion
    }
}
