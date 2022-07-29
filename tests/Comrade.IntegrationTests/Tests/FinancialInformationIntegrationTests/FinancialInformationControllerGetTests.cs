using Comrade.Application.Bases;
using Comrade.UnitTests.DataInjectors;
using System;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationControllerGetTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerGetTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task FinancialInformationController_Get()
    {
        var financialInformationId = new Guid("4d4c2560-f7f2-4bcf-83aa-f932b17ed47f");
        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await financialInformationController.GetById(financialInformationId);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<FinancialInformationDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
            Assert.NotNull(actualResultValue?.Data);
        }
    }
}