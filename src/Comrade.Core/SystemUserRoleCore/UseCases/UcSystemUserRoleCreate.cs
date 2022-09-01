using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using MediatR;
using Comrade.Core.SystemUserRoleCore;
using Comrade.Core.SystemUserRoleCore.Commands;

namespace Comrade.Core.SystemUserRoleCore.UseCases;

public class UcSystemUserRoleCreate : UseCase, IUcSystemUserRoleCreate
{
    private readonly IMediator _mediator;

    public UcSystemUserRoleCreate(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(SystemUserRoleCreateCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}