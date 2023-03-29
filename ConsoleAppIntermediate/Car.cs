using System;

namespace ConsoleAppIntermediate
{
    public class Car : Vechicle
    {
        public Car(string registrationNumber):base(registrationNumber)
        { 
            Console.WriteLine("Car is being initialized {0}", registrationNumber); 
        }
    }
}