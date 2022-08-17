using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Core.RoleCore;
using MediatR;

namespace Comrade.Application.Services.RoleServices.Commands;

public class RoleCommand : IRoleCommand
{
    private readonly IUcRoleDelete _deleteRole;
    private readonly IMediator _mediator;

    public RoleCommand(
        IUcRoleDelete deleteRole,
        IMediator mediator)
    {
        _deleteRole = deleteRole;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(RoleCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(RoleEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteRole.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}