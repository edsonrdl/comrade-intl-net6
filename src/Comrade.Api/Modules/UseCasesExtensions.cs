using Comrade.Application.Bases;
using Comrade.Application.Services.AirplaneServices.Commands;
using Comrade.Application.Services.AirplaneServices.Dtos;
using Comrade.Application.Services.AirplaneServices.Handlers;
using Comrade.Application.Services.AirplaneServices.Queries;
using Comrade.Application.Services.RoleServices.Commands;
using Comrade.Application.Services.RoleServices.Dtos;
using Comrade.Application.Services.RoleServices.Handlers;
using Comrade.Application.Services.RoleServices.Queries;
using Comrade.Application.Services.AuthenticationServices.Commands;
using Comrade.Application.Services.SystemUserServices.Commands;
using Comrade.Application.Services.SystemUserServices.Dtos;
using Comrade.Application.Services.SystemUserServices.Handlers;
using Comrade.Application.Services.SystemUserServices.Queries;
using Comrade.Application.Services.FinancialInformationServices.Commands;
using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Application.Services.FinancialInformationServices.Handlers;
using Comrade.Application.Services.FinancialInformationServices.Queries;
using Comrade.Core.AirplaneCore;
using Comrade.Core.AirplaneCore.Commands;
using Comrade.Core.AirplaneCore.Handlers;
using Comrade.Core.AirplaneCore.UseCases;
using Comrade.Core.AirplaneCore.Validations;
using Comrade.Core.RoleCore;
using Comrade.Core.RoleCore.Commands;
using Comrade.Core.RoleCore.Handlers;
using Comrade.Core.RoleCore.UseCases;
using Comrade.Core.RoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.SecurityCore;
using Comrade.Core.SecurityCore.Commands;
using Comrade.Core.SecurityCore.Handlers;
using Comrade.Core.SecurityCore.UseCases;
using Comrade.Core.SecurityCore.Validation;
using Comrade.Core.SystemUserCore;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Core.SystemUserCore.Handlers;
using Comrade.Core.SystemUserCore.UseCases;
using Comrade.Core.SystemUserCore.Validations;
using Comrade.Core.FinancialInformationCore;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Core.FinancialInformationCore.Handlers;
using Comrade.Core.FinancialInformationCore.UseCases;
using Comrade.Core.FinancialInformationCore.Validations;
using Comrade.Domain.Bases;
using MediatR;
namespace Comrade.Api.Modules;

/// <summary>
///     Adds Use Cases classes.
/// </summary>
public static class UseCasesExtensions
{
    /// <summary>
    ///     Adds Use Cases to the ServiceCollection.
    /// </summary>
    /// <param name="services">CoreService Collection.</param>
    /// <returns>The modified instance.</returns>
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        #region Authentication

        // Application - Services
        services.AddScoped<IAuthenticationCommand, AuthenticationCommand>();

        // Core - UseCases
        services.AddScoped<IUcUpdatePassword, UcUpdatePassword>();
        services.AddScoped<IUcValidateLogin, UcValidateLogin>();
        services.AddScoped<IUcForgotPassword, UcForgotPassword>();
        services.AddScoped<IUcGenerateToken, UcGenerateToken>();

        // Core - CoreHandlers
        services
            .AddScoped<IRequestHandler<ForgotPasswordCommand, ISingleResult<Entity>>,
                ForgotPasswordCoreHandler>();
        services
            .AddScoped<IRequestHandler<GenerateTokenCommand, string>,
                GenerateTokenCoreHandler>();
        services
            .AddScoped<IRequestHandler<UpdatePasswordCommand, ISingleResult<Entity>>,
                UpdatePasswordCoreHandler>();

        #endregion

        #region Airplane

        // Application - Services
        services.AddScoped<IAirplaneCommand, AirplaneCommand>();
        services.AddScoped<IAirplaneQuery, AirplaneQuery>();

        // Application - ServiceHandlers
        services
            .AddScoped<IRequestHandler<AirplaneCreateDto, SingleResultDto<EntityDto>>,
                AirplaneCreateServiceHandler>();
        services
            .AddScoped<IRequestHandler<AirplaneEditDto, SingleResultDto<EntityDto>>,
                AirplaneEditServiceHandler>();

        // Core - UseCases
        services.AddScoped<IUcAirplaneEdit, UcAirplaneEdit>();
        services.AddScoped<IUcAirplaneCreate, UcAirplaneCreate>();
        services.AddScoped<IUcAirplaneDelete, UcAirplaneDelete>();

        // Core - CoreHandlers
        services
            .AddScoped<IRequestHandler<AirplaneCreateCommand, ISingleResult<Entity>>,
                AirplaneCreateCoreHandler>();
        services
            .AddScoped<IRequestHandler<AirplaneDeleteCommand, ISingleResult<Entity>>,
                AirplaneDeleteCoreHandler>();
        services
            .AddScoped<IRequestHandler<AirplaneEditCommand, ISingleResult<Entity>>,
                AirplaneEditCoreHandler>();

        // Core - Validations
        services.AddScoped<IAirplaneEditValidation, AirplaneEditValidation>();
        services.AddScoped<AirplaneDeleteValidation>();
        services.AddScoped<AirplaneCreateValidation>();
        services.AddScoped<AirplaneValidateSameCode>();

        #endregion

        #region Role

        // Application - Services
        services.AddScoped<IRoleCommand, RoleCommand>();
        services.AddScoped<IRoleQuery, RoleQuery>();

