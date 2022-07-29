using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using System;
using Comrade.Domain.Enums;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationControllerEditErrorTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerEditErrorTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task FinancialInformationController_Edit_Error()
    {
        //var changeName = "new Name";
        //var changeEmail = "novo@email.com";
        //var changeRegistration = "NovaRegistration";
        var changeType = EnumTypeFinancial.ReceiptDoc;
      

        var financialInformationId = new Guid("6adf10d0-1b83-46f2-91eb-0c64f1c638a5");

        var testObject = new FinancialInformationEditDto
        {
            Id = financialInformationId,
            Type = changeType,
        };

        var financialInformationController =
            FinancialInformationInjectionController.GetFinancialInformationController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);
        var result = await financialInformationController.Edit(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(409, actualResultValue?.Code);
        }

        var repository = new FinancialInformationRepository(_fixture.SqlContextFixture);
        var user = await repository.GetById(financialInformationId);
        Assert.NotEqual(changeType, user!.Type);
        //Assert.NotEqual(changeEmail, user.Email);
        //Assert.NotEqual(changeRegistration, user.Registration);
    }
}