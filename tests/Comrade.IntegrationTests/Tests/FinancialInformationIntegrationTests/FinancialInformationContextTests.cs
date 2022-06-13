using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using System;
using Xunit;

namespace Comrade.IntegrationTests.Tests.FinancialInformationIntegrationTests;

public class FinancialInformationContextTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _fixture;

    public FinancialInformationContextTests(ServiceProviderFixture fixture)
    {
        _fixture = fixture;
        InjectDataOnContextBase.InitializeDbForTests(_fixture.SqlContextFixture);
    }

    [Fact]
    public async Task FinancialInformation_Context()
    {
        var id = new Guid("6adf10d0-1b83-46f2-91eb-0c64f1c638a5");
        var repository = new FinancialInformationRepository(_fixture.SqlContextFixture);
        var financialInformation = await repository.GetById(id);
        Assert.NotNull(financialInformation);
    }
}