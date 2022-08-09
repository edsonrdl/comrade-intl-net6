using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Enums;
using Comrade.Domain.Models;

namespace Comrade.Core.FinancialInformationCore.Validations;

public class FinancialInformationValueByTypeValidation
{
    public ISingleResult<Entity> Execute(FinancialInformation entity)
    {
        var result = new SingleResult<Entity>();
        switch (entity.Type)
        {
            case EnumTypeFinancial.Debit:
                result = ValueByDebitValidation(entity.Value);
                break;
            case EnumTypeFinancial.Ticket:
                result = ValueByTicketValidation(entity.Value);
                break;
            case EnumTypeFinancial.Credit:
                result = ValueByCreditValidation(entity.Value);
                break;
        }
        return result;
    }

    private static SingleResult<Entity> ValueByDebitValidation(decimal value)
    {
        if (value>=3) return new SingleResult<Entity>();

        return new SingleResult<Entity>((int)EnumResponse.ErrorBusinessValidation,
            BusinessMessage.MSG10);
    }
    private static SingleResult<Entity> ValueByTicketValidation(decimal value)
    {
        if (value >= 100) return new SingleResult<Entity>();

        return new SingleResult<Entity>((int)EnumResponse.ErrorBusinessValidation,
            BusinessMessage.MSG11);
    }
    private static SingleResult<Entity> ValueByCreditValidation(decimal value)
    {
        if (value is >= 130 and <= 890 ) return new SingleResult<Entity>();

        return new SingleResult<Entity>((int)EnumResponse.ErrorBusinessValidation,
            BusinessMessage.MSG12);
    }
}