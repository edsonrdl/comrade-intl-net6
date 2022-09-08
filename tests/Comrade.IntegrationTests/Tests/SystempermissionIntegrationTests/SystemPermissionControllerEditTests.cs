using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemPermissionTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemPermissionIntegrationTests;

public class SystemPermissionControllerEditTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemPermissionControllerEditTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemPermissionController_Edit()
    {
        
        var changeId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9");
        var changeName = "lasanha";
        var changerTag = " mortadela";


        var systemPermissionId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");

        var testObject = new SystemPermissionEditDto
        {
            Id = systemPermissionId,
            Name = changeName,
            Tag = changerTag,
          

        };

        var systemPermissionController =
            SystemPermissionInjectionController.GetSystemPermissionController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await systemPermissionController.Edit(testObject);

        if (result is ObjectResult objectResult)
        {
            var actualResultValue = objectResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(204, actualResultValue?.Code);
        }

        var repository = new SystemPermissionRepository(_fixture.SqlContextFixture);
        var systemPermission = await repository.GetById(systemPermissionId);
    
        Assert.Equal(changeName, systemPermission!.Name);
        Assert.Equal(changerTag, systemPermission!.Tag);

    }
}