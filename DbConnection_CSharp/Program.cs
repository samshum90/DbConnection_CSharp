using System;

namespace DbConnection_CSharp
{
    class Program
    {
  static void Main(string[] args)
        {
            DbConnection database;
            ChooseConnectionMethod();
 
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    database = new SqlConnection();
                    break;
                }
                else if (input == "2")
                {
                    database = new OracleConnection();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please try again.");
                    ChooseConnectionMethod();
                }
            }
 
            // Set Timeout as 5 seconds
            database.Timeout = new TimeSpan(0, 0, 5);
 
            Console.Write("Please input the connection API: ");
            var api = Console.ReadLine();
 
            database.Open(api);
            Menu(database);
        }
 
        private static void Menu(DbConnection database)
        {
            Console.Write("Input \"close\" to close the connection: ");
            var input = Console.ReadLine();
            if (input.ToLower() == "close")
            {
                Console.Clear();
                database.Close();
            }
            else
            {
                Console.Clear();
                Menu(database);
            }
        }
 
        private static void ChooseConnectionMethod()
        {
            Console.WriteLine("Connection Methods:");
            Console.WriteLine("1. SQL");
            Console.WriteLine("2. Oracle");
            Console.WriteLine("Choose the connection methods: ");
        }
    }
}
