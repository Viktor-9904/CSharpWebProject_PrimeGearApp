using Moq;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data;
using PrimeGearApp.Services.Data.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PrimeGearApp.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IRepository<ApplicationUser, Guid>> _mockUserRepository;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            // Arrange: Initialize mocks and service.
            _mockUserRepository = new Mock<IRepository<ApplicationUser, Guid>>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange: Prepare the data for the test.
            var userId = Guid.NewGuid();
            var expectedUser = new ApplicationUser
            {
                Id = userId,
                UserName = "testUser",
                Email = "test@example.com"
            };

            // Setup mock to return a valid user.
            _mockUserRepository
                .Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync(expectedUser);

            // Act: Call the service method.
            var result = await _userService.GetUserById(userId);

            // Assert: Verify the results.
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(expectedUser.Id));
            Assert.That(result.UserName, Is.EqualTo(expectedUser.UserName));
            Assert.That(result.Email, Is.EqualTo(expectedUser.Email));
        }

        [Fact]
        public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange: Prepare the data for the test.
            var userId = Guid.NewGuid();

            // Setup mock to return null (user not found).
            _mockUserRepository
                .Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync((ApplicationUser)null);

            // Act: Call the service method.
            var result = await _userService.GetUserById(userId);

            // Assert: Verify the results.
            Assert.Null(result);
        }
    }
}
