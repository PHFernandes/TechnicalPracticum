using System;

namespace TechnicalPracticum.Model
{
    public class Dish
    {
        public Dish(int dishID, int foodID, DishType dishType, TimeOfDay timeOfDay)
        {
            DishID = dishID;
            FoodID = foodID;
            DishType = dishType;
            TimeOfDay = timeOfDay;
        }

        public int DishID { get; set; }

        public int FoodID { get; set; }

        public DishType DishType { get; set; }

        public TimeOfDay TimeOfDay { get; set; }
    }
}