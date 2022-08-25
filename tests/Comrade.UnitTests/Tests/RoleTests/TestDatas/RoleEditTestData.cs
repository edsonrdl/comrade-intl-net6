using Comrade.Core.RoleCore.Commands;

namespace Comrade.UnitTests.Tests.RoleTests.TestDatas;

internal class RoleEditTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            204,
            new RoleEditCommand
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "leite",
               
            }
        };
        yield return new object[]
        {
            404,
            new RoleEditCommand
            {
                Id = new Guid("00000000-df8b-4f96-889a-75b9d67c546f"),
                Name = "leite",
               
            }
        };
        yield return new object[]
        {
            409,
            new RoleEditCommand
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = " ADm ",

            }
        };
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}