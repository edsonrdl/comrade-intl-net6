using System;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.UnitTests.Tests.SystemPermissionTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemPermissionIntegrationTests;

public sealed class SystemPermissionControllerCreateTests : IClassFixture<ServiceProviderFixture>
{
    
    [Fact]
    public async Task SystemPermissionController_Create()
    {
        var fixture = new ServiceProviderFixture();
        var testObject = new SystemPermissionCreateDto
        {
            Id= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5"),
            Name= "abacaxi",
            Tag= "lasanha"
        };

        var systemUserSystemPermissionController =
            SystemPermissionInjectionController.GetSystemPermissionController(fixture.SqlContextFixture,
                fixture.MongoDbContextFixture,
                fixture.Mediator);

        var result = await systemUserSystemPermissionController.Create(testObject);
       
        if (result is ObjectResult okResult)
        {
            
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(201, actualResultValue.Code);
        }
    }

}