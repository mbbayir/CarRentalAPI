﻿namespace WebApplication1.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; } // Bir arabanın birden fazla markası olabilir.
    }
}
