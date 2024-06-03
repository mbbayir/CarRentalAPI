using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Dtos.AddDtos;
using WebApplication1.Dtos.NormalEntity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/CarImages")]
    [ApiController]
    [Authorize]
    public class CarImagesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public CarImagesController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarImagesDto> GetList()
        {
            var CarImages = _context.CarImages.ToList();
            var CarImagesDtos = _mapper.Map<List<CarImagesDto>>(CarImages);
            return CarImagesDtos;
        }
        [HttpGet("{id}")]
        public CarImagesDto Get(int id)
        {
            var CarImages = _context.CarImages.FirstOrDefault(x => x.Id == id);
            var CarImagesDto = _mapper.Map<CarImagesDto>(CarImages);
            return CarImagesDto;
        }

        [HttpPost]
        public CarImagesAddDto CarImagesAddDto(CarImagesAddDto CarImagesAddDto)
        {
            var CarImages = _mapper.Map<CarImages>(CarImagesAddDto);
            _context.CarImages.Add(CarImages);
            _context.SaveChanges();
            return CarImagesAddDto;
        }
        [HttpPut]
        public CarImagesDto CarImagesUpdateDto(CarImagesDto CarImagesDto)
        {
            var CarImages = _mapper.Map<CarImages>(CarImagesDto);
            _context.CarImages.Update(CarImages);
            _context.SaveChanges();
            return CarImagesDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var CarImages = _context.CarImages.FirstOrDefault(x => x.Id == id);
            if (CarImages != null)
            {
                _context.CarImages.Remove(CarImages);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "CarImages Deleted";
            }
            else
            {
                result.Status = false;
                result.Message = "CarImages Not Found";
            }
            return result;
        }
    }
}
