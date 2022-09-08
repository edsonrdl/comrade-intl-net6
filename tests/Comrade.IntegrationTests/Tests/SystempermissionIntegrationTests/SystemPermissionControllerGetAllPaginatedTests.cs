using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemPermissionTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemPermissionIntegrationTests;

public class SystemPermissionControllerGetAllPaginatedTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public SystemPermissionControllerGetAllPaginatedTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task SystemPermissionController_GetAll_Paginated()
    {
        var systemPermissionController =
            SystemPermissionInjectionController.GetSystemPermissionController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var paginationQuery = new PaginationQuery();
        var result = await systemPermissionController.GetAll(paginationQuery);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as PageResultDto<SystemPermissionDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
            Assert.Equal(1, actualResultValue?.Data?.Count);
        }
    }
}