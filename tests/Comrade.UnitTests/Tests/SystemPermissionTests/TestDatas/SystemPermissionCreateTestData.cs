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
        yield return new object[]
        {
            409, new SystemPermissionCreateCommand
            {
                Name = "ADM",
                Tag= "  LEite"

            }
        };
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}