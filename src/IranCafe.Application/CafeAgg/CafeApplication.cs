using Framework.Application;
using Framework.Domain.Cafe;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Application.CafeAgg
{
    public class CafeApplication : ICafeApplication
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IUserRepository _userRepository;

        public CafeApplication(ICafeRepository cafeRepository, IUserRepository userRepository)
        {
            _cafeRepository = cafeRepository;
            _userRepository = userRepository;
        }

        public async Task<OperationResult> ChangeStatus(ChangeCafeStatusDto command)
        {
            OperationResult result = new();

            var cafe = await _cafeRepository.GetEntityByIdAsync(command.Id);
            if (cafe is null) return result.Failed(ApplicationMessage.NotExist);

            cafe.ChangeStatus(command.Status, command.Reason!);
            await _cafeRepository.SaveChangesAsync();

            //ToDo : SMS Reason To Owner

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditCafeDto command)
        {
            OperationResult result = new();

            var cafe = await _cafeRepository.GetEntityByIdAsync(command.Id);

            if (cafe is null) return result.Failed(ApplicationMessage.NotExist);
            if (_cafeRepository.Exists(c => c.Phone == command.Phone && c.Id != command.Id))
                return result.Failed(ApplicationMessage.CafeRegisteredByThisPhone);

            cafe.Edit(command.ProvinceId, command.CityId, command.EnTitle, command.FaTitle, command.Slug, command.Phone, command.Email,
                command.InstagramId, command.TelegramId, command.Street, command.PostalCode, command.ShortDesc, command.Desc, command.Type);
            await _cafeRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<CafeAdminDto>> GetAllBy(CafeStatus status) => await _cafeRepository.GetAllBy(status);

        public async Task<IEnumerable<CafesDto>> GetAllBy(FilterCafesDto filter) => await _cafeRepository.GetAllBy(filter);

        public async Task<CafeDto> GetBy(string uniqueCode) => await _cafeRepository.GetBy(uniqueCode);

        public async Task<OperationResult> Register(RegisterCafeDto command)
        {
            OperationResult result = new();

            if (_cafeRepository.Exists(c => c.OwnerId == command.OwnerId)) return result.Failed(ApplicationMessage.UserOwnsCafe);
            if (_cafeRepository.Exists(c => c.Phone == command.Phone)) return result.Failed(ApplicationMessage.CafeRegisteredByThisPhone);
            
            //Add Cafe
            var uniqueCode = Guid.NewGuid().ToString().Substring(0, 6);
            var cafe = new Cafe(command.OwnerId,command.ProvinceId, command.CityId, command.Type, uniqueCode,
                command.EnTitle!, command.FaTitle!, command.Slug!, command.Phone!, command.Street!, command.ShortDesc!, command.Desc!);

            await _cafeRepository.AddEntityAsync(cafe);

            //Add User Cafe
            var owner = await _userRepository.GetEntityByIdAsync(command.OwnerId);
            owner.RegisterCafe(cafe.Id);

            await _cafeRepository.SaveChangesAsync();

            return result.Succeeded();
        }
    }
}