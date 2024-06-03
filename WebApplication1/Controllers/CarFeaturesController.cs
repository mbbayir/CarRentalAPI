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
    [Route("api/CarFeatures")]
    [ApiController]
    [Authorize]
    public class CarFeaturesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public CarFeaturesController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarFeaturesDto> GetList()
        {
            var CarFeatures = _context.CarFeatures.ToList();
            var CarFeaturesDtos = _mapper.Map<List<CarFeaturesDto>>(CarFeatures);
            return CarFeaturesDtos;
        }
        [HttpGet("{id}")]
        public CarFeaturesDto Get(int id)
        {
            var CarFeatures = _context.CarFeatures.FirstOrDefault(x => x.Id == id);
            var CarFeaturesDto = _mapper.Map<CarFeaturesDto>(CarFeatures);
            return CarFeaturesDto;
        }

        [HttpPost]
        public CarFeaturesAddDto CarFeaturesAddDto(CarFeaturesAddDto CarFeaturesAddDto)
        {
            var CarFeatures = _mapper.Map<CarFeatures>(CarFeaturesAddDto);
            _context.CarFeatures.Add(CarFeatures);
            _context.SaveChanges();
            return CarFeaturesAddDto;
        }
        [HttpPut]
        public CarFeaturesDto CarFeaturesUpdateDto(CarFeaturesDto CarFeaturesDto)
        {
            var CarFeatures = _mapper.Map<CarFeatures>(CarFeaturesDto);
            _context.CarFeatures.Update(CarFeatures);
            _context.SaveChanges();
            return CarFeaturesDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var CarFeatures = _context.CarFeatures.FirstOrDefault(x => x.Id == id);
            if (CarFeatures != null)
            {
                _context.CarFeatures.Remove(CarFeatures);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "CarFeatures Deleted";
                return result;
            }
            result.Status = false;
            result.Message = "CarFeatures Not Found";
            return result;
        }
    }
}
