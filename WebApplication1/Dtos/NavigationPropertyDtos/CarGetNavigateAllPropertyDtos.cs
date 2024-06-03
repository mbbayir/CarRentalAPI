using WebApplication1.Dtos.NormalEntity;

namespace WebApplication1.Dtos.NavigationPropertyDtos
{
    public class CarGetNavigateAllPropertyDtos
    {

        public string CarName { get; set; }

        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
        public CarFeaturesDto CarFeatures { get; set; }
        public CarImagesDto CarImages { get; set; }
    }
}
