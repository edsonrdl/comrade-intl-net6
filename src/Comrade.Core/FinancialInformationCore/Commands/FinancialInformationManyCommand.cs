using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;


namespace Comrade.Core.FinancialInformationCore.Commands;

public class FinancialInformationCreateManyCommand : IRequest<ISingleResult<Entity>>
{
    public FinancialInformationCreateManyCommand(IList<FinancialInformation> financialInformations)
    {
        FinancialInformations = financialInformations;
    }

    public IList<FinancialInformation> FinancialInformations { get; set; }
}