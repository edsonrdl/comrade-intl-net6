using Comrade.Api.Bases;
using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemPermissionServices.Commands;
using Comrade.Application.Services.SystemPermissionServices.Dtos;
using Comrade.Application.Services.SystemPermissionServices.Queries;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Comrade.Api.UseCases.V1.SystemPermissionApi;

// [Authorize]
[FeatureGate(CustomFeature.SystemPermission)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class SystemPermissionController : ComradeController
{
    private readonly ISystemPermissionCommand _systemPermissionCommand;
    private readonly ISystemPermissionQuery _systemPermissionQuery;
    private readonly ILogger<SystemPermissionController> _logger;

    public SystemPermissionController(ISystemPermissionCommand systemPermissionCommand,
        ISystemPermissionQuery systemPermissionQuery, ILogger<SystemPermissionController> logger)
    {
        _systemPermissionCommand = systemPermissionCommand;
        _systemPermissionQuery = systemPermissionQuery;
        _logger = logger;
    }

    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _systemPermissionQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    /// <summary>
    ///     Get an systemPermission details.
    /// </summary>
    /// <param name="systemPermissionId"></param>
    [HttpGet("get-by-id/{systemPermissionId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute][Required] Guid systemPermissionId)
    {
        try
        {
            var result = await _systemPermissionQuery.GetByIdDefault(systemPermissionId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPost("create")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
    public async Task<IActionResult> Create([FromBody][Required] SystemPermissionCreateDto dto)
    {
        try
        {
            var result = await _systemPermissionCommand.Create(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPut("edit")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
    public async Task<IActionResult> Edit([FromBody][Required] SystemPermissionEditDto dto)
    {
        try
        {
            var result = await _systemPermissionCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{systemPermissionId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute][Required] Guid systemPermissionId)
    {
        try
        {
            var result = await _systemPermissionCommand.Delete(systemPermissionId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}