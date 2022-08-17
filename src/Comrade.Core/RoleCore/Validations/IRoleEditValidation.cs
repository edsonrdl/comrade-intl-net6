using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public interface IRoleEditValidation
{
    Task<ISingleResult<Entity>> Execute(Role entity, Role? recordExists);
}