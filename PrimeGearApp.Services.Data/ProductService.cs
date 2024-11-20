﻿using Microsoft.EntityFrameworkCore;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.ProductViewModels;
using static PrimeGearApp.Common.ApplicationConstants.ProductConstants;

namespace PrimeGearApp.Services.Data
{
    public class ProductService : IProductService
    {
        public IRepository<Product, int> productRepository;
        public IRepository<ProductDetail, int> productDetailRepository;

        public ProductService(
            IRepository<Product, int> productRepository,
            IRepository<ProductDetail, int> productDetailRepository)
        {
            this.productRepository = productRepository;
            this.productDetailRepository = productDetailRepository;
        }
        public async Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync()
        {
            IEnumerable<ProductIndexViewModel> products = await this.productRepository
                .GetAllAttached()
                .Select(p => new ProductIndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Brand = p.Brand,
                    ReleaseDate = p.RelaseDate.ToString(ProductReleaseDateFormat),
                    ProductImagePath = p.ProductImagePath,
                    ProductPrice = p.Price.ToString(),
                    WarrantyInMonths = p.WarrantyDurationInMonths.ToString(),
                    AvaibleQuantity = p.AvaibleQuantity.ToString()
                })
                .OrderBy(p => p.Name)
                .ToArrayAsync();

            return products;
        }

        public async Task<ProductDetailViewModel> GetProductDetailByIdAsync(int id)
        {
            Product? product = await this.productRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(p => p.Id == id);

            IEnumerable<ProductDetail> productDetails = await this.productDetailRepository
                .GetAllAttached()
                .Include(pd => pd.ProductTypeProperty)
                .Where(p => p.ProductId == id)
                .ToArrayAsync();

            ProductDetailViewModel DetailsViewModel = new ProductDetailViewModel()
            {
                Id = product!.Id.ToString(),
                Name = product.Name,
                Brand = product.Brand,
                ReleaseDate = product.RelaseDate.ToString(ProductReleaseDateFormat),
                ProductImagePath = product.ProductImagePath,
                ProductPrice = product.Price.ToString(),
                WarrantyInMonths = product.WarrantyDurationInMonths.ToString(),
                AvaibleQuantity = product.AvaibleQuantity.ToString()
            };
            foreach (ProductDetail detail in productDetails)
            {
                string detailKey = detail.ProductTypeProperty.ProductTypePropertyName;
                string detailValue = detail.ProductTypePropertyValue;

                DetailsViewModel.ProductProperties!
                    .Add(detailKey, detailValue);
            }
            return DetailsViewModel;
        }
    }
}
