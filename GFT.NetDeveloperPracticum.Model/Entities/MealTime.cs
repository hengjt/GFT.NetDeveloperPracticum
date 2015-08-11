using System;
using GFT.NetDeveloperPracticum.Model.Entities.BussinessExceptions;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealTime
    {
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

        private static bool IsNight(string text)
        {
            return text.IndexOf(EnumDishesTime.Night.ToString(), 
                StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private static bool IsMorning(string text)
        {
            return text.IndexOf(EnumDishesTime.Morning.ToString(), 
                StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
