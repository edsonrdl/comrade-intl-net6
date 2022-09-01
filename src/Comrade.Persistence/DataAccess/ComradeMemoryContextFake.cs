using Comrade.Domain.Models;
using Comrade.Persistence.Extensions;

namespace Comrade.Persistence.DataAccess;

public static class ComradeMemoryContextFake
{
    private const string JsonPath = "Comrade.Persistence.SeedData";
    private static readonly object SyncLock = new();

    /// <summary>
    ///     To reset memory database use -> context.Database.EnsureDeleted().
    /// </summary>
    public static void AddDataFakeContext(ComradeContext? context)
    {
        var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

        if (context != null && context.Airplanes.Any())
        {
            return;
        }

        lock (SyncLock)
        {
            if (context != null && assembly is not null)
            {
                var airplanes =
                    JsonUtilities.GetListFromJson<Airplane>(
                        assembly.GetManifestResourceStream($"{JsonPath}.airplane.json"));
                var roles =
                    JsonUtilities.GetListFromJson<Role>(
                        assembly.GetManifestResourceStream($"{JsonPath}.role.json"));
                var systemUserRoles =
                    JsonUtilities.GetListFromJson<SystemUserRole>(
                        assembly.GetManifestResourceStream($"{JsonPath}.system-user-role.json"));
                var systemUser = JsonUtilities.GetListFromJson<SystemUser>(
                    assembly.GetManifestResourceStream($"{JsonPath}.system-user.json"));

                context.Airplanes.AddRange(airplanes!);
                context.Roles.AddRange(roles!);
                context.SystemUserRoles.AddRange(systemUserRoles!);
                context.SystemUsers.AddRange(systemUser!);

                if (context.Airplanes.Any())
                {
                    return;
                }

                context.SaveChanges();
            }
        }
    }
}