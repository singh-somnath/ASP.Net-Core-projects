using System;

namespace ConsoleAppIntermediate.AbstractRuntimePolymorphismForDBConnection
{

    public class DbCommand
    {
        private string SqlInstruction { get; set; }
        private DbConnection DbConnection { get; set; }
        public DbCommand(DbConnection dbConnection, string sqlInstruction)
        {
            if (dbConnection == null) throw new ArgumentNullException();
            if (sqlInstruction == null) throw new ArgumentNullException();
            if (sqlInstruction.Length == 0) throw new ArgumentNullException();

            DbConnection = dbConnection;
            SqlInstruction = sqlInstruction;


        }

        public void Execute()
        {
            DbConnection.Open();
            Console.WriteLine("Runing SQL Instruction - {0}", SqlInstruction);
            DbConnection.Close();
        }
    }

}