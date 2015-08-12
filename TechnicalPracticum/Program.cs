using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalPracticum.Model;

namespace TechnicalPracticum
{
    public class Program
    {
        static Restaurant rest = new Restaurant();

        static void Main(string[] args)
        {
            while (true)
            {
                EnterOrder(null);
            };
        }

        public static string EnterOrder(string order)
        {
            var line = string.IsNullOrEmpty(order) ? Console.ReadLine().Trim() : order;
            var values = line.Split(',');

            // Getting the Time of Day and all the Dishes
            var tod = GetTimeOfDay(values[0]);
            var listDishes = GetIDs(values);

            if (tod == null || listDishes == null)
                return string.Empty;

            // Getting the list of foods
            var output = GetOrderList(listDishes, tod.Value);

            // Removing teh last comma
            var lastComma = output.LastIndexOf(',');
            var result = lastComma == -1 ? output : output.Remove(lastComma);

            Console.WriteLine(result);
            return result;
        }

        public static string GetOrderList(List<int> listDishes, TimeOfDay tod)
        {
            var output = string.Empty;
            listDishes = listDishes.OrderBy(x => x).ToList();
            var last = -1;

            foreach (var dishType in listDishes)
            {
                if (dishType == last)
                    continue;
                last = dishType;

                Dish dish = rest.FindDish(tod, (DishType)dishType);
                if (dish == null)
                {
                    output += "error,";
                    continue;
                }

                var quantity = GetValidQuantity(listDishes, dish);
                if (quantity == -1)
                {
                    Console.WriteLine("Invalid quantity.");
                    break;
                }

                // Concatenating the output and adding the quantity if necessary
                output += quantity > 1 ? rest.FindFood(dish.FoodID).Name + "(x" + quantity + ")," : rest.FindFood(dish.FoodID).Name + ",";
            }

            return output;
        }

        public static int GetValidQuantity(List<int> listDishes, Dish dish)
        {
            // Getting the Dish quantity and checking if the inserted Food is multiple for the Time of Day
            int quantity = listDishes.Count(x => x == (int)dish.DishType);
            return quantity == 1 || IsMultipleFood(dish.TimeOfDay, dish) ? quantity : -1;
        }

        public static TimeOfDay? GetTimeOfDay(string timeOfDay)
        {
            if (timeOfDay.Trim().ToUpper().Equals("MORNING"))
                return TimeOfDay.Morning;
            else if (timeOfDay.Trim().ToUpper().Equals("NIGHT"))
                return TimeOfDay.Night;

            Console.WriteLine("Invalid dish type.");
            return null;
        }

        public static bool IsMultipleFood(TimeOfDay tod, Dish dish)
        {
            return rest.multipleFoodList.Where(x => x.TimeOfDay == tod && x.FoodIDList.Contains(dish.FoodID)).Count() > 0;
        }

        public static List<int> GetIDs(string[] values)
        {
            if (values.Length == 1 || string.IsNullOrEmpty(values[1]))
            {
                Console.WriteLine("You must enter a comma delimited list of dish types with at least one selection.");
                return null;
            }

            var listDishes = new List<int>();
            for (int i = 1; i < values.Length; i++)
                try
                {
                    listDishes.Add(Convert.ToInt32(values[i]));
                }
                catch (Exception)
                {
                    listDishes.Add(-1);
                }

            return listDishes;
        }
    }
}