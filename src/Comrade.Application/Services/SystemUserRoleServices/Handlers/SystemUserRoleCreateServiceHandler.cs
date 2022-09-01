using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.Core.SystemUserRoleCore;
using Comrade.Core.SystemUserRoleCore.Commands;
using MediatR;

namespace Comrade.Application.Services.SystemUserRoleServices.Handlers;

public class
    SystemUserRoleCreateServiceHandler : IRequestHandler<SystemUserRoleCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcSystemUserRoleCreate _createSystemUserRole;
    private readonly IMapper _mapper;

    public SystemUserRoleCreateServiceHandler(IMapper mapper, IUcSystemUserRoleCreate createSystemUserRole)
    {
        _mapper = mapper;
        _createSystemUserRole = createSystemUserRole;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(SystemUserRoleCreateDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<SystemUserRoleCreateCommand>(request);
        var result = await _createSystemUserRole.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}