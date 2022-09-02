using System.Threading;
using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.SystemUserRoleCore.Handlers;
using Comrade.Core.SystemUserRoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.RoleCore.Validations;
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

public sealed class UcSystemUserRoleCreateTests
{
    [Theory]
    [ClassData(typeof(SystemUserRoleCreateTestData))]
    public async Task UcSystemUserRoleCreate_Test(int expected, SystemUserRoleCreateCommand testObjectInput)
    {
        var options = new DbContextOptionsBuilder<ComradeContext>()
            .UseInMemoryDatabase("test_database_UcSystemUserRoleCreate_Test" + testObjectInput.Id)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .EnableSensitiveDataLogging().Options;

        await using var context = new ComradeContext(options);
        await context.Database.EnsureCreatedAsync();
        InjectDataOnContextBase.InitializeDbForTests(context);

        var repository = new SystemUserRoleRepository(context);

        var validation = new Mock<ISystemUserRoleCreateValidation>();
        validation.Setup(s =>
                s.Execute(It.IsAny<SystemUserRole>()))
            .ReturnsAsync(new SingleResult<Entity>(testObjectInput));

        var mongo = new Mock<IMongoDbCommandContext>();

        var handler = new SystemUserRoleCreateCoreHandler(validation.Object, repository, mongo.Object);

        var result = await handler.Handle(testObjectInput, CancellationToken.None);

        Assert.Equal( expected, result.Code);
    }
}