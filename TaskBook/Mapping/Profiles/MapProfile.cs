using AutoMapper;
using TaskBook.DTOs.Book;
using TaskBook.Models;

namespace TaskBook.Mapping.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Book,BookGetDto>();
            CreateMap<Category,CategoryInBookDto>();
            CreateMap<Book,BookListItemDto>();
        }
    }
}
