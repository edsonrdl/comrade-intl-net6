using System;
using Comrade.Application.Bases;
using Comrade.Application.Components.SystemMenuComponent.Contracts;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemMenuTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemMenuIntegrationTests;

public sealed class SystemMenuControllerEditTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemMenuControllerEditTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }


    [Fact]
    public async Task SystemMenuController_Edit()
    {
        var systemMenuId = new Guid("6adf10d0-1b83-46f2-91eb-0c64f1c638a6");
        const string systemMenuText = "Main Teste Edit";
        const string systemMenuDescription = "Description Main Teste Edit";
        const int systemMenuOrder = 1;
        const string systemMenuRoute = "/teste";

        var testObject = new SystemMenuEditDto
        {
            Id = systemMenuId,
            Text = systemMenuText,
            Description = systemMenuDescription,
            Order = systemMenuOrder,
            Route = systemMenuRoute
        };

        var systemMenuController =
            SystemMenuInjectionController.GetSystemMenuController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);

        var result = await systemMenuController.Edit(testObject);

        if (result is ObjectResult objectResult)
        {
            var actualResultValue = objectResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(204, actualResultValue?.Code);
        }

        var repository = new SystemMenuRepository(_fixture.SqlContextFixture);
        var systemMenu = await repository.GetById(systemMenuId);
        Assert.Equal(systemMenuOrder, systemMenu!.Order);
        Assert.Equal(systemMenuRoute, systemMenu.Route);
        Assert.Equal(systemMenuText, systemMenu.Text);
        Assert.Equal(systemMenuDescription, systemMenu.Description);
    }
}