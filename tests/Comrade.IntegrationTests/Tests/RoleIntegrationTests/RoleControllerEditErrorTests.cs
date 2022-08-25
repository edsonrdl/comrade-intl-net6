using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.RoleTests.Bases;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.RoleIntegrationTests;

public class RoleControllerEditErrorTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public RoleControllerEditErrorTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task RoleController_Edit_Error()
    {
        var changeName = "adm";
     
        var roleId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        var testObject = new RoleEditDto
        {
            Id = roleId,
            Name = changeName,
        };

        var roleController =
            RoleInjectionController.GetRoleController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await roleController.Edit(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(409, actualResultValue?.Code);
        }

        var repository = new RoleRepository(_fixture.SqlContextFixture);
        var role = await repository.GetById(roleId);
        Assert.NotEqual(changeName, role!.Name);
        
    }
}
