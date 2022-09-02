using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserRoleIntegrationTests;

public class SystemUserRoleControllerDeleteTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemUserRoleControllerDeleteTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemUserRoleController_Delete()
    {
        var systemUserRoleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");

        var systemUserRoleController =
            SystemUserRoleInjectionController.GetSystemUserRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        _ = await systemUserRoleController.Delete(systemUserRoleId);

        var repository = new SystemUserRoleRepository(_fixture.SqlContextFixture);
        var systemUserRole = await repository.GetById(systemUserRoleId);
        Assert.Null(systemUserRole);
    }
}