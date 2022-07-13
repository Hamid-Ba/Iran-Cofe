using Framework.Application;

namespace IranCafe.Application.Contract.UserAgg
{
    public interface IUserApplication
	{
		Task<OperationResult> Register(RegisterUserDto command);
		Task<OperationResult> LoginFirstStep(LoginUserDto command);
		//Task<(OperationResult,string)> VerifyRegister(AccessTokenDto command);
		Task<(OperationResult,string)> VerifyLoginRegister(AccessTokenDto command);
	}
}