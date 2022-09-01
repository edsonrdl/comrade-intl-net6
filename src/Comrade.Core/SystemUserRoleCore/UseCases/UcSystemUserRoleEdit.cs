using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.SystemUserRoleCore.UseCases;

public class UcSystemUserRoleEdit : UseCase, IUcSystemUserRoleEdit
{
    private readonly IMediator _mediator;

    public UcSystemUserRoleEdit(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(SystemUserRoleEditCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}