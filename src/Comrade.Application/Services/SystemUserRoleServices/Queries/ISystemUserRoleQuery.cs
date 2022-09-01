using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;

namespace Comrade.Application.Services.SystemUserRoleServices.Queries;
public interface ISystemUserRoleQuery
{
    Task<IPageResultDto<SystemUserRoleDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<SystemUserRoleDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<SystemUserRoleDto>> GetByIdMongo(Guid id);
}