using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleCreateValidation
{
    private readonly RoleValidateSameCode _roleValidateSameCode;

    public RoleCreateValidation(IRoleRepository repository,
        RoleValidateSameCode roleValidateSameCode)
    {
        _roleValidateSameCode = roleValidateSameCode;
    }

    public async Task<ISingleResult<Entity>> Execute(Role entity)
    {
        var registerSameCode =
            await _roleValidateSameCode.Execute(entity).ConfigureAwait(false);
        if (!registerSameCode.Success)
        {
            return registerSameCode;
        }

        return new SingleResult<Entity>(entity);
    }
}