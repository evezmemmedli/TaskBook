using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBook.DAL;
using TaskBook.DTOs;
using TaskBook.DTOs.Book;
using TaskBook.Models;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly APIDbContext _context;

        public readonly IMapper _mapper;

        public BooksController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(BookPostDto bookDto)
        {
           if(bookDto==null) return NotFound();
            if (!_context.Categorie.Any(e => e.Id == bookDto.CategoryId)) return BadRequest();
            Book book = new Book
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Price = bookDto.Price,
                Page = bookDto.Page,
                CategoryId=bookDto.CategoryId
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { id = book.Id, book = bookDto });
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            if(id==0) return NotFound();
            Book book = _context.Books.Include(b => b.Category).ThenInclude(b => b.Books).FirstOrDefault(b => b.Id == id);
            BookGetDto dto = _mapper.Map<BookGetDto>(book);
            return Ok(dto);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int page=1)
        {
            var query = _context.Books.AsQueryable();
            List<Book>books = _context.Books.Include(c=>c.Category).ThenInclude(c=>c.Books).Skip((page-1)*4).Take(2).ToList();
            ListDto<BookListItemDto> dto = new ListDto<BookListItemDto>
            {
                ListItemDtos = _mapper.Map<List<BookListItemDto>>(books),
                TotalCount = query.Count()
            };
            return Ok(dto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,BookPostDto bookDto)
        {
            if (id == 0) return BadRequest();
            Book existed = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            _context.Entry(existed).CurrentValues.SetValues(bookDto);
            if (existed == null) return NotFound();
            await _context.SaveChangesAsync();
            return StatusCode(200, bookDto);

        }
    }
}
