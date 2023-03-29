using System;

namespace ConsoleAppIntermediate
{
    public class ChangeVideoStatus : IActivity
    {
        public string Name { get; set; }

        public ChangeVideoStatus(string name)
        {
            Name = name;
        }

        public void Execute()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine("Current Video Status : Processing");
        }
    }

}