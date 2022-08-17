using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.RoleCore;

public interface IUcRoleDelete
{
    Task<ISingleResult<Entity>> Execute(Guid id);
}