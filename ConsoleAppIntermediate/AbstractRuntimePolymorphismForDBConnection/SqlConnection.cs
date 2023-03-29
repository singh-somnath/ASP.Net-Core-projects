using System;

namespace ConsoleAppIntermediate.AbstractRuntimePolymorphismForDBConnection
{

    public class SqlConnection : DbConnection
    {

        public SqlConnection(string connectionstring) : base(connectionstring)
        {

        }
        public override void Open()
        {
            Console.WriteLine("Open SqlConnection");
        }

        public override void Close()
        {
            Console.WriteLine("Close SqlConnection");
        }
    }

}