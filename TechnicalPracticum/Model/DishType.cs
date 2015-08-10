using System;

namespace TechnicalPracticum.Model
{
    public class DishType
    {
        public DishType(int dishTypeID, string name)
        {
            DishTypeID = dishTypeID;
            Name = name;
        }

        public int DishTypeID { get; set; }

        public string Name { get; set; }
    }
}