using System;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Xunit;

namespace Comrade.IntegrationTests.Tests.RoleIntegrationTests;

public class RoleContextTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public RoleContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task Role_Context()
    {
        var roleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        var repository = new RoleRepository(_fixture.SqlContextFixture);
        var role = await repository.GetById(roleId);
        Assert.NotNull(role);
    }
}