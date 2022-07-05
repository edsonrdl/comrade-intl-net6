using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore.Validations;

public class FinancialInformationCreateManyValidation
{
    public ISingleResult<Entity> Execute(FinancialInformation entity)
    {
        return new SingleResult<Entity>(entity);
    }
}