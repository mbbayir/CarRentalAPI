namespace WebApplication1.Models
{
    public class CarFeatures
    {
        public int Id { get; set; }
        public string CarKm { get; set; }
        public string CarColor { get; set; }
        public string CarModel { get; set; }
        public string CarYear { get; set; }
        public string CarFuel { get; set; }
        public string CarGear { get; set; }
        public string CarDescription { get; set; }
        public string CarPrice { get; set; }


        public Car Car { get; set; }


    }
}
