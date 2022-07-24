using Framework.Application;
using Framework.Domain.Cafe;

namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface ICafeApplication
    {
        Task<OperationResult> Register(RegisterCafeDto command);
        Task<IEnumerable<CafeAdminDto>> GetAllBy(CafeStatus status);
    }
}