using System;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemPermissionIntegrationTests;

public class SystemPermissionContextTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemPermissionContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemPermission_Context()
    {
        var systemPermissionId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
        var repository = new SystemPermissionRepository(_fixture.SqlContextFixture);
        var systemPermission = await repository.GetById(systemPermissionId);
        Assert.NotNull(systemPermission);
    }
}