using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.Core.SystemUserRoleCore;
using Comrade.Core.SystemUserRoleCore.Commands;
using MediatR;

namespace Comrade.Application.Services.SystemUserRoleServices.Handlers;

public class
    SystemUserRoleEditServiceHandler : IRequestHandler<SystemUserRoleEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcSystemUserRoleEdit _editSystemUserRole;
    private readonly IMapper _mapper;

    public SystemUserRoleEditServiceHandler(IMapper mapper, IUcSystemUserRoleEdit editSystemUserRole)
    {
        _mapper = mapper;
        _editSystemUserRole = editSystemUserRole;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(SystemUserRoleEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<SystemUserRoleEditCommand>(request);
        var result = await _editSystemUserRole.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}