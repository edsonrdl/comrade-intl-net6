using Comrade.Core.FinancialInformationCore;
using Comrade.Domain.Bases;
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


    public IQueryable<Lookup>? FindByName(string name)
    {
        var result = _context.FinancialInformations
            .Where(x => x.Name.Contains(name)).Take(30)
            .OrderBy(x => x.Name)
            .Select(s => new Lookup { Key = s.Id, Value = s.Name });

        return result;
    }
}