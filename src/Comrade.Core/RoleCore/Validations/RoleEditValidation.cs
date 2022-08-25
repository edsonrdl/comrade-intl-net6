using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleEditValidation : IRoleEditValidation
{
    private readonly RoleValidateSameName _roleValidateSameName;

    public RoleEditValidation(RoleValidateSameName roleValidateSameName)
    {
        _roleValidateSameName = roleValidateSameName;
    }

    public async Task<ISingleResult<Entity>> Execute(Role entity, Role? recordExists)
    {
        var registerSameName =
            await _roleValidateSameName.Execute(entity).ConfigureAwait(false);
        if (!registerSameName.Success)
        {
            return registerSameName;
        }

        return new SingleResult<Entity>(recordExists);
    }
}