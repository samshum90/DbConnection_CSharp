using System;

namespace DbConnection_CSharp
{
    public class OracleConnection : DbConnection
        {
            public override void Open(string connection)
            {
                if (connection == null || connection == "")
                    throw new InvalidOperationException("Invalid connection string.");
 
                ConnectionString = connection;
                CheckTime();
 
                while (!_isConnected && DateTime.Compare(DateTime.Now, expireTime) < 0)
                {
                    _isConnected = true;
                }
 
                if (!_isConnected)
                    throw new InvalidOperationException("Connection failed.");
                else
                    Console.WriteLine("Connected to Oracle Database.");
            }
 
            public override void Close()
            {
                Console.WriteLine("Oracle Database is closed.");
            }
        }
}