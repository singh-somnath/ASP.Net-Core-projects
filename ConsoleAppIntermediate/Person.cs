using System;

namespace ConsoleAppIntermediate
{
    public class Person
    {
        public string? Name { get; set; }
        public DateTime BirthDate { get; private set; }

        public Person(DateTime birthDate)
        {
            this.BirthDate = birthDate;
        }

        public int Age
        {
            get
            {
                var timespan = DateTime.Now - this.BirthDate;
                var years = timespan.Days / 365;
                return years;
            }
        }
    }
}