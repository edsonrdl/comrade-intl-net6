using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleEditValidation : IRoleEditValidation
{
    private readonly RoleValidateSameCode _roleValidateSameCode;

    public RoleEditValidation(RoleValidateSameCode roleValidateSameCode)
    {
        _roleValidateSameCode = roleValidateSameCode;
    }

    public async Task<ISingleResult<Entity>> Execute(Role entity, Role? recordExists)
    {
        var registerSameCode =
            await _roleValidateSameCode.Execute(entity).ConfigureAwait(false);
        if (!registerSameCode.Success)
        {
            return registerSameCode;
        }

        return new SingleResult<Entity>(recordExists);
    }
}