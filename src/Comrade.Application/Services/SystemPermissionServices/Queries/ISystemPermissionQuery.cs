using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemPermissionServices.Dtos;

namespace Comrade.Application.Services.SystemPermissionServices.Queries;
public interface ISystemPermissionQuery
{
    Task<IPageResultDto<SystemPermissionDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<SystemPermissionDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<SystemPermissionDto>> GetByIdMongo(Guid id);
}