using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemUserRoleCore.Validations;

public interface ISystemUserRoleDeleteValidation
{
    ISingleResult<Entity> Execute(SystemUserRole? recordExists);
}