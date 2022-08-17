using System.Threading;
using Comrade.Core.RoleCore.Commands;
using Comrade.Core.RoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.RoleCore.Handlers;

public class
    RoleDeleteCoreHandler : IRequestHandler<RoleDeleteCommand, ISingleResult<Entity>>
{
    private readonly RoleDeleteValidation _roleDeleteValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IRoleRepository _repository;

    public RoleDeleteCoreHandler(RoleDeleteValidation roleDeleteValidation,
        IRoleRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _roleDeleteValidation = roleDeleteValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(RoleDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = _roleDeleteValidation.Execute(recordExists);
        if (!validate.Success)
        {
            return validate;
        }

        var roleId = recordExists.Id;
        _repository.Remove(roleId);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(roleId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.DeleteOne<Role>(roleId);

        return new DeleteResult<Entity>(true,
            BusinessMessage.MSG03);
    }
}