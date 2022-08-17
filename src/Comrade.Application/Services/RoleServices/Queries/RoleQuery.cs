using AutoMapper;
using AutoMapper.QueryableExtensions;
using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Paginations;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Core.RoleCore;
using Comrade.Domain.Models;

namespace Comrade.Application.Services.RoleServices.Queries;

public class RoleQuery : IRoleQuery
{
    private readonly IMapper _mapper;
    private readonly IMongoDbQueryContext _mongoDbQueryContext;
    private readonly IRoleRepository _repository;

    public RoleQuery(IRoleRepository repository,
        IMongoDbQueryContext mongoDbQueryContext, IMapper mapper)
    {
        _repository = repository;
        _mongoDbQueryContext = mongoDbQueryContext;
        _mapper = mapper;
    }

    public async Task<IPageResultDto<RoleDto>> GetAll(
        PaginationQuery? paginationQuery = null)
    {
        var paginationFilter = _mapper.Map<PaginationQuery?, PaginationFilter?>(paginationQuery);
        List<RoleDto> list;
        if (paginationFilter == null)
        {
            list = await Task.Run(() => _repository.GetAllAsNoTracking()
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                .ToList()).ConfigureAwait(false);

            return new PageResultDto<RoleDto>(list);
        }

        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

        list = await Task.Run(() => _repository.GetAllAsNoTracking().Skip(skip)
            .Take(paginationFilter.PageSize)
            .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new PageResultDto<RoleDto>(paginationFilter, list);
    }

    public async Task<ISingleResultDto<RoleDto>> GetByIdDefault(Guid id)
    {
        var entity = await _repository.GetById(id).ConfigureAwait(false);
        var dto = _mapper.Map<RoleDto>(entity);
        return new SingleResultDto<RoleDto>(dto);
    }

    public async Task<ISingleResultDto<RoleDto>> GetByIdMongo(Guid id)
    {
        var entity = await _mongoDbQueryContext.GetById<Role?>(id).ConfigureAwait(false);
        var dto = _mapper.Map<RoleDto>(entity);
        return new SingleResultDto<RoleDto>(dto);
    }
}