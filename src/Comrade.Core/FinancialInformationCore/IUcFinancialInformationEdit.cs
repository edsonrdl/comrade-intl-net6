using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;

namespace Comrade.Core.FinancialInformationCore;

public interface IUcFinancialInformationEdit
{
    Task<ISingleResult<Entity>> Execute(FinancialInformationEditCommand entity);
}