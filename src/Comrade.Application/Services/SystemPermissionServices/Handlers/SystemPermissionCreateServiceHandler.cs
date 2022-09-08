using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.Core.SystemPermissionCore;
using Comrade.Core.SystemPermissionCore.Commands;
using MediatR;

namespace Comrade.Application.Services.SystemPermissionServices.Handlers;

public class
    SystemPermissionCreateServiceHandler : IRequestHandler<SystemPermissionCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcSystemPermissionCreate _createSystemPermission;
    private readonly IMapper _mapper;

    public SystemPermissionCreateServiceHandler(IMapper mapper, IUcSystemPermissionCreate createSystemPermission)
    {
        _mapper = mapper;
        _createSystemPermission = createSystemPermission;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(SystemPermissionCreateDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<SystemPermissionCreateCommand>(request);
        var result = await _createSystemPermission.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}