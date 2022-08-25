using System.Net.Http;
using System.Text;
using Comrade.Core.Messages;
using Comrade.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Comrade.ComponentTests.V1.RoleApi;

public class RoleComponentCreateErrorTests : IClassFixture<CustomWebApplicationFactoryFixture>
{
    private readonly CustomWebApplicationFactoryFixture _fixture;

    public RoleComponentCreateErrorTests(CustomWebApplicationFactoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateErrorRole()
    {
        var client = _fixture.CustomWebApplicationFactory.CreateClient();
        var token = await GenerateFakeToken.Execute(_fixture.Mediator);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new Role("adm")), Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var actualResponse = await client.PostAsync("/api/v1/role/create", httpContent).ConfigureAwait(false);
        var actualResponseString = await actualResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.Conflict, actualResponse.StatusCode);

        using StringReader stringReader = new(actualResponseString);
        using JsonTextReader reader = new(stringReader) { DateParseHandling = DateParseHandling.None };
        var jsonResponse = await JObject.LoadAsync(reader).ConfigureAwait(false);

        Assert.Equal(BusinessMessage.MSG13, jsonResponse["message"]);
    }
}