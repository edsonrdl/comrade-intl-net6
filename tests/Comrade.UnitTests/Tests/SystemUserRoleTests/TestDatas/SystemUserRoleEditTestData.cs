﻿using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Domain.Enums;

namespace Comrade.UnitTests.Tests.SystemUserRoleTests.TestDatas;

internal class SystemUserRoleEditTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            EnumResponse.NoContent,
            new SystemUserRoleEditCommand
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5"),
                SystemUserId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9") ,
                RoleId= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9")
                
            }
        };
        yield return new object[]
        {
            EnumResponse.NotFound,
            new SystemUserRoleEditCommand
            {
                Id = new Guid("00000000-df8b-4f96-889a-75b9d67c546f"),
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