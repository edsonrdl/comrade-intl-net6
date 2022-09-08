using System.Threading;
using Comrade.Core.SystemPermissionCore.Commands;
using Comrade.Core.SystemPermissionCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.SystemPermissionCore.Handlers;

public class
    SystemPermissionEditCoreHandler : IRequestHandler<SystemPermissionEditCommand, ISingleResult<Entity>>
{
    private readonly ISystemPermissionEditValidation _systemPermissionEditValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ISystemPermissionRepository _repository;

    public SystemPermissionEditCoreHandler(ISystemPermissionEditValidation systemPermissionEditValidation,
        ISystemPermissionRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _systemPermissionEditValidation = systemPermissionEditValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(SystemPermissionEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new EditResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = await _systemPermissionEditValidation.Execute(request, recordExists)
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

    private static void HydrateValues(SystemPermission target, SystemPermission source)
    {
        target.Name = source.Name.ToUpper().Trim();
        target.Tag = source.Tag.ToUpper().Trim();
    }
}