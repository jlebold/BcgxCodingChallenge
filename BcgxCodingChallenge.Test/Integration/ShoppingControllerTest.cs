using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;

namespace BcgxCodingChallenge.Test.Integration;

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
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal("{ \"price\": 360 }", responseContent);
    }

    /// <summary>
    /// • There is no limit to the number of items or combinations of watches a user can checkout.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task LargeInput()
    {
        // Arrange
        var client = _factory.CreateClient();
        var content = "[";
        for (int i = 0; i < 100000; i++)
        {
            content += "\"001\",\"002\",\"001\",\"004\",\"003\",";
        }

        content += "\"001\"]";
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            Content = new StringContent(content, Encoding.UTF8, "application/json"),
            RequestUri = new Uri(client.BaseAddress + "shopping/" + "checkout")
        };

        // Act
        var response = await client.SendAsync(request);

        // Assert
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal("{ \"price\": 27333400 }", responseContent);
    }
}