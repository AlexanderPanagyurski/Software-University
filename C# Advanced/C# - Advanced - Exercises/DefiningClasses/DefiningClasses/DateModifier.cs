using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class DateModifier
    {
        private int Difference;
        private DateTime FirstDate;
        private DateTime SecondDate;

        public DateModifier(string firstDate,string secondDate)
        {
             FirstDate = DateTime.Parse(firstDate);
             SecondDate = DateTime.Parse(secondDate);
        }
        public void DateDiffence()
        {
            
            Console.WriteLine(Math.Abs(FirstDate.Subtract(SecondDate).TotalDays));
        }
    }
}
