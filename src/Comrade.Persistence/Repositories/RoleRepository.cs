using Comrade.Core.RoleCore;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Enums;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;
namespace Comrade.Persistence.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    private readonly ComradeContext _context;

    public RoleRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
    public async Task<ISingleResult<Role>> ValidateSameName(Guid id, string name )
    {
        var exists = await _context.Roles
            .Where(p => name.ToUpper().Trim().Equals(p.Name.ToUpper().Trim()))
            .AnyAsync().ConfigureAwait(false);


        return exists
            ? new SingleResult<Role>((int)EnumResponse.ErrorBusinessValidation,
                BusinessMessage.MSG13)
            : new SingleResult<Role>();
    }

}