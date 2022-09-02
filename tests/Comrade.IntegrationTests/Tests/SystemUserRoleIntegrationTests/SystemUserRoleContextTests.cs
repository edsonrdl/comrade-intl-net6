using System;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserRoleIntegrationTests;

public class SystemUserRoleContextTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemUserRoleContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemUserRole_Context()
    {
        var systemUserRoleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
        var repository = new SystemUserRoleRepository(_fixture.SqlContextFixture);
        var systemUserRole = await repository.GetById(systemUserRoleId);
        Assert.NotNull(systemUserRole);
    }
}