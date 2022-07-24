using Framework.Application;

namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface ICafeApplication
    {
        Task<OperationResult> Register(RegisterCafeDto command);
    }
}