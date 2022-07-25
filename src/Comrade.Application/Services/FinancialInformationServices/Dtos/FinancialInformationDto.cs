using Comrade.Application.Bases;
using Comrade.Domain.Enums;

namespace Comrade.Application.Services.FinancialInformationServices.Dtos;

public class FinancialInformationDto : EntityDto
{
    public EnumTypeFinancial? Type { get; set; }
    public DateTime? DateTime { get; set; }
    public decimal? Value { get; set; }
    public string? Cpf { get; set; }
    public string? Card { get; set; }
    public string? Shop { get; set; }
    public string? Store { get; set; }
   
}