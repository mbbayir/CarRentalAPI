namespace WebApplication1.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public Car Car { get; set; }
        public AppUser User { get; set; }
    }
}
