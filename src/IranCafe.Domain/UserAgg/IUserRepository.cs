using Framework.Domain;

namespace IranCafe.Domain.UserAgg
{
    public interface IUserRepository : IRepository<User>
	{
		Task<User> GetBy(string phone);
	}
}