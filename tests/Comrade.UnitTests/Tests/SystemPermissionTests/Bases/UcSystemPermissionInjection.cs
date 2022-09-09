using Comrade.Core.SystemPermissionCore.UseCases;
using MediatR;

namespace Comrade.UnitTests.Tests.SystemPermissionTests.Bases;

public sealed class UcSystemPermissionInjection
{
    public static UcSystemPermissionCreate GetUcSystemPermissionCreate(IMediator mediator)
    {
        return new UcSystemPermissionCreate(mediator);
    }

    public static UcSystemPermissionEdit GetUcSystemPermissionEdit(IMediator mediator)
    {
        return new UcSystemPermissionEdit(mediator);
    }
}