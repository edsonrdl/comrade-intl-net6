using Comrade.Application.Bases;

namespace Comrade.Application.Services.FinancialInformationServices.Dtos;

public class FinancialInformationDto : EntityDto
{
    public string? Type { get; set; }
    public string? Date { get; set; }
    public string? Value { get; set; }
    public string? CPF { get; set; }
    public string? Card { get; set; }
    public string? Hour { get; set; }
    public string? Shop { get; set; }
    public string? Store { get; set; }
   
}