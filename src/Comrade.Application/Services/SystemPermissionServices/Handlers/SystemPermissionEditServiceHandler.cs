using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.Core.SystemPermissionCore;
using Comrade.Core.SystemPermissionCore.Commands;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Handlers;

public class
    SystemPermissionEditServiceHandler : IRequestHandler<SystemPermissionEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcSystemPermissionEdit _editSystemPermission;
    private readonly IMapper _mapper;

    public SystemPermissionEditServiceHandler(IMapper mapper, IUcSystemPermissionEdit editSystemPermission)
    {
        _mapper = mapper;
        _editSystemPermission = editSystemPermission;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(SystemPermissionEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<SystemPermissionEditCommand>(request);
        var result = await _editSystemPermission.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}