using System.Threading;
using Comrade.Core.SystemPermissionCore.Commands;
using Comrade.Core.SystemPermissionCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using MediatR;
using Comrade.Domain.Models;

namespace Comrade.Core.SystemPermissionCore.Handlers;

public class
    SystemPermissionCreateCoreHandler : IRequestHandler<SystemPermissionCreateCommand, ISingleResult<Entity>>
{
    private readonly ISystemPermissionCreateValidation _systemPermissionCreateValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ISystemPermissionRepository _repository;

    public SystemPermissionCreateCoreHandler(ISystemPermissionCreateValidation systemPermissionCreateValidation,
        ISystemPermissionRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _systemPermissionCreateValidation = systemPermissionCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(SystemPermissionCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await _systemPermissionCreateValidation.Execute(request).ConfigureAwait(false);
        if (!validate.Success)
        {
            return validate;
        }

        HydrateValues(request);


        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.Add(request).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.InsertOne(request);

        return new CreateResult<Entity>(true,
            BusinessMessage.MSG01);
    }
    private static void HydrateValues(SystemPermission source)
    {
        source.Name = source.Name.ToUpper().Trim();
        source.Tag = source.Tag.ToUpper().Trim();
    }
}