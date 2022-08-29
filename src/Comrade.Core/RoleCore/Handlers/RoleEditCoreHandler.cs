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
    RoleEditCoreHandler : IRequestHandler<RoleEditCommand, ISingleResult<Entity>>
{
    private readonly IRoleEditValidation _roleEditValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IRoleRepository _repository;

    public RoleEditCoreHandler(IRoleEditValidation roleEditValidation,
        IRoleRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _roleEditValidation = roleEditValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(RoleEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new EditResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = await _roleEditValidation.Execute(request, recordExists)
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

    private static void HydrateValues(Role target, Role source)
    {
        target.Name = source.Name.ToUpper().Trim();
    }
}