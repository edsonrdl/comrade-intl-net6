using Comrade.Domain.Bases.Interfaces;
using Comrade.Domain.Enums;

namespace Comrade.Domain.Bases;

public class Lookup : ILookup
{
    public Guid Key { get; set; }
    public string? Value { get; set; }
}