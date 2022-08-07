namespace TaskBook.DTOs.Book
{
    public class BookGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Page { get; set; }
        public CategoryInBookDto Category { get; set; }

    }
    public class CategoryInBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BooksCount { get; set; }
    }
}
