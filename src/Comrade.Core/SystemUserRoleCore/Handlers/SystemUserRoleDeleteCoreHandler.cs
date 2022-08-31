using System.Threading;
using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.SystemUserRoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;
using Comrade.Core.SystemUserRoleCore.Commands;

namespace Comrade.Core.SystemUserRoleCore.Handlers;

public class
    SystemUserRoleDeleteCoreHandler : IRequestHandler<SystemUserRoleDeleteCommand, ISingleResult<Entity>>
{
    private readonly SystemUserRoleDeleteValidation _systemUserRoleDeleteValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ISystemUserRoleRepository _repository;

    public SystemUserRoleDeleteCoreHandler(SystemUserRoleDeleteValidation systemUserRoleDeleteValidation,
        ISystemUserRoleRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _systemUserRoleDeleteValidation = systemUserRoleDeleteValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(SystemUserRoleDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = _systemUserRoleDeleteValidation.Execute(recordExists);
        if (!validate.Success)
        {
            return validate;
        }

        var systemUserRoleId = recordExists.Id;
        _repository.Remove(systemUserRoleId);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(systemUserRoleId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.DeleteOne<SystemUserRole>(systemUserRoleId);

        return new DeleteResult<Entity>(true,
            BusinessMessage.MSG03);
    }
}