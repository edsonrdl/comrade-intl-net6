using Comrade.Core.SystemUserRoleCore;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;
namespace Comrade.Persistence.Repositories;

public class SystemUserRoleRepository : Repository<SystemUserRole>, ISystemUserRoleRepository
{
    private readonly ComradeContext _context;

    public SystemUserRoleRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }
    
}