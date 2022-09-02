using System;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserRoleIntegrationTests;

public sealed class SystemUserRoleControllerCreateTests : IClassFixture<ServiceProviderFixture>
{
    
    [Fact]
    public async Task SystemUserRoleController_Create()
    {
        var fixture = new ServiceProviderFixture();
        var testObject = new SystemUserRoleCreateDto
        {
            SystemUserId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5"),
            RoleId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5")
        };

        var systemUserSystemUserRoleController =
            SystemUserRoleInjectionController.GetSystemUserRoleController(fixture.SqlContextFixture,
                fixture.MongoDbContextFixture,
                fixture.Mediator);

        var result = await systemUserSystemUserRoleController.Create(testObject);
       
        if (result is ObjectResult okResult)
        {
            
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(201, actualResultValue.Code);
        }
    }

}