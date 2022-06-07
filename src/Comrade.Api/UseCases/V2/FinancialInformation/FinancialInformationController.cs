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
    private readonly IFinancialInformationCommand -financialInformationCommand;
    private readonly IFinancialInformationQuery -financialInformationQuery;

    public FinancialInformationController(IFinancialInformationCommand financialInformationCommand,
        IFinancialInformationQuery financialInformationQuery)
    {
        -financialInformationCommand = financialInformationCommand;
        -financialInformationQuery = financialInformationQuery;
    }


    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await -financialInformationQuery.GetAll(paginationQuery).ConfigureAwait(false);
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
            var result = await -financialInformationQuery.GetByIdDefault(financialInformationId).ConfigureAwait(false);
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
            var result = await -financialInformationCommand.Create(dto).ConfigureAwait(false);
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
            var result = await -financialInformationCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{financialInformationId:int}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute][Required] Guid financialInformationId)
    {
        try
        {
            var result = await -financialInformationCommand.Delete(financialInformationId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}