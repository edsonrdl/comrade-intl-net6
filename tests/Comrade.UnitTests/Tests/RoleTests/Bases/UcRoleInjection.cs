using Comrade.Core.RoleCore.UseCases;
using MediatR;

namespace Comrade.UnitTests.Tests.RoleTests.Bases;

public sealed class UcRoleInjection
{
    public static UcRoleCreate GetUcRoleCreate(IMediator mediator)
    {
        return new UcRoleCreate(mediator);
    }

    public static UcRoleEdit GetUcRoleEdit(IMediator mediator)
    {
        return new UcRoleEdit(mediator);
    }
}