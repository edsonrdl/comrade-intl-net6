﻿using System.Net.Http;
using System.Text;
using Comrade.Core.Messages;
using Comrade.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Comrade.ComponentTests.V1.RoleApi;

public class RoleComponentEditTests : IClassFixture<CustomWebApplicationFactoryFixture>
{
    [Fact]
    public async Task EditRole()
    {
        var fixture = new CustomWebApplicationFactoryFixture();
        var client = fixture.CustomWebApplicationFactory.CreateClient();
        var token = await GenerateFakeToken.Execute(fixture.Mediator);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var role = new Role
        {
            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            Name = "ROLE"
        };

        HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var actualResponse = await client.PutAsync("/api/v1/role/edit", httpContent).ConfigureAwait(false);
        var actualResponseString = await actualResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

        Assert.Equal(HttpStatusCode.NoContent, actualResponse.StatusCode);

        using StringReader stringReader = new(actualResponseString);
        using JsonTextReader reader = new(stringReader) { DateParseHandling = DateParseHandling.None };
        var jsonResponse = await JObject.LoadAsync(reader).ConfigureAwait(false);

        Assert.Equal(BusinessMessage.MSG02, jsonResponse["message"]);
    }
}