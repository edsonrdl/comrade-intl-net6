using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemUserRoleCore.Validations;

public class SystemUserRoleCreateValidation: ISystemUserRoleCreateValidation
{
    public async Task<ISingleResult<Entity>> Execute(SystemUserRole entity)
    {
        return new SingleResult<Entity>(entity);
    }
}