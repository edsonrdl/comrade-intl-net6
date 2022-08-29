using System.Threading;
using Comrade.Core.RoleCore.Commands;
using Comrade.Core.RoleCore.Validations;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Extensions;
using MediatR;
using Comrade.Domain.Models;

namespace Comrade.Core.RoleCore.Handlers;

public class
    RoleCreateCoreHandler : IRequestHandler<RoleCreateCommand, ISingleResult<Entity>>
{
    private readonly RoleCreateValidation _roleCreateValidation;
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IRoleRepository _repository;

    public RoleCreateCoreHandler(RoleCreateValidation roleCreateValidation,
        IRoleRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _roleCreateValidation = roleCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(RoleCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await _roleCreateValidation.Execute(request).ConfigureAwait(false);
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
    private static void HydrateValues( Role source)
    {
        source.Name = source.Name.ToUpper().Trim();
    }
}