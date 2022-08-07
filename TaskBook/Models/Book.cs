using TaskBook.Models.Base;

namespace TaskBook.Models
{
    public class Book:BaseEntity
    {
        public string  Name { get; set; }
        public string  Author { get; set; }
        public decimal  Price { get; set; }
        public int  Page { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
