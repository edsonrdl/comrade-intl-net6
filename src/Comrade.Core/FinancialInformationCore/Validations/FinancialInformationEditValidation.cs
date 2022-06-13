using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore.Validations;

public class FinancialInformationEditValidation
{
    public ISingleResult<Entity> Execute(FinancialInformation entity, FinancialInformation? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}