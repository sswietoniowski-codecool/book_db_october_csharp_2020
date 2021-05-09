using System;
using Microsoft.Data.SqlClient;
using static System.Configuration.ConfigurationManager;

namespace Codecool.BookDb.Manager
{
    public class BookDbManager
    {
        private const string SETTINGS_CONNECTION_STRING = "connectionString";
        public string ConnectionString => AppSettings[SETTINGS_CONNECTION_STRING];

        public string Connect()
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            Console.WriteLine("Connected...");
            
            return ConnectionString;
        }
    }
}