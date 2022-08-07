using System.Collections.Generic;
using TaskBook.Models.Base;

namespace TaskBook.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
