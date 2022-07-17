using Framework.Application;
using Framework.Application.Hashing;
using IranCafe.Application.Contract.AccountAgg;
using IranCafe.Application.Contract.AccountAgg.Contracts;
using IranCafe.Domain.AccountAgg;
using IranCafe.Domain.AccountAgg.Contracts;

namespace IranCafe.Application.AccountAgg
{
    public class OperatorApplication : IOperatorApplication
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IOperatorRepository _operatorRepository;

        public OperatorApplication(IPasswordHasher passwordHasher, IOperatorRepository operatorRepository)
        {
            _passwordHasher = passwordHasher;
            _operatorRepository = operatorRepository;
        }

        public async Task<OperationResult> Create(CreateOperatorDto command)
        {
            OperationResult result = new();

            if (_operatorRepository.Exists(o => o.Mobile == command.Mobile))
                return result.Failed(ApplicationMessage.DuplicatedMobile);

            var hashedPassword = _passwordHasher.Hash(command.Password!);
            var ope = new Operator(command.FullName!, command.Mobile!, hashedPassword);

            await _operatorRepository.AddEntityAsync(ope);
            await _operatorRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            OperationResult result = new();

            var ope = await _operatorRepository.GetEntityByIdAsync(id);
            if (ope is null) return result.Failed(ApplicationMessage.UserNotExist);

            ope.Delete();
            await _operatorRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditOperatorDto command)
        {
            OperationResult result = new();

            var ope = await _operatorRepository.GetEntityByIdAsync(command.Id);

            if (ope is null) return result.Failed(ApplicationMessage.UserNotExist);
            if (_operatorRepository.Exists(o => o.Mobile == command.Mobile && o.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedMobile);

            string hashPassword = "";

            if (!string.IsNullOrWhiteSpace(command.Password))
                hashPassword = _passwordHasher.Hash(command.Password);

            ope.Edit(command.FullName!, command.Mobile!, hashPassword);
            await _operatorRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<OperatorDto>> GetAll() => await _operatorRepository.GetAll();

        public async Task<EditOperatorDto> GetDetailForEditBy(Guid id) => await _operatorRepository.GetDetailForEditBy(id);
    }
}