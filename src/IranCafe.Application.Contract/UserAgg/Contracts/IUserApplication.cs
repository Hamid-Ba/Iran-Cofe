using Framework.Application;

namespace IranCafe.Application.Contract.UserAgg.Contracts
{
    public interface IUserApplication
    {
        Task<UserDto> GetBy(Guid id);
        Task<OperationResult> Delete(Guid id);
        Task<EditUserDto> GetDetailForEditBy(Guid id);
        Task<OperationResult> ActiveOrDeactive(Guid id);
        Task<OperationResult> Edit(EditUserDto command);
        Task<IEnumerable<UserDto>> GetAll(bool isDelete);
        Task<OperationResult> Register(RegisterUserDto command);
        Task<OperationResult> SendMessage(SendSmsUserDto command);
        Task<OperationResult> LoginFirstStep(LoginUserDto command);
        //Task<(OperationResult,string)> VerifyRegister(AccessTokenDto command);
        Task<(OperationResult, string)> VerifyLoginRegister(AccessTokenDto command);
    }
}