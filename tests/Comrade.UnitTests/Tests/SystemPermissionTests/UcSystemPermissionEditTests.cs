using System.Threading;
using Comrade.Core.SystemPermissionCore.Commands;
using Comrade.Core.SystemPermissionCore.Handlers;
using Comrade.Core.SystemPermissionCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using Comrade.UnitTests.DataInjectors;
using Comrade.UnitTests.Tests.SystemPermissionTests.TestDatas;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Comrade.UnitTests.Tests.SystemPermissionTests;

public sealed class UcSystemPermissionEditTests
{
    [Theory]
    [ClassData(typeof(SystemPermissionEditTestData))]
    public async Task UcSystemPermissionEdit_Test(int expected, SystemPermissionEditCommand testObjectInput)
    {
        var options = new DbContextOptionsBuilder<ComradeContext>()
            .UseInMemoryDatabase("test_database_UcSystemPermissionEdit_Test" + testObjectInput.Id)
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .EnableSensitiveDataLogging().Options;

        await using var context = new ComradeContext(options);
        await context.Database.EnsureCreatedAsync();
        InjectDataOnContextBase.InitializeDbForTests(context);

        var repository = new SystemPermissionRepository(context);
        var systemPermissionValidateSameName = new SystemPermissionValidateTag(repository);
        var systemPermissionEditValidation = new SystemPermissionEditValidation(systemPermissionValidateSameName);
        var mongo = new Mock<IMongoDbCommandContext>();


        var handler =
            new SystemPermissionEditCoreHandler(systemPermissionEditValidation, repository, mongo.Object);

        var result = await handler.Handle(testObjectInput, CancellationToken.None);

        Assert.Equal(expected, result.Code);
    }
}