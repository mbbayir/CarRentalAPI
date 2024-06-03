using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Dtos.AddDtos;
using WebApplication1.Dtos.NavigationPropertyDtos;
using WebApplication1.Dtos.NormalDtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    [Authorize]
    public class CarsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public CarsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarDto> GetList()
        {
            var Cars = _context.Cars.ToList();
            var CarDtos = _mapper.Map<List<CarDto>>(Cars);
            return CarDtos;
        }
        [HttpGet("GetAllListNavigateProperty")]
        public List<CarGetNavigateAllPropertyDtos> GettListAl()
        {
            var cars = _context.Cars.Include(x => x.Brand).Include(x => x.CarFeatures).Include(x=>x.CarImages).Include(x=>x.Category).ToList();

            var cardtos = _mapper.Map<List<CarGetNavigateAllPropertyDtos>>(cars);

            return cardtos;
        }
        [HttpGet("GetAllListNavigatePropertyById/{id}")]
        public List<CarGetNavigateAllPropertyDtos> GettListAl(int id)
        {
            var cars = _context.Cars.Include(x => x.Brand).Include(x => x.CarFeatures).Include(x => x.CarImages).Include(x => x.Category).Where(c=>c.Id == id).ToList();

            var cardtos = _mapper.Map<List<CarGetNavigateAllPropertyDtos>>(cars);

            return cardtos;
        }

        [HttpGet("{id}")]
        public CarDto Get(int id)
        {
            var Car = _context.Cars.FirstOrDefault(x => x.Id == id);
            var CarDto = _mapper.Map<CarDto>(Car);
            return CarDto;
        }

        [HttpPost]
        public CarAddDto CarAddDto(CarAddDto CarAddDto)
        {
            var Car = _mapper.Map<Car>(CarAddDto);
            _context.Cars.Add(Car);
            _context.SaveChanges();
            return CarAddDto;
        }
        [HttpPut]
        public CarDto CarUpdateDto(CarDto CarDto)
        {
            var Car = _mapper.Map<Car>(CarDto);
            _context.Cars.Update(Car);
            _context.SaveChanges();
            return CarDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (Car != null)
            {
                _context.Cars.Remove(Car);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Car deleted successfully";
            }
            else
            {
                result.Status = false;
                result.Message = "Car not found";
            }
            return result;
        }
    }
}
