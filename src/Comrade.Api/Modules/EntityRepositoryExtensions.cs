using Comrade.Core.AirplaneCore;
using Comrade.Core.RoleCore;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.SystemUserCore;
using Comrade.Core.FinancialInformationCore;
using Comrade.Core.SystemPermissionCore;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Repositories;

namespace Comrade.Api.Modules;

/// <summary>
///     Persistence Extensions.
/// </summary>
public static class EntityRepositoryExtensions
{
    /// <summary>
    ///     Add Persistence dependencies varying on configuration.
    /// </summary>
    public static IServiceCollection AddEntityRepository(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAirplaneRepository, AirplaneRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ISystemPermissionRepository, SystemPermissionRepository>();
        services.AddScoped<ISystemUserRepository, SystemUserRepository>();
        services.AddScoped<IFinancialInformationRepository, FinancialInformationRepository>();

        return services;
    }

}
