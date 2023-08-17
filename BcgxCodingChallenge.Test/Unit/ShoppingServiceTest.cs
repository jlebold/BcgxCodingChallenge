using BcgxCodingChallenge.DataAccess.Repositories;
using BcgxCodingChallenge.Models.Dtos;
using BcgxCodingChallenge.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace BcgxCodingChallenge.Test.Unit;

public class ShoppingServiceTest
{
    private readonly ShoppingService _shoppingService;
    private readonly Mock<IWatchRepository> _watchRepository;

    public ShoppingServiceTest()
    {
        var logger = new Mock<ILogger<ShoppingService>>();
        _watchRepository = new Mock<IWatchRepository>();

        var exampleWatchDtos = new List<WatchDto>()
        {
            new ()
            {
                Code = "001",
                Price = 100,
                DiscountPrice = 200,
                DiscountUnits = 3
            },
            new ()
            {
                Code = "002",
                Price = 80,
                DiscountPrice = 120,
                DiscountUnits = 2
            },
            new ()
            {
                Code = "003",
                Price = 50
            },
            new ()
            {
                Code = "004",
                Price = 30
            }
        };

        _watchRepository.Setup(x => x.GetAll()).Returns(exampleWatchDtos);
        _shoppingService = new ShoppingService(_watchRepository.Object, logger.Object);
    }

    [Fact]
    public void HappyPath_NoDiscounts()
    {
        // Arrange
        var input = new List<string>() { "001", "002", "001", "003", "004" };

        // Act
        var result = _shoppingService.CalculateCost(input);

        // Assert
        _watchRepository.Verify(x => x.GetAll(), Times.Once());
        Assert.True(result == "{ \"price\": 360 }");
    }

    [Fact]
    public void HappyPath_WithDiscounts()
    {
        // Arrange
        var input = new List<string>() { "001", "002", "001", "001", "003", "004", "002" };

        // Act
        var result = _shoppingService.CalculateCost(input);

        // Assert
        _watchRepository.Verify(x => x.GetAll(), Times.Once());
        Assert.True(result == "{ \"price\": 400 }");
    }

    [Fact]
    public void EmptyInput_ReturnsZero()
    {
        // Arrange
        var input = new List<string>() { };

        // Act
        var result = _shoppingService.CalculateCost(input);

        // Assert
        _watchRepository.Verify(x => x.GetAll(), Times.Once());
        Assert.True(result == "{ \"price\": 0 }");
    }

    [Fact]
    public void InvalidInput_ReturnsNull()
    {
        // Arrange
        var input = new List<string>() { "001", "0001", "002" };

        // Act
        var result = _shoppingService.CalculateCost(input);

        // Assert
        _watchRepository.Verify(x => x.GetAll(), Times.Never());
        Assert.True(result == null);
    }
}
