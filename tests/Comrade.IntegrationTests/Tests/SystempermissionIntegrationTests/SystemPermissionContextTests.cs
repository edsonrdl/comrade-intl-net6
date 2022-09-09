using System;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemPermissionTests.Bases;
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
    [Fact]
    public async Task SystemPermissionController_Create_Error()
    {
        var fixture = new ServiceProviderFixture();
        InjectDataOnContextBase.InitializeDbForTests(fixture.SqlContextFixture);

        var testObject = new SystemPermissionCreateDto
        {
            Name = " adm ",
            Tag = " LEite ",

        };

        var systemPermissionController =
            SystemPermissionInjectionController.GetSystemPermissionController(fixture.SqlContextFixture,
                fixture.MongoDbContextFixture,
                fixture.Mediator);

        var result = await systemPermissionController.Create(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.Equal(409, actualResultValue?.Code);
        }
    }
}