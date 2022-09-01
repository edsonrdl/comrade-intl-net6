using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.SystemUserRoleCore;

public interface IUcSystemUserRoleCreate
{
    Task<ISingleResult<Entity>> Execute(SystemUserRoleCreateCommand entity);
}
