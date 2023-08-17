using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;

namespace BcgxCodingChallenge.Test;

public class ShoppingControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ShoppingControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HappyPath()
    {
        // Arrange
        var client = _factory.CreateClient();
        var content = "[\"001\",\"002\",\"001\",\"004\",\"003\"]";
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            Content = new StringContent(content, Encoding.UTF8, "application/json"),
            RequestUri = new Uri(client.BaseAddress + "shopping/" + "checkout")
        };

        // Act
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }

    [Fact]
    public void LargeInput()
    {

    }

    [Fact]
    public void InvalidInputOne()
    {

    }

    [Fact]
    public void InvalidInputTwo()
    {

    }

    [Fact]
    public void InvalidInputThree()
    {

    }
}