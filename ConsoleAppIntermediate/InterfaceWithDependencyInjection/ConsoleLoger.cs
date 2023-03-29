using System;

namespace ConsoleAppIntermediate.InterfaceWithDependencyInjection
{
    public class ConsoleLoger : ILoger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
    }
}