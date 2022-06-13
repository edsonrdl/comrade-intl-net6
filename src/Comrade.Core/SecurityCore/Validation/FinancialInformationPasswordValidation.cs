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

    public ISingleResult<FinancialInformation> Execute(Guid key, string password)
    {
        var usuSession = _financialInformationRepository.GetById(key).Result;
        var keyValidation = usuSession != null;

        if (keyValidation)
        {
            var (verified, needsUpgrade) = _passwordHasher.Check(usuSession!.Password, password);

            if (!verified)
            {
                return new SingleResult<FinancialInformation>(1001,
                    "Usuário ou password informados não são válidos");
            }

            if (needsUpgrade)
            {
                return new SingleResult<FinancialInformation>(1009,
                    "Senha precisa ser atualizada");
            }


            return new SingleResult<FinancialInformation>(usuSession);
        }


        return new SingleResult<FinancialInformation>(1001,
            "Usuário ou password informados não são válidos");
    }
}