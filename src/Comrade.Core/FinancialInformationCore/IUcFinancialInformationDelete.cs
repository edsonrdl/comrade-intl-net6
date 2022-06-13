using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.FinancialInformationCore;

public interface IUcFinancialInformationDelete
{
    Task<ISingleResult<Entity>> Execute(Guid id);
}