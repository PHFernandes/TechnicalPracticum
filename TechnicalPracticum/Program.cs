using TechnicalPracticum.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var tod = rest.FindTimeOfDay(values[0]);
            if (tod == null)
                Console.WriteLine("Invalid dish type.");

            if (values.Length == 1)
                Console.WriteLine("You must enter a comma delimited list of dish types with at least one selection.");

            var listDishes = GetIDs(values);

            var output = string.Empty;
            listDishes = listDishes.OrderBy(x => x).ToList();
            var last = -1;
            foreach (var dishID in listDishes)
            {
                if (dishID == last)
                    continue;
                last = dishID;

                Dish dish = null;
                int quantity = listDishes.Count(x => x == dishID);
                if (quantity > 1)
                {
                    dish = rest.FindDish(tod.TimeOfDayID, dishID);
                    if (rest.multipleFoodList.Where(x => x.TimeOfDayID == tod.TimeOfDayID && x.FoodIDList.Contains(dish.FoodID)).Count() == 0)
                    {
                        Console.WriteLine("Invalid quantity.");
                        break;
                    }
                }

                dish = rest.FindDish(tod.TimeOfDayID, dishID);
                if (dish != null)
                    if (quantity > 1)
                        output += rest.FindFood(dish.FoodID).Name + "(x" + quantity + ")";
                    else
                        output += rest.FindFood(dish.FoodID).Name;
                else
                    output += "error";

                output += ",";
            }

            var lastComma = output.LastIndexOf(',');
            var result = lastComma == -1 ? output : output.Remove(lastComma);

            Console.WriteLine(result);
            return result;
        }

        public static List<int> GetIDs(string[] values)
        {
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