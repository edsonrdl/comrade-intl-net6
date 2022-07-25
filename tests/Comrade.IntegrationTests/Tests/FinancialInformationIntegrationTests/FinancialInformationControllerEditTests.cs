using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.FinancialInformationTests.Bases;
using System;
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

        var financialInformationId = new Guid("6adf10d0-1b83-46f2-91eb-0c64f1c638a5");

        var testObject = new FinancialInformationEditDto
        {
            //Id = financialInformationId,
            //Name = changeName,
            //Email = changeEmail,
            //Password = changePassword,
            //Registration = changeRegistration
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
        //Assert.Equal(changeName, user!.Name);
        //Assert.Equal(changeEmail, user.Email);
        //Assert.Equal(changeRegistration, user.Registration);
    }
}