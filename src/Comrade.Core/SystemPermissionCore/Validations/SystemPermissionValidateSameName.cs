using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemPermissionCore.Validations;

public class SystemPermissionValidateSameName : ISystemPermissionValidationSameName
{
    private readonly ISystemPermissionRepository _repository;

    public SystemPermissionValidateSameName(ISystemPermissionRepository repository)
    {
        _repository = repository;
    }


    public async Task<ISingleResult<Entity>> Execute(SystemPermission entity)
    {

        var result = await _repository.ValidateSameName(entity.Id, entity.Name,entity.Tag)
            .ConfigureAwait(false);
        if (result.Success)
        {
            return new SingleResult<Entity>(entity);

        } 
        
        return new SingleResult<Entity>(result.Code,result.Message);
    }
}