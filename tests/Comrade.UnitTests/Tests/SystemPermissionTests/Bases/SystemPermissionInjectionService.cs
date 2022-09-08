using AutoMapper;
using Comrade.Application.Services.SystemPermissionServices.Commands;
using Comrade.Application.Services.SystemPermissionServices.Queries;
using Comrade.Core.SystemPermissionCore.UseCases;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemPermissionTests.Bases;

public sealed class SystemPermissionInjectionService
{
    public static SystemPermissionCommand GetSystemPermissionCommand(ComradeContext context,
        IMediator mediator)
    {
        var ucSystemPermissionDelete =
            new UcSystemPermissionDelete(mediator);

        return new SystemPermissionCommand(ucSystemPermissionDelete, mediator);
    }

    public static SystemPermissionQuery GetSystemPermissionQuery(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMapper mapper)
    {
        var systemPermissionRepository = new SystemPermissionRepository(context);

        return new SystemPermissionQuery(systemPermissionRepository, mongoDbContextFixture, mapper);
    }
}