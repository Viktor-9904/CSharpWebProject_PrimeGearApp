using Moq;
using NUnit.Framework;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data;
using PrimeGearApp.Web.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimeGearApp.Services.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IRepository<Product, int>> productRepository;
        private Mock<IRepository<ProductDetail, int>> productDetailRepository;
        private Mock<IRepository<ProductType, int>> productTypeRepository;
        private Mock<IRepository<ProductTypeProperty, int>> productTypePropertyRepository;
        private Mock<IRepository<PropertyValueType, int>> propertyValueTypeRepository;
        private Mock<IRepository<UserFavoriteProduct, int>> userFavoriteProductRepository;
        private ProductService productService;

        [SetUp]
        public void Setup()
        {
            this.productRepository = new Mock<IRepository<Product, int>>();
            this.productDetailRepository = new Mock<IRepository<ProductDetail, int>>();
            this.productTypeRepository = new Mock<IRepository<ProductType, int>>();
            this.productTypePropertyRepository = new Mock<IRepository<ProductTypeProperty, int>>();
            this.propertyValueTypeRepository = new Mock<IRepository<PropertyValueType, int>>();
            this.userFavoriteProductRepository = new Mock<IRepository<UserFavoriteProduct, int>>();

            this.productService = new ProductService(
                productRepository.Object,
                productDetailRepository.Object,
                productTypeRepository.Object,
                productTypePropertyRepository.Object,
                propertyValueTypeRepository.Object,
                userFavoriteProductRepository.Object);
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Brand = "Brand 1", Price = 100, AvaibleQuantity = 10, IsDeleted = false },
                new Product { Id = 2, Name = "Product 2", Brand = "Brand 2", Price = 200, AvaibleQuantity = 5, IsDeleted = false }
            };

            this.productRepository.Setup(repo => repo.GetAllAttached())
                .Returns(products.AsQueryable());

            // Act
            var result = await this.productService.GetAllProductsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Product 1", result.First().Name);
            Assert.AreEqual("Product 2", result.Last().Name);
        }

        [Test]
        public async Task GetProductDetailByIdAsync_ShouldReturnProductDetails()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1", Brand = "Brand 1", Price = 100, AvaibleQuantity = 10, IsDeleted = false };
            var productDetails = new List<ProductDetail>
            {
                new ProductDetail { ProductId = 1, ProductTypePropertyId = 1, ProductTypePropertyValue = "Value 1" }
            };

            this.productRepository.Setup(repo => repo.GetAllAttached())
                .Returns(new List<Product> { product }.AsQueryable());

            this.productDetailRepository.Setup(repo => repo.GetAllAttached())
                .Returns(productDetails.AsQueryable());

            // Act
            var result = await this.productService.GetProductDetailByIdAsync(1, string.Empty);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Product 1", result.Name);
            Assert.IsTrue(result.ProductProperties.ContainsKey("Value 1"));
        }

        [Test]
        public async Task AddProductAsync_ShouldReturnTrue_WhenProductIsAddedSuccessfully()
        {
            // Arrange
            var newProduct = new CreateProductViewModel
            {
                Name = "New Product",
                Brand = "Brand X",
                Price = 150,
                AvaibleQuantity = 20,
                SelectedProductTypeId = 1,
                ProductProperties = new Dictionary<int, string>
                {
                    { 1, "100" }
                }
            };

            this.productTypePropertyRepository.Setup(repo => repo.GetAllAttached())
                .Returns(new List<ProductTypeProperty> { new ProductTypeProperty { Id = 1, ProductTypeId = 1, ValueTypeId = 1 } }.AsQueryable());

            this.propertyValueTypeRepository.Setup(repo => repo.GetAllAttached())
                .Returns(new List<PropertyValueType> { new PropertyValueType { Id = 1, Name = "IntegerValue" } }.AsQueryable());

            this.productRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);
            this.productRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await this.productService.AddProductAsync(newProduct);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task SoftDeleteProductByIdAsync_ShouldReturnTrue_WhenProductIsDeleted()
        {
            // Arrange
            var product = new Product { Id = 1, IsDeleted = false };
            this.productRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                            .ReturnsAsync(product);
            this.productRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
                .Returns(Task.FromResult(true));

            this.productRepository.Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await this.productService.SoftDeleteProductByIdAsync(1);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(product.IsDeleted);
        }
    }
}