        // Application - ServiceHandlers
        services
            .AddScoped<IRequestHandler<RoleCreateDto, SingleResultDto<EntityDto>>,
                RoleCreateServiceHandler>();
        services
            .AddScoped<IRequestHandler<RoleEditDto, SingleResultDto<EntityDto>>,
                RoleEditServiceHandler>();

        // Core - UseCases
        services.AddScoped<IUcRoleEdit, UcRoleEdit>();
        services.AddScoped<IUcRoleCreate, UcRoleCreate>();
        services.AddScoped<IUcRoleDelete, UcRoleDelete>();

        // Core - CoreHandlers
        services
            .AddScoped<IRequestHandler<RoleCreateCommand, ISingleResult<Entity>>,
                RoleCreateCoreHandler>();
        services
            .AddScoped<IRequestHandler<RoleDeleteCommand, ISingleResult<Entity>>,
                RoleDeleteCoreHandler>();
        services
            .AddScoped<IRequestHandler<RoleEditCommand, ISingleResult<Entity>>,
                RoleEditCoreHandler>();

        // Core - Validations
        services.AddScoped<IRoleEditValidation, RoleEditValidation>();
        services.AddScoped<RoleDeleteValidation>();
        services.AddScoped<RoleCreateValidation>();
        services.AddScoped<RoleValidateSameCode>();

        #endregion

        #region SystemUser

        // Application - Services
        services.AddScoped<ISystemUserCommand, SystemUserCommand>();
        services.AddScoped<ISystemUserQuery, SystemUserQuery>();

        // Application - Handlers
        services
            .AddScoped<IRequestHandler<SystemUserCreateDto, SingleResultDto<EntityDto>>,
                SystemUserCreateHandler>();
        services
            .AddScoped<IRequestHandler<SystemUserEditDto, SingleResultDto<EntityDto>>,
                SystemUserEditHandler>();

        // Core - UseCases
        services.AddScoped<IUcSystemUserEdit, UcSystemUserEdit>();
        services.AddScoped<IUcSystemUserCreate, UcSystemUserCreate>();
        services.AddScoped<IUcSystemUserDelete, UcSystemUserDelete>();

        // Core - CoreHandlers
        services
            .AddScoped<IRequestHandler<SystemUserCreateCommand, ISingleResult<Entity>>,
                SystemUserCreateCoreHandler>();
        services
            .AddScoped<IRequestHandler<SystemUserDeleteCommand, ISingleResult<Entity>>,
                SystemUserDeleteCoreHandler>();
        services
            .AddScoped<IRequestHandler<SystemUserEditCommand, ISingleResult<Entity>>,
                SystemUserEditCoreHandler>();

        // Core - Validations
        services.AddScoped<SystemUserForgotPasswordValidation>();
        services.AddScoped<SystemUserPasswordValidation>();
        services.AddScoped<SystemUserEditValidation>();
        services.AddScoped<SystemUserDeleteValidation>();
        services.AddScoped<SystemUserCreateValidation>();

        #endregion

        #region FinancialInformation

        // Application - Services
        services.AddScoped<IFinancialInformationCommand, FinancialInformationCommand>();
        services.AddScoped<IFinancialInformationQuery, FinancialInformationQuery>();

        // Application - Handlers
        services
            .AddScoped<IRequestHandler<FinancialInformationCreateDto, SingleResultDto<EntityDto>>,
                FinancialInformationCreateHandler>();
        services
            .AddScoped<IRequestHandler<FinancialInformationCreateManyDto, SingleResultDto<EntityDto>>,
                FinancialInformationCreateManyHandler>();
        services
            .AddScoped<IRequestHandler<FinancialInformationCreateManyDto, SingleResultDto<EntityDto>>,
                FinancialInformationCreateManyHandler>();
        services
            .AddScoped<IRequestHandler<FinancialInformationEditDto, SingleResultDto<EntityDto>>,
                FinancialInformationEditHandler>();

        // Core - UseCases
        services.AddScoped<IUcFinancialInformationEdit, UcFinancialInformationEdit>();
        services.AddScoped<IUcFinancialInformationCreate, UcFinancialInformationCreate>();
        services.AddScoped<IUcFinancialInformationCreateMany, UcFinancialInformationCreateMany>();
        services.AddScoped<IUcFinancialInformationDelete, UcFinancialInformationDelete>();

        // Core - CoreHandlers
        services
            .AddScoped<IRequestHandler<FinancialInformationCreateCommand, ISingleResult<Entity>>,
                FinancialInformationCreateCoreHandler>();
        services
            .AddScoped<IRequestHandler<FinancialInformationCreateManyCommand, ISingleResult<Entity>>,
                FinancialInformationCreateManyCoreHandler>();
        services
            .AddScoped<IRequestHandler<FinancialInformationDeleteCommand, ISingleResult<Entity>>,
                FinancialInformationDeleteCoreHandler>();
        services
            .AddScoped<IRequestHandler<FinancialInformationEditCommand, ISingleResult<Entity>>,
                FinancialInformationEditCoreHandler>();

        // Core - Validations
        services.AddScoped<FinancialInformationForgotPasswordValidation>();
        services.AddScoped<FinancialInformationPasswordValidation>();
        services.AddScoped<FinancialInformationEditValidation>();
        services.AddScoped<FinancialInformationDeleteValidation>();
        services.AddScoped<IFinancialInformationCreateValidation,FinancialInformationCreateValidation>();
        services.AddScoped<FinancialInformationCreateManyValidation>();
        services.AddScoped<FinancialInformationValueByTypeValidation>();

        #endregion

        return services;
    }
}
