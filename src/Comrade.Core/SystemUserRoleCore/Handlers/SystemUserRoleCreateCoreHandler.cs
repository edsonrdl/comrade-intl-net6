using System.Threading;
using Comrade.Core.SystemUserRoleCore.Commands;
using Comrade.Core.SystemUserRoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using MediatR;


namespace Comrade.Core.SystemUserRoleCore.Handlers;

public class
    SystemUserRoleCreateCoreHandler : IRequestHandler<SystemUserRoleCreateCommand, ISingleResult<Entity>>
{
    private readonly ISystemUserRoleCreateValidation _systemUserRoleCreateValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ISystemUserRoleRepository _repository;

    public SystemUserRoleCreateCoreHandler(ISystemUserRoleCreateValidation systemUserRoleCreateValidation,
        ISystemUserRoleRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _systemUserRoleCreateValidation = systemUserRoleCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }
    public async Task<ISingleResult<Entity>> Handle(SystemUserRoleCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await _systemUserRoleCreateValidation.Execute(request).ConfigureAwait(false);
        if (!validate.Success)
        {
            return validate;
        }
        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.Add(request).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.InsertOne(request);

        return new CreateResult<Entity>(true,
            BusinessMessage.MSG01);
    }
}