using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.UseCases;

public class UcFinancialInformationEdit : UseCase, IUcFinancialInformationEdit
{
    private readonly IMediator _mediator;

    public UcFinancialInformationEdit(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(FinancialInformationEditCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
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