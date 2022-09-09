using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Comrade.ComponentTests.V1.SystemPermissionApi;

public class SystemPermissionComponentTests : IClassFixture<CustomWebApplicationFactoryFixture>
{
    private readonly CustomWebApplicationFactoryFixture _fixture;

    public SystemPermissionComponentTests(CustomWebApplicationFactoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetSystemPermissionReturnsList()
    {
        var client = _fixture
            .CustomWebApplicationFactory
            .CreateClient();

        var token = await GenerateFakeToken.Execute(_fixture.Mediator);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var actualResponse = await client
            .GetAsync("api/v1/system-permission/get-all")
            .ConfigureAwait(false);

        var actualResponseString = await actualResponse.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);

        using StringReader stringReader = new(actualResponseString);
        using JsonTextReader reader = new(stringReader)
            { DateParseHandling = DateParseHandling.None };
        var jsonResponse = await JObject.LoadAsync(reader)
            .ConfigureAwait(false);

        Assert.Equal(JTokenType.String, jsonResponse["data"]![0]!["name"]!.Type);
        Assert.Equal(JTokenType.String, jsonResponse["data"]![0]!["tag"]!.Type);

    }
}