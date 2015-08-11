using System.Collections.Generic;
using GFT.NetDeveloperPracticum.Model.Entities.Enums;

namespace GFT.NetDeveloperPracticum.Model.Entities.Contracts
{
    /// <summary>
    /// Contract
    /// </summary>
    public interface IScheduleStrategy
    {
        MealPlan Meal(EnumDishesTime time, List<int> numbersOfMeal);
    }
}
