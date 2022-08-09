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
    FinancialInformationEditCoreHandler : IRequestHandler<FinancialInformationEditCommand, ISingleResult<Entity>>
{
    private readonly IFinancialInformationRepository _repository;
    private readonly FinancialInformationEditValidation _financialInformationEditValidation;

    public FinancialInformationEditCoreHandler(FinancialInformationEditValidation financialInformationEditValidation,
        IFinancialInformationRepository repository)
    {
        _financialInformationEditValidation = financialInformationEditValidation;
        _repository = repository;
    }

    public async Task<ISingleResult<Entity>> Handle(FinancialInformationEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var result = _financialInformationEditValidation.Execute(request);
        if (!result.Success)
        {
            return result;
        }

        var obj = recordExists;

        HydrateValues(obj, request);

        _repository.Update(obj);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Update(obj);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        //_mongoDbContext.ReplaceOne(obj);

        return new EditResult<Entity>(true,
            BusinessMessage.MSG02);
    }

    private static void HydrateValues(FinancialInformation target, FinancialInformation source)
    {
        target.Id = source.Id;
        target.Type = source.Type;
        target.DateTime = source.DateTime;
        target.Value = source.Value;
        target.Cpf = source.Cpf;
        target.Card = source.Card;
        target.Shop = source.Shop;
        target.Store = source.Store;
    }
}