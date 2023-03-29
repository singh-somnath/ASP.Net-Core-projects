using System;

namespace ConsoleAppIntermediate.AbstractRuntimePolymorphismForDBConnection
{

    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan TimeOut { get; set; }

        public DbConnection(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException();
            if (connectionString.Length == 0) throw new ArgumentNullException();

            ConnectionString = connectionString;
        }

        public abstract void Open();

        public abstract void Close();
    }

}