using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string TcNo { get; set; }

        public List<Rent> Rent { get; set; }
    }
}
