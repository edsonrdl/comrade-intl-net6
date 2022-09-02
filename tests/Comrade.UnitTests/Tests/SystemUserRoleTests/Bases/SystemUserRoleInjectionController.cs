using Comrade.Api.UseCases.V1.SystemUserRoleApi;
using Comrade.Persistence.DataAccess;
using Comrade.UnitTests.Helpers;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;

public class SystemUserRoleInjectionController
{
    public static SystemUserRoleController GetSystemUserRoleController(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMediator mediator)
    {
        var mapper = MapperHelper.ConfigMapper();
        var logger = Mock.Of<ILogger<SystemUserRoleController>>();

        var systemUserRoleCommand =
            SystemUserRoleInjectionService.GetSystemUserRoleCommand(context, mediator);
        var systemUserRoleQuery =
            SystemUserRoleInjectionService.GetSystemUserRoleQuery(context!, mongoDbContextFixture, mapper);
        return new SystemUserRoleController(systemUserRoleCommand, systemUserRoleQuery, logger);
    }
}