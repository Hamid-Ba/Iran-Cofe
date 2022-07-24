using Framework.Application;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;

namespace IranCafe.Application.CafeAgg
{
    public class CafeApplication : ICafeApplication
    {
        private readonly ICafeRepository _cafeRepository;

        public CafeApplication(ICafeRepository cafeRepository) => _cafeRepository = cafeRepository;

        public async Task<OperationResult> Register(RegisterCafeDto command)
        {
            OperationResult result = new();

            if (_cafeRepository.Exists(c => c.OwnerId == command.OwnerId)) return result.Failed(ApplicationMessage.UserOwnsCafe);
            if (_cafeRepository.Exists(c => c.Phone == command.Phone)) return result.Failed(ApplicationMessage.CafeRegisteredByThisPhone);

            var uniqueCode = Guid.NewGuid().ToString().Substring(0, 6);
            var cafe = new Cafe(command.OwnerId, command.CityId, command.Type, uniqueCode, 
                command.EnTitle!, command.FaTitle!, command.Slug!, command.Phone!, command.Street!, command.ShortDesc!, command.Desc!);

            await _cafeRepository.AddEntityAsync(cafe);
            await _cafeRepository.SaveChangesAsync();

            return result.Succeeded();
        }
    }
}
