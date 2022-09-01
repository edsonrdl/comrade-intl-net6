using AutoMapper;
using AutoMapper.QueryableExtensions;
using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.Core.SystemUserRoleCore;
using Comrade.Domain.Models;

namespace Comrade.Application.Services.SystemUserRoleServices.Queries;

public class SystemUserRoleQuery : ISystemUserRoleQuery
{
    private readonly IMapper _mapper;
    private readonly IMongoDbQueryContext _mongoDbQueryContext;
    private readonly ISystemUserRoleRepository _repository;

    public SystemUserRoleQuery(ISystemUserRoleRepository repository,
        IMongoDbQueryContext mongoDbQueryContext, IMapper mapper)
    {
        _repository = repository;
        _mongoDbQueryContext = mongoDbQueryContext;
        _mapper = mapper;
    }

    public async Task<IPageResultDto<SystemUserRoleDto>> GetAll(PaginationQuery? paginationQuery = null)
    {
        var paginationFilter = _mapper.Map<PaginationQuery?, PaginationFilter?>(paginationQuery);
        List<SystemUserRoleDto> list;
        if (paginationFilter == null)
        {
            list = await Task.Run(() => _repository.GetAllAsNoTracking()
                .ProjectTo<SystemUserRoleDto>(_mapper.ConfigurationProvider)
                .ToList()).ConfigureAwait(false);
            return new PageResultDto<SystemUserRoleDto>(list);
        }
        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
        list = await Task.Run(() => _repository.GetAllAsNoTracking().Skip(skip)
            .Take(paginationFilter.PageSize)
            .ProjectTo<SystemUserRoleDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);
        return new PageResultDto<SystemUserRoleDto>(paginationFilter, list);
    }

    public async Task<ISingleResultDto<SystemUserRoleDto>> GetByIdDefault(Guid id)
    {
        var entity = await _repository.GetById(id).ConfigureAwait(false);
        var dto = _mapper.Map<SystemUserRoleDto>(entity);
        return new SingleResultDto<SystemUserRoleDto>(dto);
    }

    public async Task<ISingleResultDto<SystemUserRoleDto>> GetByIdMongo(Guid id)
    {
        var entity = await _mongoDbQueryContext.GetById<SystemUserRole?>(id).ConfigureAwait(false);
        var dto = _mapper.Map<SystemUserRoleDto>(entity);
        return new SingleResultDto<SystemUserRoleDto>(dto);
    }
}