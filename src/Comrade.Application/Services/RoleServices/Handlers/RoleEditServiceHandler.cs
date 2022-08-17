using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Core.RoleCore;
using Comrade.Core.RoleCore.Commands;
using MediatR;

namespace Comrade.Application.Services.RoleServices.Handlers;

public class
    RoleEditServiceHandler : IRequestHandler<RoleEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcRoleEdit _editRole;
    private readonly IMapper _mapper;

    public RoleEditServiceHandler(IMapper mapper, IUcRoleEdit editRole)
    {
        _mapper = mapper;
        _editRole = editRole;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(RoleEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<RoleEditCommand>(request);
        var result = await _editRole.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}