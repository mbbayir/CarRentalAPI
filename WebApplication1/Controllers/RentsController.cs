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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public RentsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<RentDto> GetList()
        {
            var Rents = _context.Rents.ToList();
            var RentDtos = _mapper.Map<List<RentDto>>(Rents);
            return RentDtos;
        }
        [HttpGet("GetNavigeAllProperty")]
        public List<RentCarGetNavigeAllPropertyDtos> GetNavigeAllProperty()
        {
            var Rents = _context.Rents.Include(x => x.Car).Include(x => x.User).ToList();
            var RentDtos = _mapper.Map<List<RentCarGetNavigeAllPropertyDtos>>(Rents);
            return RentDtos;
        }

        [HttpGet("GetNavigeAllProperty/{id}")]
        public List<RentCarGetNavigeAllPropertyDtos> GetNavigeAllProperty(int id)
        {
            var Rents = _context.Rents.Include(x => x.Car).Include(x => x.User).Where(x=>x.Id == id).ToList();
            var RentDtos = _mapper.Map<List<RentCarGetNavigeAllPropertyDtos>>(Rents);
            return RentDtos;
        }





        [HttpGet("{id}")]
        public RentDto Get(int id)
        {
            var Rent = _context.Rents.FirstOrDefault(x => x.Id == id);
            var RentDto = _mapper.Map<RentDto>(Rent);
            return RentDto;
        }

        [HttpPost]
        public RentAddDto RentAddDto(RentAddDto RentAddDto)
        {
            var Rent = _mapper.Map<Rent>(RentAddDto);
            _context.Rents.Add(Rent);
            _context.SaveChanges();
            return RentAddDto;
        }
        [HttpPut]
        public RentDto RentUpdateDto(RentDto RentDto)
        {
            var Rent = _mapper.Map<Rent>(RentDto);
            _context.Rents.Update(Rent);
            _context.SaveChanges();
            return RentDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Rent = _context.Rents.FirstOrDefault(x => x.Id == id);
            if (Rent != null)
            {
                _context.Rents.Remove(Rent);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Rent deleted successfully";
            }
            else
            {
                result.Status = false;
                result.Message = "Rent not found";
            }
            return result;
        }
    }
}
