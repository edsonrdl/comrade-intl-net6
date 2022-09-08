using Comrade.Core.SystemPermissionCore.Commands;
using Comrade.Domain.Enums;

namespace Comrade.UnitTests.Tests.SystemPermissionTests.TestDatas;

internal class SystemPermissionCreateTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            EnumResponse.Created, new SystemPermissionCreateCommand
            {
                
                Name= "cabelo" ,
                Tag= "prego"

            }
        };
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}