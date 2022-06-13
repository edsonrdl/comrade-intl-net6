using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.Commands;

public class FinancialInformationCreateCommand : FinancialInformation, IRequest<ISingleResult<Entity>>
{
}