namespace WebApplication1.Dtos.NormalDtos
{
    public class RentDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
