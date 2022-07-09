using Framework.Application;
using IranCafe.Application.Contract.UserAgg;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Application.UserAgg
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async  Task<OperationResult> Register(RegisterUserDto command)
        {
            OperationResult result = new();

            if (_userRepository.Exists(u => u.Phone == command.Phone)) return result.Failed(ApplicationMessage.DuplicatedMobile);

            var phoneCode = Guid.NewGuid().ToString().Substring(0, 6);
            var user = User.Register(command.Phone!, phoneCode);

            //ToDo : Send Phone Code

            await _userRepository.AddEntityAsync(user);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }
    }
}