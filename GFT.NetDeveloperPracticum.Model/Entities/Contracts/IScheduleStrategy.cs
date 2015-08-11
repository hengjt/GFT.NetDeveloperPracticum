using System.Collections.Generic;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities.Contracts
{
    public interface IScheduleStrategy
    {
        MealPlan Meal(EnumDishesTime time, List<int> numbersOfMeal);
    }
}
