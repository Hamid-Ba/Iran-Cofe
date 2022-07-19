using Framework.Application;

namespace IranCafe.Application.Contract.AccountAgg.Contracts
{
    public interface IOperatorApplication
	{
		Task<OperationResult> Delete(Guid id);
		Task<IEnumerable<OperatorDto>> GetAll();
		Task<EditOperatorDto> GetDetailForEditBy(Guid id);
		Task<OperationResult> Edit(EditOperatorDto command);
		Task<OperationResult> Login(LoginOperatorDto command);
		Task<OperationResult> Create(CreateOperatorDto command);
	}
}