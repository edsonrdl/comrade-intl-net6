using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.SystemUserRoleCore.UseCases;

public class UcSystemUserRoleDelete : UseCase, IUcSystemUserRoleDelete
{
    private readonly IMediator _mediator;

    public UcSystemUserRoleDelete(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(Guid id)
    {
        var entity = new SystemUserRoleDeleteCommand { Id = id };
        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}