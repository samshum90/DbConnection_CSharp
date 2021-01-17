using System;

namespace DbConnection_CSharp
{
    public class DbCommand
    {
         public DbConnection dbConnection;
        public string dbInstruction;
 
        private readonly string _api = "ddfghl";
 
        public DbCommand(DbConnection connection, string instruction)
        {
            dbConnection = connection;
            if (string.IsNullOrEmpty(instruction) || connection == null)
                throw new InvalidOperationException("Invalid instruction.");
 
            dbInstruction = instruction;
        }
 
        public void Execute()
        {
            dbConnection.Open(_api);
            RunInstruction();
            dbConnection.Close();
        }
 
        private void RunInstruction()
        {
            Console.WriteLine("Instruction [{0}] is running.", dbInstruction);
        }
    }
}