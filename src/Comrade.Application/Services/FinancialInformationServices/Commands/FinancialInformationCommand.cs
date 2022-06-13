using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.FinancialInformationCore;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Commands;

public class FinancialInformationCommand : IFinancialInformationCommand
{
    private readonly IUcFinancialInformationDelete _deleteFinancialInformation;
    private readonly IMediator _mediator;

    public FinancialInformationCommand(
        IUcFinancialInformationDelete deleteFinancialInformation, IMediator mediator)
    {
        _deleteFinancialInformation = deleteFinancialInformation;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(FinancialInformationCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(FinancialInformationEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteFinancialInformation.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}