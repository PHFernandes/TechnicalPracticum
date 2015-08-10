using TechnicalPracticum.Model;
using System.Collections.Generic;

namespace TechnicalPracticum
{
    public class Restaurant
    {
        public List<TimeOfDay> timeOfDayList = new List<TimeOfDay> {
            new TimeOfDay(1, "Morning"),
            new TimeOfDay(2, "Night")
        };

        public List<DishType> dishTypeList = new List<DishType> {
            new DishType(1, "Entrée"),
            new DishType(2, "Side"),
            new DishType(3, "Drink"),
            new DishType(4, "Dessert")
        };

        public List<Food> foodList = new List<Food> {
            new Food(1, "Eggs"),
            new Food(2, "Steak"),
            new Food(3, "Toast"),
            new Food(4, "Potato"),
            new Food(5, "Coffee"),
            new Food(6, "Wine"),
            new Food(7, "Cake")
        };

        public List<TimeOfDayMultipleFood> multipleFoodList = new List<TimeOfDayMultipleFood> {
            new TimeOfDayMultipleFood(1, new List<int> { 5 }),
            new TimeOfDayMultipleFood(2, new List<int> { 4 })
        };

        public List<Dish> dishList = new List<Dish> {
            // Dish(int dishID, int foodID, int dishTypeID, int timeOfDayID)
            new Dish(1, 1, 1, 1),
            new Dish(2, 2, 1, 2),
            new Dish(3, 3, 2, 1),
            new Dish(4, 4, 2, 2),
            new Dish(5, 5, 3, 1),
            new Dish(6, 6, 3, 2),
            new Dish(7, 7, 4, 2)
        };

        public TimeOfDay FindTimeOfDay(string name)
        {
            foreach (var timeOfDay in timeOfDayList)
                if (timeOfDay.Name.Trim().ToLower() == name.Trim().ToLower())
                    return timeOfDay;

            return null;
        }

        public Food FindFood(int foodID)
        {
            foreach (var food in foodList)
                if (food.FoodID == foodID)
                    return food;

            return null;
        }

        public Dish FindDish(int timeOfDayID, int dishTypeID)
        {
            foreach (var dish in dishList)
                if (dish.TimeOfDayID == timeOfDayID && dish.DishTypeID == dishTypeID)
                    return dish;

            return null;
        }
    }
}