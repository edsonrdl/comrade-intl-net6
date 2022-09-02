using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserRoleIntegrationTests;

public class SystemUserRoleControllerGetAllTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemUserRoleControllerGetAllTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemUserRoleController_GetAll()
    {
        var systemUserSystemUserRoleController =
            SystemUserRoleInjectionController.GetSystemUserRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await systemUserSystemUserRoleController.GetAll(null);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as PageResultDto<SystemUserRoleDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
            Assert.Equal(1, actualResultValue?.Data?.Count);
        }
    }
}