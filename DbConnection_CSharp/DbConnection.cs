using System;

namespace DbConnection_CSharp
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }
 
        protected bool _isConnected = false;
        protected DateTime expireTime;
 
        public abstract void Open(string connection);
        public abstract void Close();
 
        protected void CheckTime()
        {
            expireTime = DateTime.Now + Timeout;
 
            Console.Clear();
            Console.WriteLine("Connecting...");
            Console.WriteLine();
            Console.WriteLine("Time Now: " + DateTime.Now);
            Console.WriteLine("Expire Time: " + expireTime);
            Console.WriteLine();
        }
    }
}