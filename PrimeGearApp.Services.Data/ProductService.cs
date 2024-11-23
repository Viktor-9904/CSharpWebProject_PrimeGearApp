using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.ProductViewModels;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;

namespace PrimeGearApp.Services.Data
{
    public class ProductService : IProductService
    {
        public IRepository<Product, int> productRepository;
        public IRepository<ProductDetail, int> productDetailRepository;
        public IRepository<ProductType, int> productTypeRepository;
        public IRepository<ProductTypeProperty, int> productTypePropertyRepository;

        public ProductService(
            IRepository<Product, int> productRepository,
            IRepository<ProductDetail, int> productDetailRepository,
            IRepository<ProductType, int> productTypeRepository,
            IRepository<ProductTypeProperty, int> productTypePropertyRepository)
        {
            this.productRepository = productRepository;
            this.productDetailRepository = productDetailRepository;
            this.productTypeRepository = productTypeRepository;
            this.productTypePropertyRepository = productTypePropertyRepository;
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

        public async Task<IEnumerable<ProductTypePropertyViewModel>> GetAllProductTypePropertiesByProductTypeIdAsync(int id)
        {
            var productTypeProperties = await this.productTypePropertyRepository
                .GetAllAttached()
                .Where(ptp => ptp.ProductTypeId == id)
                .ToArrayAsync();

            List<ProductTypePropertyViewModel> viewModels = new List<ProductTypePropertyViewModel>();

            for (int i = 0; i < productTypeProperties.Length; i++)
            {
                ProductTypePropertyViewModel model = new ProductTypePropertyViewModel()
                {
                    Id = productTypeProperties[i].Id,
                    ProductTypePropertyName = productTypeProperties[i].ProductTypePropertyName,
                    ProductTypeId = productTypeProperties[i].ProductTypeId,
                    ProductTypePropertyUnitOfMeasurementName = productTypeProperties[i].ProductTypePropertyUnitOfMeasurement
                };
                viewModels.Add(model);
            }

            return viewModels;
        }


        public async Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypesAsync()
        {
            IEnumerable<ProductTypeViewModel> productTypes = await this.productTypeRepository
                .GetAllAttached()
                .Select(p => new ProductTypeViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name
                })
                .OrderBy(p => p.Name)
                .ToArrayAsync();

            return productTypes;
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
                Description = product.Description,
                ReleaseDate = product.RelaseDate.ToString(ProductReleaseDateFormat),
                ProductImagePath = product.ProductImagePath,
                ProductPrice = product.Price.ToString(),
                WarrantyInMonths = product.WarrantyDurationInMonths.ToString(),
                AvaibleQuantity = product.AvaibleQuantity.ToString()
            };
            foreach (ProductDetail detail in productDetails)
            {

                string detailKey = detail.ProductTypeProperty.ProductTypePropertyName;
                string? detailValueUnitOfMeasurement = detail.ProductTypeProperty.ProductTypePropertyUnitOfMeasurement;

                string detailValue = detailValueUnitOfMeasurement.IsNullOrEmpty()
                    ? detail.ProductTypePropertyValue
                    : string.Concat(detail.ProductTypePropertyValue, " ", detailValueUnitOfMeasurement);


                if (bool.TryParse(detailValue, out bool boolResult))
                {
                    detailValue = boolResult ? "Yes" : "No";
                }

                DetailsViewModel.ProductProperties!
                    .Add(detailKey, detailValue);
            }
            return DetailsViewModel;
        }


    }
}
