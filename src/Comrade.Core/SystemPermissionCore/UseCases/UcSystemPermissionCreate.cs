﻿using Comrade.Core.SystemPermissionCore.Commands;
using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using MediatR;
using Comrade.Core.SystemPermissionCore;
using Comrade.Core.SystemPermissionCore.Commands;

namespace Comrade.Core.SystemPermissionCore.UseCases;

public class UcSystemPermissionCreate : UseCase, IUcSystemPermissionCreate
{
    private readonly IMediator _mediator;

    public UcSystemPermissionCreate(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(SystemPermissionCreateCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}