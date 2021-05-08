using System.Collections.Generic;

namespace Codecool.BookDb.Model
{
    public interface IAuthorDao
    {
        /// <summary>
        /// Adds a new object to the database and sets the new ID.
        /// </summary>
        /// <param name="author">A new object, with ID not yet set (null). </param>
        public void Add(Author author);

        /// <summary>
        /// Updates existing object's data in the database.
        /// </summary>
        /// <param name="author">An object from the database, with ID already set.</param>
        public void Update(Author author);

        /// <summary>
        /// Get object by ID.
        /// </summary>
        /// <param name="id">ID to search by</param>
        /// <returns>An object with a given ID, or null if not found.</returns>
        public Author Get(int id);

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>List of all objects of this type in the database.</returns>
        public List<Author> GetAll();
    }
}
