using Comrade.Api.Bases;
using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemUserRoleServices.Commands;
using Comrade.Application.Services.SystemUserRoleServices.Dtos;
using Comrade.Application.Services.SystemUserRoleServices.Queries;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Comrade.Api.UseCases.V1.SystemUserRoleApi;

// [Authorize]
[FeatureGate(CustomFeature.SystemUserRole)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class SystemUserRoleController : ComradeController
{
    private readonly ISystemUserRoleCommand _systemUserRoleCommand;
    private readonly ISystemUserRoleQuery _systemUserRoleQuery;
    private readonly ILogger<SystemUserRoleController> _logger;

    public SystemUserRoleController(ISystemUserRoleCommand systemUserRoleCommand,
        ISystemUserRoleQuery systemUserRoleQuery, ILogger<SystemUserRoleController> logger)
    {
        _systemUserRoleCommand = systemUserRoleCommand;
        _systemUserRoleQuery = systemUserRoleQuery;
        _logger = logger;
    }

    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _systemUserRoleQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    /// <summary>
    ///     Get an systemUserRole details.
    /// </summary>
    /// <param name="systemUserRoleId"></param>
    [HttpGet("get-by-id/{systemUserRoleId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute][Required] Guid systemUserRoleId)
    {
        try
        {
            var result = await _systemUserRoleQuery.GetByIdDefault(systemUserRoleId).ConfigureAwait(false);
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
    public async Task<IActionResult> Create([FromBody][Required] SystemUserRoleCreateDto dto)
    {
        try
        {
            var result = await _systemUserRoleCommand.Create(dto).ConfigureAwait(false);
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
    public async Task<IActionResult> Edit([FromBody][Required] SystemUserRoleEditDto dto)
    {
        try
        {
            var result = await _systemUserRoleCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{systemUserRoleId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute][Required] Guid systemUserRoleId)
    {
        try
        {
            var result = await _systemUserRoleCommand.Delete(systemUserRoleId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}