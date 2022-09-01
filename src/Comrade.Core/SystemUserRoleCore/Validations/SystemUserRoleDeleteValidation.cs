using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemUserRoleCore.Validations;

public class SystemUserRoleDeleteValidation: ISystemUserRoleDeleteValidation
{
    public ISingleResult<Entity> Execute(SystemUserRole? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}