using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;


namespace Comrade.Core.FinancialInformationCore.Commands;

public class FinancialInformationCreateManyCommand : IRequest<ISingleResult<Entity>>
{
    public IList<FinancialInformation> FinancialInformations { get; set; }
}