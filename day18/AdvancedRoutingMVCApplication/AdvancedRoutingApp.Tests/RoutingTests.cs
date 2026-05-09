using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class RoutingTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public RoutingTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ComplexRoute_Products_ReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Products/Electronics/101");
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GuidConstraint_ValidGuid_ReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Reports/3f2504e0-4f89-11d3-9a0c-0305e82c3301");
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GuidConstraint_InvalidGuid_Returns404()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Reports/not-a-guid");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}