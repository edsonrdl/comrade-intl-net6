using Comrade.Domain.Bases;
using Comrade.Domain.Enums;

namespace Comrade.Domain.Models;

[Table("fiin_financial_information")]
public class FinancialInformation : Entity
{
    public FinancialInformation(){}

    public FinancialInformation(Guid id, EnumTypeFinancial type, DateTime dateTime, decimal value, string cpf, string card,string shop, string store)
    {
        Id = id;
        Type = type;
        DateTime = dateTime;
        Value = value;
        Cpf = cpf;
        Card = card;
        Shop = shop;
        Store = store;
    }

    [Column("fiin_nb_type", TypeName = "varchar")]
    public EnumTypeFinancial Type { get; set; }

    [Column("fiin_dt_dateTime", TypeName = "dateTime")]
    public DateTime DateTime { get; set; }

    [Column("fiin_dc_value", TypeName = "decimal(10, 2)")]
    public  decimal Value { get; set; }


    [Column("fiin_tx_cpf", TypeName = "varchar")]
    [MaxLength(11)]
    public string Cpf { get; set; } = null!;

    [Column("fiin_tx_card", TypeName = "varchar")]
    [MaxLength(12)]
    public string Card { get; set; } = null!;

    [Column("fiin_tx_shop", TypeName = "varchar")]
    [MaxLength(14)]
    public string Shop { get; set; } = null!;

    [Column("fiin_tx_store", TypeName = "varchar")]
    [MaxLength(19)]
    public string Store { get; set; } = null!;
}