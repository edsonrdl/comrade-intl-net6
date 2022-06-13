using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;

namespace Comrade.Core.FinancialInformationCore;

public interface IUcFinancialInformationCreate
{
    Task<ISingleResult<Entity>> Execute(FinancialInformationCreateCommand entity);
}