using System.Collections.Generic;

namespace Codecool.BookDb.Model
{
    public interface IBookDao
    {
        public void Add(Book book);

        public void Update(Book book);

        public Book Get(int id);

        List<Book> GetAll();
    }
}
