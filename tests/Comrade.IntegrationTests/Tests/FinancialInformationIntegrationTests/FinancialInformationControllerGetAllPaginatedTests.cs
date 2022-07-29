using System;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationControllerGetAllPaginatedTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerGetAllPaginatedTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task FinancialInformationController_GetAll_Paginated()
    {
        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var paginationQuery = new PaginationQuery();
        var result = await financialInformationController.GetAll(paginationQuery);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as PageResultDto<FinancialInformationDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
            Assert.Equal(3, actualResultValue?.Data?.Count);
        }
    }
}