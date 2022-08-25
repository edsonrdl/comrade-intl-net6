using Comrade.Core.RoleCore.Commands;

namespace Comrade.UnitTests.Tests.RoleTests.TestDatas;

internal class RoleCreateTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            201, new RoleCreateCommand
            {
                Name = "leite",
                
            }
        };
        yield return new object[]
        {
            409, new RoleCreateCommand
            {
                Name = "ADM",
                
            }
        };
       
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}