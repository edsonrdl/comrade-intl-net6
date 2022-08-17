using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Comrade.Application.Bases;

namespace Comrade.Application.Services.RoleServices.Dtos;

public class RoleDto : EntityDto
{
    [DisplayName("Name")]
    [Required(ErrorMessage = "Please enter a name")]
    public string? Name { get; set; }

}