using System;

namespace ConsoleAppIntermediate
{
    public class UploadVideo : IActivity
    {
        public string Name { get; set; }

        public UploadVideo(string name)
        {
            Name = name;
        }

        public void Execute()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine("Uploading a video ...");
        }
    }

}