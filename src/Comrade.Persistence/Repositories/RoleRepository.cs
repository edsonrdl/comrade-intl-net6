using Comrade.Core.RoleCore;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Enums;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;
using DocumentFormat.OpenXml.Wordprocessing;

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

}