using System;

namespace TechnicalPracticum.Model
{
    public class TimeOfDay
    {
        public TimeOfDay(int timeOfDayID, string name)
        {
            TimeOfDayID = timeOfDayID;
            Name = name;
        }

        public int TimeOfDayID { get; set; }

        public string Name { get; set; }
    }
}