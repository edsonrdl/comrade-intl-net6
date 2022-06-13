﻿using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Core.FinancialInformationCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Extensions;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.Handlers;

public class
    FinancialInformationCreateCoreHandler : IRequestHandler<FinancialInformationCreateCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IFinancialInformationRepository _repository;
    private readonly FinancialInformationCreateValidation _financialInformationCreateValidation;

    public FinancialInformationCreateCoreHandler(FinancialInformationCreateValidation financialInformationCreateValidation,
        IFinancialInformationRepository repository, IMongoDbCommandContext mongoDbContext,
        IPasswordHasher passwordHasher)
    {
        _financialInformationCreateValidation = financialInformationCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<ISingleResult<Entity>> Handle(FinancialInformationCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = _financialInformationCreateValidation.Execute(request);
        if (!validate.Success)
        {
            return validate;
        }

        request.Password = _passwordHasher.Hash(request.Password);
        request.RegisterDate = DateTimeBrasilia.GetDateTimeBrasilia();

        await _repository.Add(request).ConfigureAwait(false);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.Add(request).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        return new CreateResult<Entity>(true,
            BusinessMessage.MSG01);
    }
}