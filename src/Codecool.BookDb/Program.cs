using System;
using System.Threading.Channels;
using Codecool.BookDb.Manager;
using Codecool.BookDb.Model;
using Microsoft.Data.SqlClient;

namespace Codecool.BookDb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var manager = new BookDbManager();
                var connectionString = manager.Connect();

                var authorDao = new AuthorDao(connectionString);
                var authors = authorDao.GetAll();

                foreach (var author in authors)
                {
                    Console.WriteLine($"Autor: {author}");
                }


            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
