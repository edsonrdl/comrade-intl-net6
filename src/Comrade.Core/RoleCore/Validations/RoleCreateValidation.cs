using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleCreateValidation
{
    private readonly RoleValidateSameName _roleValidateSameName;

    public RoleCreateValidation(
        RoleValidateSameName roleValidateSameName)
    {
        _roleValidateSameName = roleValidateSameName;
    }

    public async Task<ISingleResult<Entity>> Execute(Role entity)
    {
        var registerSameName =
            await _roleValidateSameName.Execute(entity).ConfigureAwait(false);
        if (!registerSameName.Success)
        {
            return registerSameName;
        }

        return new SingleResult<Entity>(entity);
    }
}