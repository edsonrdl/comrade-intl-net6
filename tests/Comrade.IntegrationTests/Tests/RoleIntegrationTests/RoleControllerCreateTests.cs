using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.RoleTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.RoleIntegrationTests;

public sealed class RoleControllerCreateTests : IClassFixture<ServiceProviderFixture>
{
    public RoleControllerCreateTests()
    {
    }

    [Fact]
    public async Task RoleController_Create()
    {
        var fixture = new ServiceProviderFixture();
        InjectDataOnContextBase.InitializeDbForTests(fixture.SqlContextFixture);

        var testObject = new RoleCreateDto
        {
            Name = "edboy",
           
        };

        var roleController =
            RoleInjectionController.GetRoleController(fixture.SqlContextFixture,
                fixture.MongoDbContextFixture,
                fixture.Mediator);

        var result = await roleController.Create(testObject);
       
        if (result is ObjectResult okResult)
        {
            
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(201, actualResultValue?.Code);
        }
    }


    [Fact]
    public async Task RoleController_Create_Error()
    {
        var fixture = new ServiceProviderFixture();
        InjectDataOnContextBase.InitializeDbForTests(fixture.SqlContextFixture);

        var testObject = new RoleCreateDto
        {
            Name = " adm ",
            
        };

        var roleController =
            RoleInjectionController.GetRoleController(fixture.SqlContextFixture,
                fixture.MongoDbContextFixture,
                fixture.Mediator);

        var result = await roleController.Create(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.Equal(409, actualResultValue?.Code);
        }
    }
}