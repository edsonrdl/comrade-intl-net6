using System.Net.Http;
using System.Text;
using Comrade.Core.Messages;
using Comrade.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Comrade.ComponentTests.V1.SystemUserRoleApi;

public class SystemUserRoleComponentCreateTests : IClassFixture<CustomWebApplicationFactoryFixture>
{
    private readonly CustomWebApplicationFactoryFixture _fixture;

    public SystemUserRoleComponentCreateTests(CustomWebApplicationFactoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateSystemUserRole()
    {
        var client = _fixture.CustomWebApplicationFactory.CreateClient();
        var token = await GenerateFakeToken.Execute(_fixture.Mediator);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var systemUserRole = new SystemUserRole
        {
            SystemUserId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9") ,
            RoleId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9") 
        };


        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(systemUserRole), Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var actualResponse = await client.PostAsync("/api/v1/system-user-role/create", httpContent).ConfigureAwait(false);
        var actualResponseString = await actualResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.Created, actualResponse.StatusCode);

        using StringReader stringReader = new(actualResponseString);
        using JsonTextReader reader = new(stringReader) { DateParseHandling = DateParseHandling.None };
        var jsonResponse = await JObject.LoadAsync(reader).ConfigureAwait(false);

        Assert.Equal(BusinessMessage.MSG01, jsonResponse["message"]);
    }
}