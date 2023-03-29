using System;

namespace ConsoleAppIntermediate.AbstractRuntimePolymorphismForDBConnection
{

    public class ManogDBConnection : DbConnection
    {
        public ManogDBConnection(string connectionString) : base(connectionString) { }
        public override void Close()
        {
            Console.WriteLine("Close Mango DB");
        }

        public override void Open()
        {
            Console.WriteLine("Open Maango DB");
        }
    }

}