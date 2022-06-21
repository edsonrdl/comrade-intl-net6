using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Core.FinancialInformationCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.Handlers;

public class
    FinancialInformationDeleteCoreHandler : IRequestHandler<FinancialInformationDeleteCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IFinancialInformationRepository _repository;
    private readonly FinancialInformationDeleteValidation _financialInformationDeleteValidation;

    public FinancialInformationDeleteCoreHandler(FinancialInformationDeleteValidation financialInformationDeleteValidation,
        IFinancialInformationRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _financialInformationDeleteValidation = financialInformationDeleteValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(FinancialInformationDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = _financialInformationDeleteValidation.Execute(recordExists);
        if (!validate.Success)
        {
            return validate;
        }

        var financialInformationId = recordExists.Id;
        _repository.Remove(financialInformationId);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(financialInformationId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        //_mongoDbContext.DeleteOne<FinancialInformation>(financialInformationId);

        return new DeleteResult<Entity>(true,
            BusinessMessage.MSG03);
    }
}