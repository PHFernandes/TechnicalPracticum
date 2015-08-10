using System;

namespace TechnicalPracticum.Model
{
    public class Food
    {
        public Food(int foodID, string name)
        {
            FoodID = foodID;
            Name = name;
        }

        public int FoodID { get; set; }

        public string Name { get; set; }
    }
}