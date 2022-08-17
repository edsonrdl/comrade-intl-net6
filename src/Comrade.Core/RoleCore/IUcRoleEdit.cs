using Comrade.Core.RoleCore.Commands;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.RoleCore;

public interface IUcRoleEdit
{
    Task<ISingleResult<Entity>> Execute(RoleEditCommand entity);
}