using Comrade.Application.Services.FinancialInformationServices.Dtos;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Enums;

namespace Comrade.UnitTests.Tests.FinancialInformationTests.TestDatas;

internal class FinancialInformationCreateTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Credit,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 130,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Credit,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 129,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Credit,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 890,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Credit,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 891,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Debit,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 2,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Debit,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 3,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };
        yield return new object[]
        {
            201, new FinancialInformationCreateCommand
            {
                Type = EnumTypeFinancial.Ticket,
                DateTime = new DateTime(2019 / 04 / 01),
                Value = 10,
                Cpf = "28574635211",
                Card = "123456789123",
                Shop = "café",
                Store = "cafeteria "
            }
        };

    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}