using System.Threading;
using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.SystemUserRoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.SystemUserRoleCore.Handlers;

public class
    SystemUserRoleEditCoreHandler : IRequestHandler<SystemUserRoleEditCommand, ISingleResult<Entity>>
{
    private readonly ISystemUserRoleEditValidation _systemUserRoleEditValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ISystemUserRoleRepository _repository;

    public SystemUserRoleEditCoreHandler(ISystemUserRoleEditValidation systemUserRoleEditValidation,
        ISystemUserRoleRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _systemUserRoleEditValidation = systemUserRoleEditValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(SystemUserRoleEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new EditResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = await _systemUserRoleEditValidation.Execute(request, recordExists)
            .ConfigureAwait(false);

        if (!validate.Success)
        {
            return validate;
        }

        var obj = recordExists;
        HydrateValues(obj, request);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Update(obj);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.ReplaceOne(obj);

        return new EditResult<Entity>(true,
            BusinessMessage.MSG02);
    }

    private static void HydrateValues(SystemUserRole target, SystemUserRole source)
    {
        target.SystemUserId = source.SystemUserId;
        target.RoleId = source.RoleId;
    }
}