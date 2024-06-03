namespace WebApplication1.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int CategoryId { get; set; }
        public int CarFeaturesId { get; set; }
        public int CarImagesId { get; set; }
        public int BrandId { get; set; }
        public Category Category { get; set; }
        public CarFeatures CarFeatures { get; set; }
        public CarImages CarImages { get; set; }
        public Brand Brand { get; set; }
    }
}
