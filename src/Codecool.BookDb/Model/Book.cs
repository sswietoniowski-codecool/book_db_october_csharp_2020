namespace Codecool.BookDb.Model
{
    public class Book
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }

        public Book(Author author, string title)
        {
            Author = author;
            Title = title;
        }

        public override string ToString()
        {
            return new string($"{Id}, {Title}, {Author.FirstName}, {Author.LastName}");
        }
    }
}
