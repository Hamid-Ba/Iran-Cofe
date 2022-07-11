﻿using Framework.Api.Jwt;
using Framework.Application;
using IranCafe.Application.Contract.UserAgg;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Application.UserAgg
{
    public class UserApplication : IUserApplication
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IUserRepository _userRepository;

        public UserApplication(IJwtHelper jwtHelper, IUserRepository userRepository)
        {
            _jwtHelper = jwtHelper;
            _userRepository = userRepository;
        }

        public async Task<OperationResult> LoginFirstStep(LoginUserDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetBy(command.Phone!);
            if (user is null) return await Register(new RegisterUserDto { Phone = command.Phone });
            if (!user.IsActive) return result.Failed(ApplicationMessage.UserNotActive);

            user.SetAccessToLoginDate(DateTime.Now.AddMinutes(5));

            var phoneCode = Guid.NewGuid().ToString().Substring(0, 6);

            //ToDo : Send Phone Code
            user.ChangePhoneCode(phoneCode);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Register(RegisterUserDto command)
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

        public async Task<(OperationResult, string)> LoginSecondStep(AccessTokenDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetBy(command.Phone!);

            if (user.LoginExpireDate <= DateTime.Now) return (result.Failed("کد وارد شده نامعتبر می باشد"), "");
            if (user.PhoneCode != command.Token) return (result.Failed(ApplicationMessage.InvalidAccessToken), "");

            var loginDto = new JwtDto
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneCode = user.PhoneCode,
                LoginExpireDate = user.LoginExpireDate
            };

            var token = _jwtHelper.SignIn(loginDto);
            return (result.Succeeded(), token);
        }

        public async Task<(OperationResult, string)> VerifyRegister(AccessTokenDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetBy(command.Phone!);
            if (user.PhoneCode != command.Token) return (result.Failed(ApplicationMessage.InvalidAccessToken), "");
            user.ControlActivation(isActive:true);

            var loginDto = new JwtDto
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneCode = user.PhoneCode,
                LoginExpireDate = user.LoginExpireDate
            };

            var token = _jwtHelper.SignIn(loginDto);
            return (result.Succeeded(), token);

        }
    }
}