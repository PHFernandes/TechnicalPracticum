using System;
using System.Collections.Generic;

namespace TechnicalPracticum.Model
{
    public class TimeOfDayMultipleFood
    {
        public TimeOfDayMultipleFood(int timeOfDayID, List<int> foodIDList)
        {
            TimeOfDayID = timeOfDayID;
            FoodIDList = foodIDList;
        }

        public int TimeOfDayID { get; set; }

        public List<int> FoodIDList { get; set; }
    }
}