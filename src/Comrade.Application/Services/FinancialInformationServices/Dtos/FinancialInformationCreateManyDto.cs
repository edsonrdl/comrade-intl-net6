using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.FinancialInformationServices.Dtos;

public class FinancialInformationCreateManyDto : IRequest<SingleResultDto<EntityDto>>
{
    public ICollection<FinancialInformationDto> FinancialInformations { get; set; }
}