using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.Core.SystemPermissionCore;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Commands;

public class SystemPermissionCommand : ISystemPermissionCommand
{
    private readonly IUcSystemPermissionDelete _deleteSystemPermission;
    private readonly IMediator _mediator;

    public SystemPermissionCommand(
        IUcSystemPermissionDelete deleteSystemPermission,
        IMediator mediator)
    {
        _deleteSystemPermission = deleteSystemPermission;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(SystemPermissionCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(SystemPermissionEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteSystemPermission.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}