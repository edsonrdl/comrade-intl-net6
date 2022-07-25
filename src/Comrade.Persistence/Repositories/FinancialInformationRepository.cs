using Comrade.Core.FinancialInformationCore;
using Comrade.Domain.Bases;
using Comrade.Domain.Enums;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;

namespace Comrade.Persistence.Repositories;

public class FinancialInformationRepository : Repository<FinancialInformation>, IFinancialInformationRepository
{
    private readonly ComradeContext _context;

    public FinancialInformationRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }


    public IQueryable<Lookup>? FindByType(EnumTypeFinancial type)
    {
        var result = _context.FinancialInformations
            .Where(x => x.Type.Equals(type)).Take(30)
            .OrderBy(x => x.Id)
            .Select(s => new Lookup { Key = s.Id, Value = s.Type.ToString() });
        return result;
    }
}