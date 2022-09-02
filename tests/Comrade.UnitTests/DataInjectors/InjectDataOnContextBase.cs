using System.Linq;
using Comrade.Domain.Models;
using Comrade.Persistence.DataAccess;
using Comrade.Persistence.Extensions;

namespace Comrade.UnitTests.DataInjectors;

public static class InjectDataOnContextBase
{
    private const string JsonPath = "Comrade.Persistence.SeedData";

    public static void InitializeDbForTests(ComradeContext db)
    {
        try
        {
            var deleted = db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            if (assembly is not null)
            {
                var airplaneJson = assembly.GetManifestResourceStream($"{JsonPath}.airplane.json");
                var airplanes = JsonUtilities.GetListFromJson<Airplane>(airplaneJson);
                var airplaneslIst = db.Airplanes.ToList();
                db.Airplanes.AddRange(airplanes!);

                var roleJson = assembly.GetManifestResourceStream($"{JsonPath}.role.json");
                var roles = JsonUtilities.GetListFromJson<Role>(roleJson);
                db.Roles.AddRange(roles!);

                var systemUserRoleJson = assembly.GetManifestResourceStream($"{JsonPath}.system-user-role.json");
                var systemUserRoles = JsonUtilities.GetListFromJson<SystemUserRole>(systemUserRoleJson);
                db.SystemUserRoles.AddRange(systemUserRoles!);

                var systemUserJson =
                    assembly.GetManifestResourceStream($"{JsonPath}.system-user.json");
                var systemUsers = JsonUtilities.GetListFromJson<SystemUser>(systemUserJson);
                db.SystemUsers.AddRange(systemUsers!);

                var financialInformationJson =
                    assembly.GetManifestResourceStream($"{JsonPath}.financial-information.json");
                var financialInformations = JsonUtilities.GetListFromJson<FinancialInformation>(financialInformationJson);
                db.FinancialInformations.AddRange(financialInformations!);
            }

            db.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}