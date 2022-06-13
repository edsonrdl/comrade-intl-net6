using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.FinancialInformationCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.FinancialInformationCore.UseCases
{
    public class UcFinancialInformationCreate : UseCase, IUcFinancialInformationCreate
    {
        private readonly IMediator _mediator;


        public UcFinancialInformationCreate(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ISingleResult<Entity>> Execute(FinancialInformationCreateCommand entity)
        {
            var isValid = ValidateEntity(entity);
            if (!isValid.Success)
            {
                return isValid;
            }

            return await _mediator.Send(entity).ConfigureAwait(false);
        }
    }
}