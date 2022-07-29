using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using System;
using Comrade.Domain.Enums;
using DocumentFormat.OpenXml.Office2010.Excel;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationControllerEditTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerEditTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task FinancialInformationController_Edit()
    {
        //var changeName = "new name";
        //var changeEmail = "novo@email.com";
        //var changePassword = "NovaPassword";
        //var changeRegistration = "NovaRegistration";
        //"id": "6adf10d0-1b83-46f2-91eb-0c64f1c638a5",
        //"type": 1,
        //"dateTime": "2019/04/01",
        //"value": 234,
        //"cpf": "84455254073",
        //"card": "8473****1381",
        //"shop": "café",
        //"store": "cafeteria "
        var changeType = EnumTypeFinancial.ReceiptDoc;
        var changeDateTime = new DateTime(2019/04/01);
        var changeValue = new decimal(834);
        var changeCpf = "84455254073";
        var changeCard="8473****1381";
        var changeShop= "leite";
        var changeStore= "cafeteria ";

        var financialInformationId = new Guid("6adf10d0-1b83-46f2-91eb-0c64f1c638a5");

        var testObject = new FinancialInformationEditDto
        {
            Id = financialInformationId,
            Type = changeType,
            DateTime = changeDateTime,
            Value = changeValue,
            Cpf = changeCpf,
            Card = changeCard,
            Shop = changeShop,
            Store = changeStore,


        };




            var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
            _fixture.MongoDbContextFixture,
            _fixture.Mediator);
            var result = await financialInformationController.Edit(testObject);

            if (result is ObjectResult objectResult)
            {
            var actualResultValue = objectResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(204, actualResultValue?.Code);
        }


        var repository = new FinancialInformationRepository(_fixture.SqlContextFixture);
        var user = await repository.GetById(financialInformationId);
        Assert.Equal(changeType, user!.Type);
        Assert.Equal(changeDateTime, user.DateTime);
        Assert.Equal(changeValue, user.Value);
        Assert.Equal(changeCpf, user.Cpf);
        Assert.Equal(changeCard, user.Card);
        Assert.Equal(changeShop, user.Shop);
        Assert.Equal(changeStore, user.Store);
    }
}