using AutoMapper;
using Comrade.Application.Services.RoleServices.Commands;
using Comrade.Application.Services.RoleServices.Queries;
using Comrade.Core.RoleCore.UseCases;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using MediatR;

namespace Comrade.UnitTests.Tests.RoleTests.Bases;

public sealed class RoleInjectionService
{
    public static RoleCommand GetRoleCommand(ComradeContext context,
        IMediator mediator)
    {
        var ucRoleDelete =
            new UcRoleDelete(mediator);

        return new RoleCommand(ucRoleDelete, mediator);
    }

    public static RoleQuery GetRoleQuery(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMapper mapper)
    {
        var roleRepository = new RoleRepository(context);

        return new RoleQuery(roleRepository, mongoDbContextFixture, mapper);
    }
}