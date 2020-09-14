using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace TechDesk.Data
{
    public class DbConnectionFactory
    {
        private string Connection { get; } = string.Empty;

        private static IDbConnection dbConnection = null;
        
        private static readonly object locker = new object();

        private DbConnectionFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Sqlite"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                Connection = connectionString;
            }
        }

        private static DbConnectionFactory instance;
        public static DbConnectionFactory GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new DbConnectionFactory();
                    }
                }
            }

            return instance;
        }

        public static IDbConnection OpenCurrentDbConnection()
        {
            if (dbConnection == null)
            {
                dbConnection = new SQLiteConnection(instance.Connection);
            }


            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            return dbConnection;
        }
        
        public static IDbConnection OpenCurrentDbConnection(string dbConnectionString)
        {
            if (dbConnection == null)
            {
                dbConnection = new SQLiteConnection(dbConnectionString);
            }


            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            return dbConnection;
        }
    }
}