using System.Collections.Generic;
using TechnicalPracticum.Model;

namespace TechnicalPracticum
{
    public class Restaurant
    {
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
            new TimeOfDayMultipleFood(TimeOfDay.Morning, new List<int> { 5 }),
            new TimeOfDayMultipleFood(TimeOfDay.Night, new List<int> { 4 })
        };

        public List<Dish> dishList = new List<Dish> {
            // Dish(int dishID, int foodID, DishType dishType, TimeOfDay timeOfDay)
            new Dish(1, 1, DishType.Entrée, TimeOfDay.Morning),
            new Dish(2, 2, DishType.Entrée, TimeOfDay.Night),
            new Dish(3, 3, DishType.Side, TimeOfDay.Morning),
            new Dish(4, 4, DishType.Side, TimeOfDay.Night),
            new Dish(5, 5, DishType.Drink, TimeOfDay.Morning),
            new Dish(6, 6, DishType.Drink, TimeOfDay.Night),
            new Dish(7, 7, DishType.Dessert, TimeOfDay.Night)
        };

        public Food FindFood(int foodID)
        {
            foreach (var food in foodList)
                if (food.FoodID == foodID)
                    return food;

            return null;
        }

        public Dish FindDish(TimeOfDay timeOfDay, DishType dishType)
        {
            foreach (var dish in dishList)
                if (dish.TimeOfDay == timeOfDay && dish.DishType == dishType)
                    return dish;

            return null;
        }
    }
}