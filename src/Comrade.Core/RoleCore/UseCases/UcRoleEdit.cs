using Comrade.Core.RoleCore.Commands;
using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.RoleCore.UseCases;

public class UcRoleEdit : UseCase, IUcRoleEdit
{
    private readonly IMediator _mediator;

    public UcRoleEdit(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(RoleEditCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}