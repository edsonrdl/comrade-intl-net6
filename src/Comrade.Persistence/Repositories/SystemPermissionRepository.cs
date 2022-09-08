using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.SystemPermissionCore;
using Comrade.Domain.Enums;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;
namespace Comrade.Persistence.Repositories;

public class SystemPermissionRepository : Repository<SystemPermission>, ISystemPermissionRepository
{
    private readonly ComradeContext _context;

    public SystemPermissionRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
    public async Task<ISingleResult<SystemPermission>> ValidateTag(string tag)
    {
        var exists = await _context.SystemPermissions
            .Where(v => tag.ToUpper().Trim().Equals(v.Tag.ToUpper().Trim(), StringComparison.Ordinal))
            .AnyAsync().ConfigureAwait(false);
        return exists
            ? new SingleResult<SystemPermission>((int)EnumResponse.ErrorBusinessValidation,
                BusinessMessage.MSG14)
            : new SingleResult<SystemPermission>();
    }
}