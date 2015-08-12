using System.Collections.Generic;

namespace TechnicalPracticum.Model
{
    public class TimeOfDayMultipleFood
    {
        public TimeOfDayMultipleFood(TimeOfDay timeOfDay, List<int> foodIDList)
        {
            TimeOfDay = timeOfDay;
            FoodIDList = foodIDList;
        }

        public TimeOfDay TimeOfDay { get; set; }

        public List<int> FoodIDList { get; set; }
    }
}