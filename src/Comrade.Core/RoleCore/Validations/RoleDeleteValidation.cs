using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Validations;

public class RoleDeleteValidation
{
    public ISingleResult<Entity> Execute(Role? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}