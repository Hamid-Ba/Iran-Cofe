using Framework.Domain;
using IranCafe.Application.Contract.AccountAgg;

namespace IranCafe.Domain.AccountAgg.Contracts
{
    public interface IOperatorRepository : IRepository<Operator>
    {
        Task<Operator> GetBy(string mobile);
        Task<IEnumerable<OperatorDto>> GetAll();
        Task<EditOperatorDto> GetDetailForEditBy(Guid id);
    }
}