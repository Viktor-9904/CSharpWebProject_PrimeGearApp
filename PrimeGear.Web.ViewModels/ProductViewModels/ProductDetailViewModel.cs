﻿namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public class ProductDetailViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string? ProductImagePath { get; set; }
        public string ProductPrice { get; set; } = null!;
        public string WarrantyInMonths { get; set; } = null!;
        public string AvaibleQuantity { get; set; } = null!;
        public bool IsCurrentProductAddedToFavorites { get; set; }

        public Dictionary<string, string>? ProductProperties { get; set; }
            = new Dictionary<string, string>();
    }
}
