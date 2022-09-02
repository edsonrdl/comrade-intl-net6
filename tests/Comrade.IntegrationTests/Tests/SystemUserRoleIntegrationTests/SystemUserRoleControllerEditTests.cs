using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserRoleIntegrationTests;

public class SystemUserRoleControllerEditTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemUserRoleControllerEditTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemUserRoleController_Edit()
    {
        
        var changeSystemUserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9");
        var changeRoleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9");


        var systemUserRoleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");

        var testObject = new SystemUserRoleEditDto
        {
            Id = systemUserRoleId,
            SystemUserId = changeSystemUserId,
            RoleId = changeRoleId,
          

        };

        var systemUserRoleController =
            SystemUserRoleInjectionController.GetSystemUserRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await systemUserRoleController.Edit(testObject);

        if (result is ObjectResult objectResult)
        {
            var actualResultValue = objectResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(204, actualResultValue?.Code);
        }

        var repository = new SystemUserRoleRepository(_fixture.SqlContextFixture);
        var systemUserRole = await repository.GetById(systemUserRoleId);
    
        Assert.Equal(changeSystemUserId, systemUserRole!.SystemUserId);
        Assert.Equal(changeRoleId, systemUserRole!.RoleId);

    }
}