using System;
using System.Collections.Generic;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealPlan
    {
       #region MealPlan Properties
        public List<string> Menu { get; set; }

        public String TimeOfday { get; set; }

        #endregion

    }
}