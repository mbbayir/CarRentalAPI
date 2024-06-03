using WebApplication1.Dtos.NormalDtos;
using WebApplication1.Models;

namespace WebApplication1.Dtos.NavigationPropertyDtos
{
    public class CategoryAndCardPropertyDtos
    {
        public string CategoryName { get; set; }
        public List<CarDto> Car { get; set; }
    }
}
