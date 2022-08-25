using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleValidateSameName
{
    private readonly IRoleRepository _repository;

    public RoleValidateSameName(IRoleRepository repository)
    {
        _repository = repository;
    }


    public async Task<ISingleResult<Entity>> Execute(Role entity)
    {

        var result = await _repository.ValidateSameName(entity.Id, entity.Name)
            .ConfigureAwait(false);
        if (result.Success)
        {
            return new SingleResult<Entity>(entity);

        } 
        
        return new SingleResult<Entity>(result.Code,result.Message);
    }
}