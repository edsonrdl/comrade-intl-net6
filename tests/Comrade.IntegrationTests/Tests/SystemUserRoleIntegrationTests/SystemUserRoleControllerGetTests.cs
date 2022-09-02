using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserRoleIntegrationTests;

public class SystemUserRoleControllerGetTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemUserRoleControllerGetTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemUserRoleController_Get()
    {
        var systemUserRoleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
        var systemUserRoleController =
            SystemUserRoleInjectionController.GetSystemUserRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await systemUserRoleController.GetById(systemUserRoleId);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<SystemUserRoleDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
        }
    }
}