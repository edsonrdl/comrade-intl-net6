using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleValidateSameCode
{
    private readonly IRoleRepository _repository;

    public RoleValidateSameCode(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<ISingleResult<Entity>> Execute(Role entity)
    {
       

        return new SingleResult<Entity>(entity);
    }
}