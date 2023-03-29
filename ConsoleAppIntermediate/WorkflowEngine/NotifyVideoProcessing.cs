using System;

namespace ConsoleAppIntermediate
{
    public class NotifyVideoProcessing : IActivity
    {
        public string Name { get; set; }

        public NotifyVideoProcessing(string name)
        {
            Name = name;
        }

        public void Execute()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine("Started video notification ...");
        }
    }

}