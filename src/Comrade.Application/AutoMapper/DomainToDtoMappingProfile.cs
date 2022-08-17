using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Lookups;
using Comrade.Application.Services.AirplaneServices.Dtos;
using Comrade.Application.Services.AuthenticationServices.Dtos;
using Comrade.Application.Services.SystemUserServices.Dtos;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Application.AutoMapper;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Entity, EntityDto>();
        CreateMap<Lookup, LookupDto>();
        CreateMap<Airplane, AirplaneDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<SystemUser, SystemUserDto>();
        CreateMap<SystemUser, AuthenticationDto>();
        CreateMap<FinancialInformation, FinancialInformationDto>();
        CreateMap<FinancialInformation, AuthenticationDto>()
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id));
            
    }
}