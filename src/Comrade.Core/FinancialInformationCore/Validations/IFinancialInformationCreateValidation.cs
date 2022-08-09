using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore.Validations;

public interface IFinancialInformationCreateValidation
{
    ISingleResult<Entity> Execute(FinancialInformation entity);
}