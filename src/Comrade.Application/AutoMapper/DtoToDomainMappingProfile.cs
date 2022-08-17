using AutoMapper;
using Comrade.Application.Services.AirplaneServices.Dtos;
using Comrade.Application.Services.AuthenticationServices.Dtos;
using Comrade.Application.Services.SystemUserServices.Dtos;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.AirplaneCore.Commands;
using Comrade.Core.SecurityCore.Commands;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Models;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Core.RoleCore.Commands;

namespace Comrade.Application.AutoMapper;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<AirplaneDto, Airplane>();
        CreateMap<AirplaneCreateDto, AirplaneCreateCommand>();
        CreateMap<AirplaneEditDto, AirplaneEditCommand>();
        CreateMap<RoleDto, Role>();
        CreateMap<RoleCreateDto, RoleCreateCommand>();
        CreateMap<RoleEditDto, RoleEditCommand>();
        CreateMap<SystemUserDto, SystemUser>();
        CreateMap<SystemUserDto, SystemUserCreateCommand>();
        CreateMap<SystemUserDto, SystemUserEditCommand>();
        CreateMap<AuthenticationDto, SystemUser>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<AuthenticationDto, UpdatePasswordCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<AuthenticationDto, ForgotPasswordCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<AirplaneDto, Airplane>();
        CreateMap<AirplaneCreateDto, AirplaneCreateCommand>();
        CreateMap<AirplaneEditDto, AirplaneEditCommand>();
        CreateMap<RoleDto, Role>();
        CreateMap<RoleCreateDto, RoleCreateCommand>();
        CreateMap<RoleEditDto, RoleEditCommand>();
        CreateMap<FinancialInformationDto, FinancialInformation>();
        CreateMap<FinancialInformationDto, FinancialInformationCreateCommand>();
        CreateMap<FinancialInformationCreateManyDto, FinancialInformationCreateManyCommand>();
        CreateMap<FinancialInformationDto, FinancialInformationEditCommand>();
        CreateMap<AuthenticationDto, FinancialInformation>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key));
        CreateMap<AuthenticationDto, UpdatePasswordCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        CreateMap<AuthenticationDto, ForgotPasswordCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
    }
}