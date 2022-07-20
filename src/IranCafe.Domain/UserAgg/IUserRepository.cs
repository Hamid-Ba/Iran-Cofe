using Framework.Domain;
using IranCafe.Application.Contract.UserAgg;

namespace IranCafe.Domain.UserAgg
{
    public interface IUserRepository : IRepository<User>
	{
        Task<UserDto> GetBy(Guid id);
		Task<User> GetBy(string phone);
        Task<IEnumerable<UserDto>> GetAll(bool isDelete);
        Task<EditUserDto> GetDetailForEditBy(Guid id);
    }
}