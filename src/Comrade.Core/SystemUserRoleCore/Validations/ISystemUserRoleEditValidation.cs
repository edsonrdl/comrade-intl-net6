using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemUserRoleCore.Validations;

public interface ISystemUserRoleEditValidation
{
    Task<ISingleResult<Entity>> Execute(SystemUserRole entity, SystemUserRole? recordExists);
}
