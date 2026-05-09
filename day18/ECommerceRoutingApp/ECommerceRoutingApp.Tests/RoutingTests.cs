using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class RoutingTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public RoutingTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task ProductDetails_Route_Works()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Products/Mobile/5");
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task PriceConstraint_ValidRange_Works()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Products/Filter/Electronics/100-500");
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task PriceConstraint_InvalidRange_Returns404()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Products/Filter/Electronics/500-100");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}