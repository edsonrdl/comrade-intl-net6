using Comrade.Domain.Bases;

namespace Comrade.Domain.Models;

[Table("fiin_financial_information")]
public class FinancialInformation : Entity
{
    public FinancialInformation(){}

    public FinancialInformation(Guid id, string type, string date, string
value, string cPF, string card,string hour,string shop, string store)
    {
        Id = id;
        Type = type;
        Date = date;
        Value = value;
        CPF = cPF;
        Card = card;
        Hour = hour;
        Shop = shop;
        Store = store;
    }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(1)]
    public string Type { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(8)]
    public string Date { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(10)]
    public string Value { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(11)]
    public string CPF { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(12)]
    public string Card { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(6)]
    public string Hour { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(6)]
    public string Shop { get; set; }

    [Column("fiin_tx_type", TypeName = "varchar")]
    [MaxLength(6)]
    public string Store { get; set; }
}