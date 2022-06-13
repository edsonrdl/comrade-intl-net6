using Comrade.Api.UseCases.V2.SystemUserApi;
using Comrade.Persistence.DataAccess;
using Comrade.UnitTests.Helpers;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemUserTests.Bases;

public class FinancialInformationInjectionController
{
    public static FinanacialInformationController GetSystemUserController(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMediator mediator)
    {
        var mapper = MapperHelper.ConfigMapper();
        var systemUserCommand =
            FinancialInformationInjectionService.GetSystemUserCommand(context, mediator);
        var systemUserQuery =
            FinancialInformationInjectionService.GetSystemUserQuery(context, mongoDbContextFixture, mapper);

        return new SystemUserController(systemUserCommand, systemUserQuery);
    }
}