#region

using Comrade.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

#endregion

namespace Comrade.ComponentTests;

/// <summary>
/// </summary>
public sealed class CustomWebApplicationFactory : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(
            (context, config) =>
            {
                config.AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["JWT:Key"] =
                            "afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs",
                        ["AllowedHosts"] = "*",
                        ["FeatureManagement:Airplane"] = "true",
                        ["FeatureManagement:SystemUser"] = "true",
                        ["FeatureManagement:Common"] = "true",
                        ["FeatureManagement:HealthChecks"] = "false",
                        ["FeatureManagement:Swagger"] = "true",
                        ["FeatureManagement:Authentication"] = "true",
                        ["FeatureManagement:SQLServer"] = "false",
                        ["FeatureManagement:PostgresSql"] = "false",
                    });
            });
    }
}
