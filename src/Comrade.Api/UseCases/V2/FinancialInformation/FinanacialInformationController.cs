using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.FinancialInformationServices.Commands;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Application.Services.FinancialInformationServices.Queries;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Comrade.Api.UseCases.V2.FinancialInformationApi;

// [Authorize]
[FeatureGate(CustomFeature.FinancialInformation)]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class FinancialInformationController : ControllerBase
{
    private readonly IFinancialInformationCommand _financialInformationCommand;
    private readonly IFinancialInformationQuery _financialInformationQuery;

    public FinancialInformationController(IFinancialInformationCommand financialInformationCommand,
        IFinancialInformationQuery financialInformationQuery)
    {
        _financialInformationCommand = financialInformationCommand;
        _financialInformationQuery = financialInformationQuery;
    }


    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _financialInformationQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }


    [HttpGet("get-by-id/{financialInformationId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute][Required] Guid financialInformationId)
    {
        try
        {
            var result = await _financialInformationQuery.GetByIdDefault(financialInformationId).ConfigureAwait(false);
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
    public async Task<IActionResult> Create([FromBody][Required] FinancialInformationCreateDto dto)
    {
        try
        {
            var result = await _financialInformationCommand.Create(dto).ConfigureAwait(false);
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
    public async Task<IActionResult> Edit([FromBody][Required] FinancialInformationEditDto dto)
    {
        try
        {
            var result = await _financialInformationCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{financialInformationId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute][Required] Guid financialInformationId)
    {
        try
        {
            var result = await _financialInformationCommand.Delete(financialInformationId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}