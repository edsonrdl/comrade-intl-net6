using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.UseCases
{
    public class UcFinancialInformationCreateMany : UseCase, IUcFinancialInformationCreateMany
    {
        private readonly IMediator _mediator;


        public UcFinancialInformationCreateMany(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ISingleResult<Entity>> Execute(FinancialInformationCreateManyCommand entity)
        {
            var validates = entity.FinancialInformations.Select(ValidateEntity);
            foreach (var singleResult in validates)
            {
                if (!singleResult.Success)
                {
                    return singleResult;
                }
            }
            return await _mediator.Send(entity).ConfigureAwait(false);
        }
    }
}