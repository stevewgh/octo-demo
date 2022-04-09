using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Octo.Demo.Api.Tests;

public class ApiTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ApiTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    [Fact]
    public async Task Get_Weather_Forecast_Test()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/weatherforecast");
        var forecast = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        Assert.Equal(5, forecast!.Count());
    }

    private record WeatherForecast(DateTime Date, int TemperatureC, int TemperatureF, string? Summary);
}