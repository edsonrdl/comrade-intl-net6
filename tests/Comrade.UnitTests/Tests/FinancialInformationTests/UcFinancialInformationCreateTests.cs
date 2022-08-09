using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Core.FinancialInformationCore.Handlers;
using Comrade.Core.FinancialInformationCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.Tests.FinancialInformationTests.TestDatas;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Comrade.UnitTests.Tests.FinancialInformationTests;

public sealed class UcFinancialInformationCreateTests
{
    [Theory]
    [ClassData(typeof(FinancialInformationCreateTestData))]
    public async Task UcFinancialInformationCreate_Test(int expected, FinancialInformationCreateCommand testObjectInput)
    {
        var options = new DbContextOptionsBuilder<ComradeContext>()
            .UseInMemoryDatabase("test_database_UcFinancialInformationCreate_Test" + testObjectInput.Id)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .EnableSensitiveDataLogging().Options;

        await using var context = new ComradeContext(options);
        await context.Database.EnsureCreatedAsync();

        var repository = new FinancialInformationRepository(context);

        var validation = new Mock<IFinancialInformationCreateValidation>();

        validation.Setup(s =>
                s.Execute(It.IsAny<FinancialInformation>()))
            .Returns(new SingleResult<Entity>(testObjectInput));

        var handler =
            new FinancialInformationCreateCoreHandler(validation.Object, repository);

        var result = await handler.Handle(testObjectInput, CancellationToken.None);

        Assert.Equal(result.Code, expected);
    }
}