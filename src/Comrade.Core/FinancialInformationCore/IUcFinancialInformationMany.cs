using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;

namespace Comrade.Core.FinancialInformationCore;

public interface IUcFinancialInformationCreateMany
{
    Task<ISingleResult<Entity>> Execute(FinancialInformationCreateManyCommand entity);
}