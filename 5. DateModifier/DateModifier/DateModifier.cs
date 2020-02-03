using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(string dateOne, string dateTwo)
        {
            this.DateOne = dateOne;
            this.DateTwo = dateTwo;
        }
        public string DateOne { get; set; }
        public string DateTwo { get; set; }


        public string CalculateDifference()
        {
            int difference = 0;

            var dateOne = DateTime.Parse(this.DateOne);
            var dateTwo = DateTime.Parse(this.DateTwo);

            return Math.Abs((dateOne - dateTwo).TotalDays).ToString();

        }
    }
}
