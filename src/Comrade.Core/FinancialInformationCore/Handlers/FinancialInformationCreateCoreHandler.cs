using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Core.FinancialInformationCore.Validations;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.Handlers;

public class
    FinancialInformationCreateCoreHandler : IRequestHandler<FinancialInformationCreateCommand, ISingleResult<Entity>>
{
    private readonly IFinancialInformationRepository _repository;
    private readonly IFinancialInformationCreateValidation _financialInformationCreateValidation;

    public FinancialInformationCreateCoreHandler(IFinancialInformationCreateValidation financialInformationCreateValidation,
        IFinancialInformationRepository repository)
    {
        _financialInformationCreateValidation = financialInformationCreateValidation;
        _repository = repository;
    }

    public async Task<ISingleResult<Entity>> Handle(FinancialInformationCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = _financialInformationCreateValidation.Execute(request);
        if (!validate.Success)
        {
            return validate;
        }

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.Add(request).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        return new CreateResult<Entity>(true,
            BusinessMessage.MSG01);
    }
}