using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.ProductViewModels;
using System.Collections.Immutable;
using System.Linq;
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
        public IRepository<PropertyValueType, int> propertyValueTypeRepository;

        public ProductService(
            IRepository<Product, int> productRepository,
            IRepository<ProductDetail, int> productDetailRepository,
            IRepository<ProductType, int> productTypeRepository,
            IRepository<ProductTypeProperty, int> productTypePropertyRepository,
            IRepository<PropertyValueType, int> propertyValueTypeRepository)
        {
            this.productRepository = productRepository;
            this.productDetailRepository = productDetailRepository;
            this.productTypeRepository = productTypeRepository;
            this.productTypePropertyRepository = productTypePropertyRepository;
            this.propertyValueTypeRepository = propertyValueTypeRepository;
        }


        public async Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync()
        {
            IEnumerable<ProductIndexViewModel> products = await this.productRepository
                .GetAllAttached()
                .Where(p => !p.IsDeleted)
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
                    ProductTypePropertyUnitOfMeasurementName = productTypeProperties[i].ProductTypePropertyUnitOfMeasurement,
                    ValueTypeId = productTypeProperties[i].ValueTypeId,
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
                if (int.TryParse(detailValue, out int intResult))
                {
                    detailValue = intResult == 0 ? "None" : intResult.ToString();
                }

                DetailsViewModel.ProductProperties!
                    .Add(detailKey, detailValue);
            }
            return DetailsViewModel;
        }

        public async Task<bool> AddProductAsync(CreateProductViewModel viewModel)
        {
            //Get all ProductTypeProperties with the same ProductTypeId
            IEnumerable<ProductTypeProperty> currentProductTypeProperties = await this.productTypePropertyRepository
                .GetAllAttached()
                .Where(ptp => ptp.ProductTypeId == viewModel.SelectedProductTypeId)
                .ToArrayAsync();

            Product productToAdd = new Product()
            {
                Name = viewModel.Name,
                Brand = viewModel.Brand,
                Description = viewModel.Description,
                RelaseDate = viewModel.ReleaseDate,
                ProductTypeId = viewModel.SelectedProductTypeId,
                Price = viewModel.Price,
                Weigth = viewModel.Weigth,
                WarrantyDurationInMonths = viewModel.WarrantyDurationInMonths,
                AvaibleQuantity = viewModel.AvaibleQuantity,
                //  ProductImagePath = viewModel.ProductImagePath             //TODO: implement adding an image
            };

            IEnumerable<PropertyValueType> allPropertyValueTypes = await this.propertyValueTypeRepository
                .GetAllAsync();

            bool viewModelValidResult = true;

            // Check if each Property has the right value type
            foreach (ProductTypeProperty property in currentProductTypeProperties)
            {
                string propertyValueName = allPropertyValueTypes
                    .FirstOrDefault(p => p.Id == property.ValueTypeId)!.Name;

                //Get key-value pair with given id by ProductTypeProperties
                var viewModelProperty = viewModel.ProductProperties
                    .Where(k => k.Key == property.Id)
                    .FirstOrDefault();

                bool isCurrentPropertyValid = false;
                //Check if entered values are valid, by trying to parse them
                switch (propertyValueName)
                {
                    case "IntegerValue":
                        isCurrentPropertyValid = int.TryParse(viewModelProperty.Value, out int intValue);
                        break;
                    case "DecimalValue":
                        isCurrentPropertyValid = decimal.TryParse(viewModelProperty.Value, out decimal decimalValue);
                        break;
                    case "BooleanValue":
                        isCurrentPropertyValid = bool.TryParse(viewModelProperty.Value, out bool boolValue);
                        break;
                    case "TextValue":
                        isCurrentPropertyValid = !viewModelProperty.Value.IsNullOrEmpty();
                        break;
                    default:
                        return false;
                }
                if (!isCurrentPropertyValid)
                {
                    viewModelValidResult = false;
                }
            }
            if (!viewModelValidResult)
            {
                return false;
            }

            await this.productRepository.AddAsync(productToAdd);
            await this.productRepository.SaveChangesAsync();

            //Add each ProductTypeProperty as ProductDetail after confirming that each value is valid
            foreach (ProductTypeProperty property in currentProductTypeProperties)
            {
                var viewModelProperty = viewModel.ProductProperties
                    .Where(k => k.Key == property.Id)
                    .FirstOrDefault();

                ProductDetail productDetail = new ProductDetail()
                {
                    ProductId = productToAdd.Id,
                    ProductTypePropertyId = viewModelProperty.Key,
                    ProductTypePropertyValue = viewModelProperty.Value,
                };
                await this.productDetailRepository.AddAsync(productDetail);
            }
            await this.productDetailRepository.SaveChangesAsync();

            return true;
        }

        public async Task<EditProductViewModel> GetEditProductByIdAsync(int id) // TODO: check for null product
        {
            Product? product = await this.productRepository
            .GetAllAttached()
            .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            IEnumerable<ProductTypeProperty> currentProductTypeProperties = await this.productTypePropertyRepository
                .GetAllAttached()
                .Where(ptp => ptp.ProductTypeId == product.ProductTypeId)
                .ToArrayAsync();

            IEnumerable<ProductDetail> productDetails = await this.productDetailRepository
                .GetAllAttached()
                .Where(pd => pd.ProductId == product.Id)
                .ToArrayAsync();

            ProductType? productType = await this.productTypeRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(pt => pt.Id == product.ProductTypeId);



            EditProductViewModel? editViewModel = new EditProductViewModel()
            {
                ProductId = id,
                Name = product!.Name,
                Brand = product.Brand,
                Description = product.Description,
                ReleaseDate = product.RelaseDate,
                Price = product.Price,
                WarrantyDurationInMonths = product.WarrantyDurationInMonths,
                AvaibleQuantity = product.AvaibleQuantity,
                Weigth = product.Weigth,
                ProductImagePath = product.ProductImagePath,
                SelectedProductTypeId = product.ProductTypeId,
                DropDownList = await LoadAllProductTypesDropDownList(),
            };

            HashSet<EditPropertyField> PropertyFields = new HashSet<EditPropertyField>();

            foreach (ProductTypeProperty property in currentProductTypeProperties) //Load each property field
            {
                EditPropertyField currentField = new EditPropertyField()
                {
                    PropertyId = property.Id,
                    ProductTypePropertyName = property.ProductTypePropertyName,
                    ProductTypePropertyUnitOfMeasurementName = property.ProductTypePropertyUnitOfMeasurement,
                    ValueTypeId = property.ValueTypeId,
                    Value = productDetails
                        .FirstOrDefault(pd => pd.ProductTypePropertyId == property.Id)!
                        .ProductTypePropertyValue
                };
                PropertyFields.Add(currentField);
            }
            editViewModel.ProductTypeProperties = PropertyFields;
            return editViewModel;
        }

        public async Task<IEnumerable<ProductTypeDropDownListViewModel>> LoadAllProductTypesDropDownList()
        {
            IEnumerable<ProductType> productTypes = await this.productTypeRepository
                 .GetAllAsync();

            HashSet<ProductTypeDropDownListViewModel> dropDownList = new HashSet<ProductTypeDropDownListViewModel>();

            foreach (ProductType type in productTypes)
            {
                ProductTypeDropDownListViewModel model = new ProductTypeDropDownListViewModel()
                {
                    ProductTypeId = type.Id,
                    ProductTypeName = type.Name
                };
                dropDownList.Add(model);
            }

            return dropDownList;
        }

        public async Task<bool> UpdateEditedProductAsync(EditProductViewModel viewModel)
        {
            if (viewModel == null)
            {
                return false;
            }

            Product productToEdit = new Product()
            {
                Id = viewModel.ProductId,
                Name = viewModel.Name,
                Brand = viewModel.Brand,
                Description = viewModel.Description,
                RelaseDate = viewModel.ReleaseDate,
                ProductTypeId = viewModel.SelectedProductTypeId,
                ProductImagePath = viewModel.ProductImagePath,
                Price = viewModel.Price,
                Weigth = viewModel.Weigth,
                WarrantyDurationInMonths = viewModel.WarrantyDurationInMonths,
                AvaibleQuantity = viewModel.AvaibleQuantity
            };

            bool wasProductEdited = await this.productRepository
                .UpdateAsync(productToEdit);
            if (wasProductEdited)
            {
                await productRepository.SaveChangesAsync();
            }

            return wasProductEdited;
        }

        public async Task<bool> SoftDeleteProductByIdAsync(int id)
        {
            Product productToDelete = await this.productRepository
                .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == id.ToString().ToLower());

            if (productToDelete == null)
            {
                return false;
            }
            productToDelete.IsDeleted = true;

            bool wasProductDeleted = await this.productRepository
                .UpdateAsync(productToDelete);

            if (wasProductDeleted)
            {
                await productRepository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
