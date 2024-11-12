﻿namespace PrimeGearApp.Data.Models
{
    public class ProductType
    {
        public Guid Id { get; set; } 
            = Guid.NewGuid();
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
            = new List<Product>();  
    }
}