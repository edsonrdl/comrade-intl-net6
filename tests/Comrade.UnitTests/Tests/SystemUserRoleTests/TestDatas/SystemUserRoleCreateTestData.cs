using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Domain.Enums;

namespace Comrade.UnitTests.Tests.SystemUserRoleTests.TestDatas;

internal class SystemUserRoleCreateTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            EnumResponse.Created, new SystemUserRoleCreateCommand
            {
                
                SystemUserId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9") ,
                RoleId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9")

            }
        };
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}