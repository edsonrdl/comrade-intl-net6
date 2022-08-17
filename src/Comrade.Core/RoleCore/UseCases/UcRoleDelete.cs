using Comrade.Core.RoleCore.Commands;
using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.RoleCore.UseCases;

public class UcRoleDelete : UseCase, IUcRoleDelete
{
    private readonly IMediator _mediator;

    public UcRoleDelete(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(Guid id)
    {
        var entity = new RoleDeleteCommand { Id = id };
        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}