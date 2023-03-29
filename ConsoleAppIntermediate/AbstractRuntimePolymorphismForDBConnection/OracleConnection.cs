using System;

namespace ConsoleAppIntermediate.AbstractRuntimePolymorphismForDBConnection
{

    public class OracleConnection : DbConnection
    {

        public OracleConnection(string connectionstring) : base(connectionstring)
        {

        }
        public override void Open()
        {
            Console.WriteLine("Open OracleConnection");
        }

        public override void Close()
        {
            Console.WriteLine("Close OracleConnection");
        }
    }

}