using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemUserRoleCore.Validations;

public class SystemUserRoleEditValidation : ISystemUserRoleEditValidation
{
   
    public async Task<ISingleResult<Entity>> Execute(SystemUserRole entity, SystemUserRole? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}