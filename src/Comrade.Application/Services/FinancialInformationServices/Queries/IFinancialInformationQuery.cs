using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.FinancialInformationServices.Dtos;

namespace Comrade.Application.Services.FinancialInformationServices.Queries;

public interface IFinancialInformationQuery
{
    Task<IPageResultDto<FinancialInformationDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<FinancialInformationDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<FinancialInformationDto>> GetByIdMongo(Guid id);
    Task<ListResultDto<LookupDto>> FindByName(string name);
}