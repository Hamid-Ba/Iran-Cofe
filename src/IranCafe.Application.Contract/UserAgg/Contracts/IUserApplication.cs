using Framework.Application;

namespace IranCafe.Application.Contract.UserAgg.Contracts
{
    public interface IUserApplication
    {
        Task<UserDto> GetBy(Guid id);
        Task<OperationResult> Delete(Guid id);
        Task<OperationResult> ActiveOrDeactive(Guid id);
        Task<IEnumerable<UserDto>> GetAll(bool isDelete);
        Task<OperationResult> Register(RegisterUserDto command);
        Task<OperationResult> LoginFirstStep(LoginUserDto command);
        Task<OperationResult> SendMessage(Guid id, string message);
        //Task<(OperationResult,string)> VerifyRegister(AccessTokenDto command);
        Task<(OperationResult, string)> VerifyLoginRegister(AccessTokenDto command);
    }
}