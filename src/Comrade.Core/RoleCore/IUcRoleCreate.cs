using Comrade.Core.RoleCore.Commands;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.RoleCore;

public interface IUcRoleCreate
{
    Task<ISingleResult<Entity>> Execute(RoleCreateCommand entity);
}