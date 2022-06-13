using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.UseCases;

public class UcFinancialInformationDelete : UseCase, IUcFinancialInformationDelete
{
    private readonly IMediator _mediator;

    public UcFinancialInformationDelete(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(Guid id)
    {
        var entity = new FinancialInformationDeleteCommand { Id = id };
        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}