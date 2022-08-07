using System.Collections.Generic;

namespace TaskBook.DTOs
{
    public class ListDto<T>
    {
        public List<T> ListItemDtos { get; set; }
        public int TotalCount { get; set; }
    }
}
