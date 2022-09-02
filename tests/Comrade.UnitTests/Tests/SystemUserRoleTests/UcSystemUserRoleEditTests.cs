using System.Threading;
using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.SystemUserRoleCore.Handlers;
using Comrade.Core.SystemUserRoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemUserRoleTests.TestDatas;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.UnitTests.Tests.SystemUserRoleTests;

public sealed class UcSystemUserRoleEditTests
{
    [Theory]
    [ClassData(typeof(SystemUserRoleEditTestData))]
    public async Task UcSystemUserRoleEdit_Test(int expected, SystemUserRoleEditCommand testObjectInput)
    {
        var options = new DbContextOptionsBuilder<ComradeContext>()
            .UseInMemoryDatabase("test_database_UcSystemUserRoleEdit_Test" + testObjectInput.Id)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .EnableSensitiveDataLogging().Options;

        await using var context = new ComradeContext(options);
        await context.Database.EnsureCreatedAsync();
        InjectDataOnContextBase.InitializeDbForTests(context);

        var repository = new SystemUserRoleRepository(context);

        var validation = new Mock<ISystemUserRoleEditValidation>();
        validation.Setup(s =>
                s.Execute(It.IsAny<SystemUserRole>(), It.IsAny<SystemUserRole>()))
            .ReturnsAsync(new SingleResult<Entity>(testObjectInput));

        var mongo = new Mock<IMongoDbCommandContext>();


        var handler =
            new SystemUserRoleEditCoreHandler(validation.Object, repository, mongo.Object);

        var result = await handler.Handle(testObjectInput, CancellationToken.None);

        Assert.Equal( expected, result.Code);
    }
}