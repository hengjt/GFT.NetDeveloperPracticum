using System;
using System.Collections.Generic;

namespace GFT.NetDeveloperPracticum.Model.Entities
{
    public class MealPlan
    {
        /// <summary>
        /// Class Properties
        /// </summary>

        #region Properties
        public List<string> Menu { get; set; }

        public String TimeOfday { get; set; }

        #endregion

    }
}