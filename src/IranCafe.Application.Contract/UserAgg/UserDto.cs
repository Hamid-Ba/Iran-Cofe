namespace IranCafe.Application.Contract.UserAgg
{
    public class UserDto : EntityBaseDto
    {
        public string? Phone { get; set; }
        public string? PhoneCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }

    public class RegisterUserDto
    {
        public string? Phone { get; set; }
    }

    public class LoginUserDto : RegisterUserDto
    {
        
    }
}