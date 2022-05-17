﻿using AutoMapper;
<<<<<<< HEAD
using Comrade.Application.Services.AirplaneServices.Dtos;
using Comrade.Application.Services.AuthenticationServices.Dtos;
using Comrade.Application.Services.SystemMenuServices.Dtos;
using Comrade.Application.Services.SystemUserServices.Dtos;
=======
using Comrade.Application.Components.AirplaneComponent.Dtos;
using Comrade.Application.Components.AuthenticationComponent.Dtos;
using Comrade.Application.Components.SystemUserComponent.Dtos;
>>>>>>> origin/feature/20
using Comrade.Core.AirplaneCore.Commands;
using Comrade.Core.SecurityCore.Commands;
using Comrade.Core.SystemMenuCore.Commands;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Domain.Models;

namespace Comrade.Application.AutoMapper;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<AirplaneDto, Airplane>();
        CreateMap<AirplaneCreateDto, AirplaneCreateCommand>();
        CreateMap<AirplaneEditDto, AirplaneEditCommand>();
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
        CreateMap<SystemMenuDto, SystemMenu>();
        CreateMap<SystemMenuCreateDto, SystemMenuCreateCommand>();
        CreateMap<SystemMenuEditDto, SystemMenuEditCommand>();
    }
}