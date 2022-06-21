using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore;

public interface IFinancialInformationRepository : IRepository<FinancialInformation>
{
    IQueryable<Lookup>? FindByType(string type);
}