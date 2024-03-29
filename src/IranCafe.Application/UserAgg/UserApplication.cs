﻿using Framework.Api.Jwt;
using Framework.Application;
using Framework.Application.Sms;
using IranCafe.Application.Contract.UserAgg;
using IranCafe.Application.Contract.UserAgg.Contracts;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Application.UserAgg
{
    public class UserApplication : IUserApplication
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly ISmsService _smsService;
        private readonly IUserRepository _userRepository;

        public UserApplication(IJwtHelper jwtHelper, ISmsService smsService, IUserRepository userRepository)
        {
            _jwtHelper = jwtHelper;
            _smsService = smsService;
            _userRepository = userRepository;
        }

        public async Task<OperationResult> ActiveOrDeactive(Guid id)
        {
            OperationResult result = new();

            var user = await _userRepository.GetEntityByIdAsync(id);
            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            user.ControlActivation(!user.IsActive);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            OperationResult result = new();

            var user = await _userRepository.GetEntityByIdAsync(id);
            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            user.Delete();
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditUserDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetEntityByIdAsync(command.Id);

            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);
            if (_userRepository.Exists(u => u.Email == command.Email && u.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedEmail);

            user.Edit(command.FullName!, command.Email!);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<UserDto>> GetAll(bool isDelete) => await _userRepository.GetAll(isDelete);

        public async Task<UserDto> GetBy(Guid id) => await _userRepository.GetBy(id);

        public async Task<UserDto> GetBy(string accessToken) => await _userRepository.GetByToken(accessToken);

        public async Task<EditUserDto> GetDetailForEditBy(Guid id) => await _userRepository.GetDetailForEditBy(id);

        public async Task<OperationResult> LoginFirstStep(LoginUserDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetBy(command.Phone!);
            if (user is null) return await Register(new RegisterUserDto { Phone = command.Phone });
            if (!user.IsActive) return result.Failed(ApplicationMessage.UserNotActive);

            user.SetAccessToLoginDate(DateTime.Now.AddMinutes(5));

            var phoneCode = new Random().Next(100000, 999999).ToString();//Guid.NewGuid().ToString().Substring(0, 6);

            //ToDo : Send Phone Code
            //var smsMessage = $"کاربر گرامی با شماره موبایل {command.Phone},\nکد تایید شما : {phoneCode} می باشد";
            //_smsService.SendSms(command.Phone!, smsMessage);

            user.ChangePhoneCode(phoneCode);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Register(RegisterUserDto command)
        {
            OperationResult result = new();

            if (_userRepository.Exists(u => u.Phone == command.Phone)) return result.Failed(ApplicationMessage.DuplicatedMobile);

            var phoneCode = new Random().Next(100000, 999999).ToString();//Guid.NewGuid().ToString().Substring(0, 6);
            var user = User.Register(command.Phone!, phoneCode);

            //ToDo : Send Phone Code
            //var smsMessage = $"کاربر گرامی با شماره موبایل {command.Phone},\nکد تایید شما : {phoneCode} می باشد";
            //_smsService.SendSms(command.Phone!, smsMessage);

            await _userRepository.AddEntityAsync(user);
            await _userRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> SendMessage(SendSmsUserDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetEntityByIdAsync(command.Id);
            if (user is null) return result.Failed(ApplicationMessage.UserNotExist);

            //ToDo : Send Phone Code
            _smsService.SendSms(user.Phone!, command.Message!);

            return result.Succeeded();
        }

        public async Task<(OperationResult, string)> VerifyLoginRegister(AccessTokenDto command)
        {
            OperationResult result = new();

            var user = await _userRepository.GetBy(command.Phone!);

            if (user.LoginExpireDate <= DateTime.Now) return (result.Failed("کد وارد شده نامعتبر می باشد"), "");
            if (user.PhoneCode != command.Token) return (result.Failed(ApplicationMessage.InvalidAccessToken), "");

            var phoneCode = new Random().Next(100000, 999999).ToString();//Guid.NewGuid().ToString().Substring(0, 6);
            user.ChangePhoneCode(phoneCode);

            var loginDto = new JwtDto
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneCode = user.PhoneCode,
                LoginExpireDate = user.LoginExpireDate
            };

            var token = _jwtHelper.SignIn(loginDto);

            user.SetAccessToken(token);
            await _userRepository.SaveChangesAsync();

            return (result.Succeeded(), token);
        }

        //public async Task<(OperationResult, string)> VerifyRegister(AccessTokenDto command)
        //{
        //    OperationResult result = new();

        //    var user = await _userRepository.GetBy(command.Phone!);
        //    if (user.PhoneCode != command.Token) return (result.Failed(ApplicationMessage.InvalidAccessToken), "");

        //    user.ControlActivation(isActive:true);
        //    user.SetAccessToLoginDate(DateTime.Now.AddMinutes(5));
        //    await _userRepository.SaveChangesAsync();

        //    return await LoginSecondStep(command);
        //}
    }
}