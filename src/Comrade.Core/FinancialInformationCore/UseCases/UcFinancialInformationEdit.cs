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
        target.Date = source.Date;
        target.Value = source.Value;
        target.Date = source.Date;
        target.CPF = source.CPF;
        target.Card = source.Card;
        target.Hour = source.Hour;
        target.Shop = source.Shop;
        target.Store = source.Store;
    }
}