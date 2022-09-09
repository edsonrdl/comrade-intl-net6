using Comrade.Core.SystemPermissionCore.Commands;
using Comrade.Domain.Enums;

namespace Comrade.UnitTests.Tests.SystemPermissionTests.TestDatas;

internal class SystemPermissionEditTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            EnumResponse.NoContent,
            new SystemPermissionEditCommand
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5"),
                Name= "joelho" ,
                Tag= "dedo"
                
            }
        };
        yield return new object[]
        {
            EnumResponse.NotFound,
            new SystemPermissionEditCommand
            {
                Id = new Guid("00000000-df8b-4f96-889a-75b9d67c546f"),
                Name= "xuxa",
                Tag= "leite"

            }
        };
        yield return new object[]
        {
            EnumResponse.ErrorBusinessValidation,
            new SystemPermissionEditCommand
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5"),
                Name= "taxa",
                Tag= "  LEite  "

            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}