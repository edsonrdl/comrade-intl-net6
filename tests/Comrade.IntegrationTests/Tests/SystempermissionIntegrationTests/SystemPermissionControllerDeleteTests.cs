using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemPermissionTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemPermissionIntegrationTests;

public class SystemPermissionControllerDeleteTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemPermissionControllerDeleteTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemPermissionController_Delete()
    {
        var systemPermissionId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");

        var systemPermissionController =
            SystemPermissionInjectionController.GetSystemPermissionController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        _ = await systemPermissionController.Delete(systemPermissionId);

        var repository = new SystemPermissionRepository(_fixture.SqlContextFixture);
        var systemPermission = await repository.GetById(systemPermissionId);
        Assert.Null(systemPermission);
    }
}