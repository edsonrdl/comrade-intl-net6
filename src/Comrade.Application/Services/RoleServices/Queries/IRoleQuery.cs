using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Paginations;
using Comrade.Application.Services.RoleServices.Dtos;

namespace Comrade.Application.Services.RoleServices.Queries;

public interface IRoleQuery
{
    Task<IPageResultDto<RoleDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<RoleDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<RoleDto>> GetByIdMongo(Guid id);
}