using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.RoleCore.Commands;

public class RoleCreateCommand : Role, IRequest<ISingleResult<Entity>>
{
}