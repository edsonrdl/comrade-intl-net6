using System.Threading;
using Comrade.Core.RoleCore.Commands;
using Comrade.Core.RoleCore.Handlers;
using Comrade.Core.RoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.RoleTests.TestDatas;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Comrade.UnitTests.Tests.RoleTests;

public sealed class UcRoleEditTests
{
    [Theory]
    [ClassData(typeof(RoleEditTestData))]
    public async Task UcRoleEdit_Test(int expected, RoleEditCommand testObjectInput)
    {
        var options = new DbContextOptionsBuilder<ComradeContext>()
            .UseInMemoryDatabase("test_database_UcRoleEdit_Test" + testObjectInput.Id)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .EnableSensitiveDataLogging().Options;

        await using var context = new ComradeContext(options);
        await context.Database.EnsureCreatedAsync();
        InjectDataOnContextBase.InitializeDbForTests(context);

        var repository = new RoleRepository(context);
        var roleValidateSameName = new RoleValidateSameName(repository);
        var roleEditValidation = new RoleEditValidation(roleValidateSameName);
        var mongo = new Mock<IMongoDbCommandContext>();


        var handler =
            new RoleEditCoreHandler(roleEditValidation, repository, mongo.Object);

        var result = await handler.Handle(testObjectInput, CancellationToken.None);

        Assert.Equal( expected, result.Code);
    }
}