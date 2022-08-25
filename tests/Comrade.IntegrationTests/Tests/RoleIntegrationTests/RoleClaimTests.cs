using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.UnitTests.Tests.RoleTests.Bases;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Xunit;

namespace Comrade.IntegrationTests.Tests.RoleIntegrationTests;

public class RoleClaimTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public RoleClaimTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task Role_Claim()
    {
        var roleController =
            RoleInjectionController.GetRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);

        var testObject = new RoleCreateDto
        {
            Name = "lasanha",
           
        };

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "userName"),
            new(ClaimTypes.NameIdentifier, "userId"),
            new("Name", "User Name"),
            new("Key", "1")
        };

        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        roleController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = claimsPrincipal }
        };

        var result = await roleController.Create(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(201, actualResultValue?.Code);
        }
    }
}