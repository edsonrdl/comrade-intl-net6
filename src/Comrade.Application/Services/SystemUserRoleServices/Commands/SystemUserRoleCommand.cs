using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.Core.SystemUserRoleCore;
using MediatR;

namespace Comrade.Application.Services.SystemUserRoleServices.Commands;

public class SystemUserRoleCommand : ISystemUserRoleCommand
{
    private readonly IUcSystemUserRoleDelete _deleteSystemUserRole;
    private readonly IMediator _mediator;

    public SystemUserRoleCommand(
        IUcSystemUserRoleDelete deleteSystemUserRole,
        IMediator mediator)
    {
        _deleteSystemUserRole = deleteSystemUserRole;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(SystemUserRoleCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(SystemUserRoleEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteSystemUserRole.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}