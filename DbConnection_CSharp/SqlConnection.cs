using System;

namespace DbConnection_CSharp
{
public class SqlConnection : DbConnection
        {
            public override void Open(string connection)
            {
                if (connection == null || connection == "")
                    throw new InvalidOperationException("Invalid connection string.");
 
                ConnectionString = connection;
                CheckTime();
 
                // Connect to the database
                while (!_isConnected && DateTime.Compare(DateTime.Now,expireTime) < 0)
                {
                    // Code to connect the database
                    _isConnected = true;
                }
 
                if (!_isConnected)
                    throw new InvalidOperationException("Connection failed.");
                else
                    Console.WriteLine("Connected to SQL Database.");
            }
 
            public override void Close()
            {
                // Close the database
                Console.WriteLine("SQL Database is closed.");
            }
        }
}