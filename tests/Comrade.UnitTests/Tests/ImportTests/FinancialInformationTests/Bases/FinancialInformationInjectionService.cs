using AutoMapper;
using Comrade.Application.Services.FinancialInformationServices.Commands;
using Comrade.Application.Services.FinancialInformationServices.Queries;
using Comrade.Application.Services.SystemUserServices.Commands;
using Comrade.Application.Services.SystemUserServices.Queries;
using Comrade.Core.FinancialInformationCore.UseCases;
using Comrade.Core.SystemUserCore.UseCases;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemUserTests.Bases;

public sealed class FinancialInformationInjectionService
{
    public static FinancialInformationCommand GetFinancialInformationCommand(ComradeContext context, IMediator mediator)
    {
        var ucSystemUserDelete =
            new UcFinancialInformationDelete(mediator);

        return new FinancialInformationCommand(ucSystemUserDelete, mediator);
    }

    public static FinancialInformationQuery GetFinancialInformationQuery(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMapper mapper)
    {
        var repository = new FinancialInformationRepository(context);

        return new FinancialInformationQuery(repository, mongoDbContextFixture, mapper);
    }
}