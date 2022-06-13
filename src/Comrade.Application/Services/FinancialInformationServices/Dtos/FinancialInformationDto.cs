using Comrade.Application.Bases;

namespace Comrade.Application.Services.FinancialInformationServices.Dtos;

public class FinancialInformationDto : EntityDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Registration { get; set; }
    public DateTime? RegisterDate { get; set; }
}