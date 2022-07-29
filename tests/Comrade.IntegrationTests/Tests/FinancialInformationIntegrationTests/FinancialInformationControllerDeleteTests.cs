﻿using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using System;
using Comrade.Application.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationControllerDeleteTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerDeleteTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task FinancialInformationController_Delete()
    {
        //Preparação
        var financialInformationId = new Guid("6adf10d0-1b83-46f2-91eb-0c64f1c638a5");

        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture, _fixture.Mediator);

        //Execução
        var result = await financialInformationController.Delete(financialInformationId);
        var repository = new FinancialInformationRepository(_fixture.SqlContextFixture);
        var financialInformation = await repository.GetById(financialInformationId);

        //Assert/Validação
        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(200, actualResultValue?.Code);
        }
        Assert.Null(financialInformation);
    }
}