namespace WebApplication1.Models
{
    public class CarImages
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }

        public Car Car { get; set; }
    }
}
