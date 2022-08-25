using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore;

public interface IRoleRepository : IRepository<Role>
{
    Task<ISingleResult<Role>> ValidateSameName(Guid id, string name);


}