using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TaskBook.DAL;
using TaskBook.DTOs;
using TaskBook.DTOs.Category;
using TaskBook.Models;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly APIDbContext _context;

        //public readonly IMapper _mapper;

        public CategoriesController(APIDbContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CategoryPostDto categoryDto)
        {
            if (categoryDto == null) return NotFound();
            if (_context.Categorie.Any(e => e.Name == categoryDto.Name)) return NotFound();
            Category category = new Category
            {
                Name = categoryDto.Name,

            };
            await _context.Categorie.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { id = category.Id, book = categoryDto });
        }

        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categorie.FirstOrDefault(e => e.Id == id);
            if (category == null) return NotFound();
            CategoryGetDto dto = new CategoryGetDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(dto);
        }
        [HttpGet("getall")]
        public IActionResult GetAll(int page = 1)
        {
            var query = _context.Categorie.AsQueryable();
            ListDto<CategoryListItemDto> listDto = new ListDto<CategoryListItemDto>
            {
                ListItemDtos = query.Select(e => new CategoryListItemDto { Id = e.Id, Name = e.Name })
                .Skip((page - 1) * 4)
                .Take(4)
                .ToList(),
                TotalCount = query.Count()
            };
            return Ok(listDto);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if(id==0) return BadRequest();
            Category existed = _context.Categorie.FirstOrDefault(c=>c.Id == id);
            if(existed==null) return NotFound();
            _context.Categorie.Remove(existed);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id,CategoryPostDto dto)
        {
            if (id == 0) return BadRequest();
            if (_context.Categorie.Any(e => e.Name == dto.Name)) return BadRequest();
            Category existed = await _context.Categorie.FirstOrDefaultAsync(e => e.Id == id);
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();
            return StatusCode(200, new { category = dto });
        }
    }

}
