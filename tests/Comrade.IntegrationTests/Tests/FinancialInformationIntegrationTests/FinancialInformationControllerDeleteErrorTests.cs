using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using System;
using Comrade.Application.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationControllerDeleteErrorTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerDeleteErrorTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task FinancialInformationController_Delete_Error()
    {
        var financialInformationId = Guid.NewGuid();

        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture, _fixture.Mediator);
        var result = await financialInformationController.Delete(financialInformationId);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(404, actualResultValue?.Code);
        }
    }
}