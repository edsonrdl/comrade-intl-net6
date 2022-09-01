using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.SystemUserRoleCore;

public interface IUcSystemUserRoleDelete
{
    Task<ISingleResult<Entity>> Execute(Guid id);
}