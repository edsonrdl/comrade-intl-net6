using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemPermissionCore.Validations;

public class SystemPermissionEditValidation : ISystemPermissionEditValidation
{
    private readonly SystemPermissionValidateSameName _systemPermissionValidateSameName;

    public SystemPermissionEditValidation(SystemPermissionValidateSameName systemPermissionValidateSameName)
    {
        _systemPermissionValidateSameName = systemPermissionValidateSameName;
    }

    public async Task<ISingleResult<Entity>> Execute(SystemPermission entity, SystemPermission? recordExists)
    {
        var registerSameName =
            await _systemPermissionValidateSameName.Execute(entity).ConfigureAwait(false);
        if (!registerSameName.Success)
        {
            return registerSameName;
        }

        return new SingleResult<Entity>(recordExists);
    }
}