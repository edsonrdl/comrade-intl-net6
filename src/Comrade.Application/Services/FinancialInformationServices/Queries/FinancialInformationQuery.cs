using AutoMapper;
using AutoMapper.QueryableExtensions;
using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.FinancialInformationCore;
using Comrade.Domain.Models;

namespace Comrade.Application.Services.FinancialInformationServices.Queries;

public class FinancialInformationQuery : IFinancialInformationQuery
{
    private readonly IMapper _mapper;
    private readonly IMongoDbQueryContext _mongoDbQueryContext;
    private readonly IFinancialInformationRepository _repository;

    public FinancialInformationQuery(IFinancialInformationRepository repository,
        IMongoDbQueryContext mongoDbQueryContext, IMapper mapper)
    {
        _repository = repository;
        _mongoDbQueryContext = mongoDbQueryContext;
        _mapper = mapper;
    }

    public async Task<IPageResultDto<FinancialInformationDto>> GetAll(
        PaginationQuery? paginationQuery = null)
    {
        var paginationFilter = _mapper.Map<PaginationQuery?, PaginationFilter?>(paginationQuery);

        List<FinancialInformationDto> list;
        if (paginationFilter == null)
        {
            list = await Task.Run(() => _repository.GetAllAsNoTracking()
                .ProjectTo<FinancialInformationDto>(_mapper.ConfigurationProvider)
                .ToList()).ConfigureAwait(false);

            return new PageResultDto<FinancialInformationDto>(list);
        }

        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

        list = await Task.Run(() => _repository.GetAllAsNoTracking().Skip(skip)
            .ProjectTo<FinancialInformationDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new PageResultDto<FinancialInformationDto>(paginationFilter, list);
    }

    public async Task<ListResultDto<LookupDto>> FindByType(string type)
    {
        var list = await Task.Run(() => _repository.FindByType(type)
            .ProjectTo<LookupDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new ListResultDto<LookupDto>(list);
    }

    public async Task<ISingleResultDto<FinancialInformationDto>> GetByIdDefault(Guid id)
    {
        var entity = await _repository.GetById(id).ConfigureAwait(false);
        var dto = _mapper.Map<FinancialInformationDto>(entity);
        return new SingleResultDto<FinancialInformationDto>(dto);
    }

    public async Task<ISingleResultDto<FinancialInformationDto>> GetByIdMongo(Guid id)
    {
        var entity = await _mongoDbQueryContext.GetById<FinancialInformation?>(id).ConfigureAwait(false);
        var dto = _mapper.Map<FinancialInformationDto>(entity);
        return new SingleResultDto<FinancialInformationDto>(dto);
    }
}