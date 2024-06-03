using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.AddDtos;
using WebApplication1.Dtos.NormalEntity;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Dtos.NavigationPropertyDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public CategoriesController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CategoryDto> GetList()
        {
            var Categories = _context.Categories.ToList();
            var CategoryDtos = _mapper.Map<List<CategoryDto>>(Categories);
            return CategoryDtos;
        }
        [HttpGet("{id}")]
        public CategoryDto Get(int id)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.Id == id);
            var CategoryDto = _mapper.Map<CategoryDto>(Category);
            return CategoryDto;
        }
        [HttpGet("GettListCars")]
        public List<CategoryAndCardPropertyDtos> GettListCars()
        {
            var categoryandcars = _context.Categories.Include(x=>x.Cars).ToList();
            var categoryandcarsdtos = _mapper.Map<List<CategoryAndCardPropertyDtos>>(categoryandcars);
            return categoryandcarsdtos;
        }
        [HttpGet("GettListCars/{id}")]
        public CategoryAndCardPropertyDtos GettListCars(int id)
        {
            var category = _context.Categories
                           .Include(x => x.Cars)
                           .FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            var categoryAndCardPropertyDto = _mapper.Map<CategoryAndCardPropertyDtos>(category);

            return categoryAndCardPropertyDto;
        }

        [HttpPost]
        public CategoryAddDto CategoryAddDto(CategoryAddDto CategoryAddDto)
        {
            var Category = _mapper.Map<Category>(CategoryAddDto);
            _context.Categories.Add(Category);
            _context.SaveChanges();
            return CategoryAddDto;
        }
        [HttpPut]
        public CategoryDto CategoryUpdateDto(CategoryDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            _context.Categories.Update(Category);
            _context.SaveChanges();
            return CategoryDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Category deleted successfully";
            }
            else
            {
                result.Status = false;
                result.Message = "Category not found";
            }
            return result;
        }
    }
}
