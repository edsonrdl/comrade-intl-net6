using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.SystemUserCore;
using Comrade.Core.FinancialInformationCore;
using Comrade.Domain.Extensions;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;
public class FinancialInformationPasswordValidation
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IFinancialInformationRepository _financialInformationRepository;

    public FinancialInformationPasswordValidation(IFinancialInformationRepository financialInformationRepository,
        IPasswordHasher passwordHasher)
    {
        _financialInformationRepository = financialInformationRepository;
        _passwordHasher = passwordHasher;
    }

   
}