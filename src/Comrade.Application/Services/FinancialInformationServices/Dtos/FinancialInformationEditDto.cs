using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Dtos;

public class FinancialInformationEditDto : FinancialInformationDto, IRequest<SingleResultDto<EntityDto>>
{
}