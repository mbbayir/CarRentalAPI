using WebApplication1.Dtos.NormalDtos;
using WebApplication1.Models;

namespace WebApplication1.Dtos.NavigationPropertyDtos
{
    public class RentCarGetNavigeAllPropertyDtos
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public CarNameDto Car { get; set; }
        public UserDto User { get; set; }
    }
}
