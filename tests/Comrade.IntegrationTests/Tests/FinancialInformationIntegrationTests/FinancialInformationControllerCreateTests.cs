using System;
using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Domain.Enums;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public sealed class FinancialInformationControllerCreateTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerCreateTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task FinancialInformationController_Create()
    {
        //Prepara��o
        var testObject = new FinancialInformationCreateDto
        {
            Type = EnumTypeFinancial.ReceiptDoc,
            DateTime = new DateTime(2019 / 04 / 01),
            Value = 1000,
            Cpf = "85638445573",
            Card = "856384455731",
            Shop = "caf�",
            Store = "cafeteria "
        };
        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);

        //Execu��o
        var result = await financialInformationController.Create(testObject);

        //Assert / Verifica��o
        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.Equal(201, actualResultValue?.Code);
        }
    }


    [Fact]
    public async Task FinancialInformationController_Create_Error()
    {
        var testObject = new FinancialInformationCreateDto
        {
            Type = null,
            DateTime = new DateTime(2019 / 04 / 01),
            Value = 234,
            Cpf = "84455",
            Card = "8473",
            Shop = "caf�",
            Store = "cafeteria "
        };

        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);

        var result = await financialInformationController.Create(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(409, actualResultValue?.Code);
        }
    }
    
}