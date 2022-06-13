using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserServices.Dtos;
using Comrade.UnitTests.Tests.SystemUserTests.Bases;
using Xunit;

namespace Comrade.IntegrationTests.Tests.SystemUserIntegrationTests;

public sealed class FinancialInformationControllerCreateTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationControllerCreateTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
    }


    [Fact]
    public async Task SystemUserController_Create()
    {
        var testObject = new FinancialInformationCreateDto
        {
            Name = "111",
            Email = "777@testObject",
            Password = "123456",
            Registration = "123"
        };

        var systemUserController =
            FinancialInformationInjectionController.GetSystemUserController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);

        var result = await systemUserController.Create(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(201, actualResultValue?.Code);
        }
    }


    [Fact]
    public async Task SystemUserController_Create_Error()
    {
        var testObject = new FinancialInformationCreateDto
        {
            Email = "777@testObject",
            Password = "123456",
            Registration = "123"
        };

        var systemUserController =
            FinancialInformationInjectionController.GetSystemUserController(_fixture.SqlContextFixture,
                _fixture.MongoDbContextFixture,
                _fixture.Mediator);

        var result = await systemUserController.Create(testObject);

        if (result is ObjectResult okResult)
        {
            var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
            Assert.NotNull(actualResultValue);
            Assert.Equal(409, actualResultValue?.Code);
        }
    }
}