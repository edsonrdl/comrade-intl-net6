using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemPermissionCore.Validations;

public class SystemPermissionCreateValidation : ISystemPermissionCreateValidation 
{
    private readonly ISystemPermissionValidateTag _systemPermissionValidateTag;

    public SystemPermissionCreateValidation(ISystemPermissionValidateTag systemPermissionValidateTag)
    {
        _systemPermissionValidateTag = systemPermissionValidateTag;
    }

    public async Task<ISingleResult<Entity>> Execute(SystemPermission entity)
    {
        var registerTag =
            await _systemPermissionValidateTag.Execute(entity).ConfigureAwait(false);
        if (!registerTag.Success)
        {
            return registerTag;
        }

        return new SingleResult<Entity>(entity);
    }
}