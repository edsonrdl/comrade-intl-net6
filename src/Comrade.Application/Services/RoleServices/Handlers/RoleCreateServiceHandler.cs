using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Core.RoleCore;
using Comrade.Core.RoleCore.Commands;
using MediatR;

namespace Comrade.Application.Services.RoleServices.Handlers;

public class
    RoleCreateServiceHandler : IRequestHandler<RoleCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcRoleCreate _createRole;
    private readonly IMapper _mapper;

    public RoleCreateServiceHandler(IMapper mapper, IUcRoleCreate createRole)
    {
        _mapper = mapper;
        _createRole = createRole;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(RoleCreateDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<RoleCreateCommand>(request);
        var result = await _createRole.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}