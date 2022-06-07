using Comrade.Api.UseCases.V2.FinancialInformationApi;
using Comrade.Persistence.DataAccess;
using Comrade.UnitTests.Helpers;
using MediatR;

namespace Comrade.UnitTests.Tests.FinancialInformationTests.Bases;

public class FinancialInformationInjectionController
{
    public static FinancialInformationController GetFinancialInformationController(ComradeContext context,
        MongoDbContext mongoDbContextFixture, IMediator mediator)
    {
        var mapper = MapperHelper.ConfigMapper();
        var financialInformationCommand =
            FinancialInformationInjectionService.GetFinancialInformationCommand(context, mediator);
        var financialInformationQuery =
            FinancialInformationInjectionService.GetFinancialInformationQuery(context, mongoDbContextFixture, mapper);

        return new FinancialInformationController(financialInformationCommand, financialInformationQuery);
    }
}