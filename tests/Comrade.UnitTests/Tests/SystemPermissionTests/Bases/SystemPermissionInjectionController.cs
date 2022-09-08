using Comrade.Api.UseCases.V1.SystemPermissionApi;
using Comrade.Persistence.DataAccess;
using Comrade.UnitTests.Helpers;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemPermissionTests.Bases;

public class SystemPermissionInjectionController
{
    public static SystemPermissionController GetSystemPermissionController(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMediator mediator)
    {
        var mapper = MapperHelper.ConfigMapper();
        var logger = Mock.Of<ILogger<SystemPermissionController>>();

        var systemPermissionCommand =
            SystemPermissionInjectionService.GetSystemPermissionCommand(context, mediator);
        var systemPermissionQuery =
            SystemPermissionInjectionService.GetSystemPermissionQuery(context!, mongoDbContextFixture, mapper);
        return new SystemPermissionController(systemPermissionCommand, systemPermissionQuery, logger);
    }
}