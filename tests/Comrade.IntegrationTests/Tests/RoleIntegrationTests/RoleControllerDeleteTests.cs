using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.RoleTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.RoleIntegrationTests;

public class RoleControllerDeleteTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public RoleControllerDeleteTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task RoleController_Delete()
    {
        var roleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        var roleController =
            RoleInjectionController.GetRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        _ = await roleController.Delete(roleId);

        var repository = new RoleRepository(_fixture.SqlContextFixture);
        var role = await repository.GetById(roleId);
        Assert.Null(role);
    }
}