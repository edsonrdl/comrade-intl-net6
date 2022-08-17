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
    FinancialInformationCreateManyCoreHandler : IRequestHandler<FinancialInformationCreateManyCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IFinancialInformationRepository _repository;
    private readonly FinancialInformationCreateValidation _financialInformationCreateValidation;

    public FinancialInformationCreateManyCoreHandler(FinancialInformationCreateValidation financialInformationCreateValidation,
        IFinancialInformationRepository repository, IMongoDbCommandContext mongoDbContext,
        IPasswordHasher passwordHasher)
    {
        _financialInformationCreateValidation = financialInformationCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<ISingleResult<Entity>> Handle(FinancialInformationCreateManyCommand request,
        CancellationToken cancellationToken)
    {
        var validate = request.FinancialInformations.Select(_financialInformationCreateValidation.Execute);
        foreach (var singleResult in validate)
        {
            if (!singleResult.Success)
            {
                return singleResult;
            }
        }

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.AddAll(request.FinancialInformations).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        return new ManyResult<Entity>(true,
            BusinessMessage.MSG01);
    }
}