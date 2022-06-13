using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.FinancialInformationCore;
using Comrade.Core.FinancialInformationCore.Commands;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Handlers;

public class FinancialInformationEditHandler : IRequestHandler<FinancialInformationEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcFinancialInformationEdit _editFinancialInformation;
    private readonly IMapper _mapper;

    public FinancialInformationEditHandler(IMapper mapper, IUcFinancialInformationEdit editFinancialInformation)
    {
        _mapper = mapper;
        _editFinancialInformation = editFinancialInformation;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(FinancialInformationEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<FinancialInformationEditCommand>(request);
        var result = await _editFinancialInformation.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}