using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemPermissionTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemPermissionIntegrationTests;

public class SystemPermissionControllerGetTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemPermissionControllerGetTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemPermissionController_Get()
    {
        var systemPermissionId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
        var systemPermissionController = SystemPermissionInjectionController.GetSystemPermissionController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await systemPermissionController.GetById(systemPermissionId);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<SystemPermissionDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
        }
    }
}