using AutoMapper;
using Comrade.Application.Services.SystemUserRoleServices.Commands;
using Comrade.Application.Services.SystemUserRoleServices.Queries;
using Comrade.Core.SystemUserRoleCore.UseCases;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemUserRoleTests.Bases;

public sealed class SystemUserRoleInjectionService
{
    public static SystemUserRoleCommand GetSystemUserRoleCommand(ComradeContext context,
        IMediator mediator)
    {
        var ucSystemUserRoleDelete =
            new UcSystemUserRoleDelete(mediator);

        return new SystemUserRoleCommand(ucSystemUserRoleDelete, mediator);
    }

    public static SystemUserRoleQuery GetSystemUserRoleQuery(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMapper mapper)
    {
        var systemUserRoleRepository = new SystemUserRoleRepository(context);

        return new SystemUserRoleQuery(systemUserRoleRepository, mongoDbContextFixture, mapper);
    }
}