using System.Threading;
using Comrade.Core.RoleCore.Commands;
using Comrade.Core.RoleCore.Handlers;
using Comrade.Core.RoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.RoleTests.TestDatas;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Comrade.UnitTests.Tests.RoleTests;

public sealed class UcRoleCreateTests
{
    [Theory]
    [ClassData(typeof(RoleCreateTestData))]
    public async Task UcRoleCreate_Test(int expected, RoleCreateCommand testObjectInput)
    {
        var options = new DbContextOptionsBuilder<ComradeContext>()
            .UseInMemoryDatabase("test_database_UcRoleCreate_Test" + testObjectInput.Id)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .EnableSensitiveDataLogging().Options;

        await using var context = new ComradeContext(options);
        await context.Database.EnsureCreatedAsync();
        InjectDataOnContextBase.InitializeDbForTests(context);

        var repository = new RoleRepository(context);
        var roleValidateSameName = new RoleValidateSameName(repository);
        var roleCreateValidation = new RoleCreateValidation(roleValidateSameName);
        var mongo = new Mock<IMongoDbCommandContext>();


        var handler =
            new RoleCreateCoreHandler(roleCreateValidation, repository, mongo.Object);

        var result = await handler.Handle(testObjectInput, CancellationToken.None);

        Assert.Equal( expected, result.Code);
    }
}