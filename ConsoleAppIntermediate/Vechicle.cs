using System;

namespace ConsoleAppIntermediate
{
    public class Vechicle
    {
        private readonly string registrationNumber;

        public Vechicle(string registrationNumber)
        {
            this.registrationNumber = registrationNumber;
            Console.WriteLine("Vehicle is being initialized {0}",this.registrationNumber);
        }
    }
}