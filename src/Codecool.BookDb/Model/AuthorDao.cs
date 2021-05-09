using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Codecool.BookDb.Model
{
    public class AuthorDao : IAuthorDao
    {
        private readonly string _connectionString;
        
        public AuthorDao(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public void Add(Author author)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        @"
INSERT INTO dbo.author (first_name, last_name, birth_date)
VALUES (@FirstName, @LastName, @BirthDate);

SELECT SCOPE_IDENTITY();
";
                    command.Parameters.AddWithValue("@FirstName", author.FirstName);
                    command.Parameters.AddWithValue("@LastName", author.LastName);
                    command.Parameters.AddWithValue("@BirthDate", author.BirthDate);

                    int authorId = Convert.ToInt32(command.ExecuteScalar());
                    author.Id = authorId;
                }

                connection.Close();
            }
            catch (SqlException exception)
            {
                // tutaj dodamy logowanie
                throw;
            }
        }

        public void Update(Author author)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText =
                    @"
UPDATE dbo.author
SET
    first_name = @FirstName,
    last_name = @LastName,
    birth_date = @BirthDate
WHERE
    id = @Id;
";
                command.Parameters.AddWithValue("@FirstName", author.FirstName);
                command.Parameters.AddWithValue("@LastName", author.LastName);
                command.Parameters.AddWithValue("@BirthDate", author.BirthDate);
                command.Parameters.AddWithValue("@Id", author.Id);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public Author Get(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = 
@"
SELECT id, first_name, last_name, birth_date 
FROM dbo.author 
WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            Author author = null;
            
            if (reader.Read())
            {
                string firstName = (string)reader["first_name"];
                string lastName = (string)reader["last_name"];
                DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);

                author = new Author(firstName, lastName, birthDate) {Id = id};
            }
            
            connection.Close();

            return author;
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        public List<Author> GetAll()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = 
                @"
SELECT id, first_name, last_name, birth_date 
FROM dbo.author";

            using var reader = command.ExecuteReader();

            List<Author> authors = new List<Author>();
            
            while (reader.Read())
            {
                int id = (int) reader["id"];
                string firstName = (string)reader["first_name"];
                string lastName = (string)reader["last_name"];
                DateTime birthDate = Convert.ToDateTime(reader["birth_date"]);

                Author author = new Author(firstName, lastName, birthDate) {Id = id};
                authors.Add(author);
            }
            
            connection.Close();

            return authors;
            }
            catch (SqlException exception)
            {
                throw;
            }
        }
    }
}