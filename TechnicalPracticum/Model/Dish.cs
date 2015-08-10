using System;

namespace TechnicalPracticum.Model
{
    public class Dish
    {
        public Dish(int dishID, int foodID, int dishTypeID, int timeOfDayID)
        {
            DishID = dishID;
            FoodID = foodID;
            DishTypeID = dishTypeID;
            TimeOfDayID = timeOfDayID;
        }

        public int DishID { get; set; }

        public int FoodID { get; set; }

        public int DishTypeID { get; set; }

        public int TimeOfDayID { get; set; }
    }
}