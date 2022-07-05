using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Enums;

namespace Comrade.Core.Bases.Results
{
    public class ManyResult<TEntity> : SingleResult<TEntity>
        where TEntity : Entity
    {
        public ManyResult()
        {
            Code = (int)EnumResponse.Manyd;
            Success = true;
            Message = BusinessMessage.MSG01;
        }

        public ManyResult(bool success, string? message)
        {
            Code = success ? (int)EnumResponse.Manyd : (int)EnumResponse.NotFound;
            Success = success;
            Message = message;
        }
    }
}