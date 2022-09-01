using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.SystemUserRoleCore;

public interface IUcSystemUserRoleEdit
{
    Task<ISingleResult<Entity>> Execute(SystemUserRoleEditCommand entity);
}