using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Dtos.AddDtos;
using WebApplication1.Dtos.NormalEntity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/Brands")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public BrandsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public List<BrandDto> GetList()
        {
            var Brands = _context.Brands.ToList();
            var BrandDtos = _mapper.Map<List<BrandDto>>(Brands);
            return BrandDtos;
        }
        [HttpGet("{id}")]
        public BrandDto Get(int id)
        {
            var Brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            var BrandDto = _mapper.Map<BrandDto>(Brand);
            return BrandDto;
        }

        [HttpPost]
        public BrandAddDto BrandAddDto(BrandAddDto BrandAddDto)
        {
            var Brand = _mapper.Map<Brand>(BrandAddDto);
            _context.Brands.Add(Brand);
            _context.SaveChanges();
            return BrandAddDto;
        }
        [HttpPut]
        public BrandDto BrandUpdateDto(BrandDto BrandDto)
        {
            var Brand = _mapper.Map<Brand>(BrandDto);
            _context.Brands.Update(Brand);
            _context.SaveChanges();
            return BrandDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (Brand != null)
            {
                _context.Brands.Remove(Brand);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Brand deleted successfully";
            }
            else
            {
                result.Status = false;
                result.Message = "Brand not found";
            }
            return result;
        }

    }
}
