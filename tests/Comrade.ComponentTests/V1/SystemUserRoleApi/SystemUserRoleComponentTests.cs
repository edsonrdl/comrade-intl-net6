using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Comrade.ComponentTests.V1.SystemUserRoleApi;

public class SystemUserRoleComponentTests : IClassFixture<CustomWebApplicationFactoryFixture>
{
    private readonly CustomWebApplicationFactoryFixture _fixture;

    public SystemUserRoleComponentTests(CustomWebApplicationFactoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetSystemUserRoleReturnsList()
    {
        var client = _fixture
            .CustomWebApplicationFactory
            .CreateClient();

        var token = await GenerateFakeToken.Execute(_fixture.Mediator);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var actualResponse = await client
            .GetAsync("api/v1/system-user-role/get-all")
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

        Assert.Equal(JTokenType.String, jsonResponse["data"]![0]!["systemUserId"]!.Type);
        Assert.Equal(JTokenType.String, jsonResponse["data"]![0]!["roleId"]!.Type);

    }
}