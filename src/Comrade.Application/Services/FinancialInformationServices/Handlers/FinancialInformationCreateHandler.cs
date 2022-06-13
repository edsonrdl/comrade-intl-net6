using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.FinancialInformationCore;
using Comrade.Core.FinancialInformationCore.Commands;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Handlers;

public class
    FinancialInformationCreateHandler : IRequestHandler<FinancialInformationCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcFinancialInformationCreate _createFinancialInformation;
    private readonly IMapper _mapper;

    public FinancialInformationCreateHandler(IMapper mapper, IUcFinancialInformationCreate createFinancialInformation)
    {
        _mapper = mapper;
        _createFinancialInformation = createFinancialInformation;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(FinancialInformationCreateDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<FinancialInformationCreateCommand>(request);
        var result = await _createFinancialInformation.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}