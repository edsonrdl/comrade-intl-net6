using Comrade.Api.UseCases.V1.RoleApi;
using Comrade.Persistence.DataAccess;
using Comrade.UnitTests.Helpers;
using MediatR;

namespace Comrade.UnitTests.Tests.RoleTests.Bases;

public class RoleInjectionController
{
    public static RoleController GetRoleController(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMediator mediator)
    {
        var mapper = MapperHelper.ConfigMapper();
        var logger = Mock.Of<ILogger<RoleController>>();

        var roleCommand =
            RoleInjectionService.GetRoleCommand(context, mediator);
        var roleQuery =
            RoleInjectionService.GetRoleQuery(context!, mongoDbContextFixture, mapper);
        return new RoleController(roleCommand, roleQuery, logger);
    }
}