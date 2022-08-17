using Comrade.Api.Bases;
using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.RoleServices.Commands;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Application.Services.RoleServices.Queries;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Comrade.Api.UseCases.V1.RoleApi;

// [Authorize]
[FeatureGate(CustomFeature.Role)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class RoleController : ComradeController
{
    private readonly IRoleCommand _roleCommand;
    private readonly IRoleQuery _roleQuery;
    private readonly ILogger<RoleController> _logger;

    public RoleController(IRoleCommand roleCommand,
        IRoleQuery roleQuery, ILogger<RoleController> logger)
    {
        _roleCommand = roleCommand;
        _roleQuery = roleQuery;
        _logger = logger;
    }

    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _roleQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    /// <summary>
    ///     Get an role details.
    /// </summary>
    /// <param name="roleId"></param>
    [HttpGet("get-by-id/{roleId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute][Required] Guid roleId)
    {
        try
        {
            var result = await _roleQuery.GetByIdDefault(roleId).ConfigureAwait(false);
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
    public async Task<IActionResult> Create([FromBody][Required] RoleCreateDto dto)
    {
        try
        {
            var result = await _roleCommand.Create(dto).ConfigureAwait(false);
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
    public async Task<IActionResult> Edit([FromBody][Required] RoleEditDto dto)
    {
        try
        {
            var result = await _roleCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{roleId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute][Required] Guid roleId)
    {
        try
        {
            var result = await _roleCommand.Delete(roleId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}