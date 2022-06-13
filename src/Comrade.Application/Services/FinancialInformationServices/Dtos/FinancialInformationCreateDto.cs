using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Dtos;

public class FinancialInformationCreateDto : FinancialInformationDto, IRequest<SingleResultDto<EntityDto>>
{
}