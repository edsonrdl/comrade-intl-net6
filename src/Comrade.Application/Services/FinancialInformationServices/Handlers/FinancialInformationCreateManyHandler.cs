using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.FinancialInformationCore;
using Comrade.Core.FinancialInformationCore.Commands;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Handlers;

public class
    FinancialInformationCreateManyHandler : IRequestHandler<FinancialInformationCreateManyDto, SingleResultDto<EntityDto>>
{
    private readonly IUcFinancialInformationCreateMany _createManyFinancialInformation;
    private readonly IMapper _mapper;

    public FinancialInformationCreateManyHandler(IMapper mapper, IUcFinancialInformationCreateMany createManyFinancialInformation)
    {
        _mapper = mapper;
        _createManyFinancialInformation = createManyFinancialInformation;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(FinancialInformationCreateManyDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<FinancialInformationCreateManyCommand>(request);
        var result = await _createManyFinancialInformation.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}