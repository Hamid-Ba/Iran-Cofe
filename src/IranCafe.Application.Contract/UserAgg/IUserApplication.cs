using System;
using Framework.Application;

namespace IranCafe.Application.Contract.UserAgg
{
	public interface IUserApplication
	{
		Task<OperationResult> Register(RegisterUserDto command);
	}
}