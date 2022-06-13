using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.FinancialInformationServices.Dtos;

namespace Comrade.Application.Services.FinancialInformationServices.Commands;

public interface IFinancialInformationCommand
{
    Task<ISingleResultDto<EntityDto>> Create(FinancialInformationCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(FinancialInformationEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}