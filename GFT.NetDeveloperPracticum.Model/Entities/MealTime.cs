using System;
using GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealTime
    {
        /// <summary>
        /// Compair and delegate the Input dish
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static EnumDishesTime GetTime(string text)
        {
            if (IsMorning(text))
            {
                return EnumDishesTime.Morning;
            }else if (IsNight(text))
            {
                return EnumDishesTime.Night;
            }
            else
            {
                throw new ExceptionBySyntax("Error: Incorrect time input.");
            }            
        }

        #region MealTime Methods

        /// <summary>
        /// Verify if the text it's night
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool IsNight(string text)
        {
            return text.IndexOf(EnumDishesTime.Night.ToString(),
                StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// Verify if the text it's day
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool IsMorning(string text)
        {
            return text.IndexOf(EnumDishesTime.Morning.ToString(),
                StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        #endregion

    }
}
