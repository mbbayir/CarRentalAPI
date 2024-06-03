using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Dtos.AddDtos;
using WebApplication1.Dtos.NavigationPropertyDtos;
using WebApplication1.Dtos.NormalDtos;
using WebApplication1.Dtos.NormalEntity;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandAddDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarAddDto>().ReverseMap();
            CreateMap<CarFeatures, CarFeaturesDto>().ReverseMap();
            CreateMap<CarFeatures, CarFeaturesAddDto>().ReverseMap();
            CreateMap<CarImages, CarImagesDto>().ReverseMap();
            CreateMap<CarImages, CarImagesAddDto>().ReverseMap();   
            CreateMap<Rent, RentDto>().ReverseMap();
            CreateMap<Rent, RentAddDto>().ReverseMap();
            CreateMap<Car, CarGetNavigateAllPropertyDtos>().ReverseMap();
            CreateMap<Category, CategoryAndCardPropertyDtos>()
                .ForMember(dto=>dto.Car,opt=>opt.MapFrom(cat=>cat.Cars)).ReverseMap();
            CreateMap<Rent, RentCarGetNavigeAllPropertyDtos>()
                .ForMember(dto=>dto.Car,opt=>opt.MapFrom(rent=>rent.Car))
                .ForMember(dto=>dto.User,opt=>opt.MapFrom(rent=>rent.User)).ReverseMap();
            CreateMap<Car, CarNameDto>().ReverseMap();

        }
    }
}
