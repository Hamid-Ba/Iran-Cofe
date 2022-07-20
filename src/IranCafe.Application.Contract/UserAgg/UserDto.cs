namespace IranCafe.Application.Contract.UserAgg
{
    public class UserDto : EntityBaseDto
    {
        public string? Phone { get; set; }
        public string? PhoneCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string? PersianCreationDate { get; set; }
        public string? PersianDeletionDate { get; set; }
        public DateTime LoginExpireDate { get; set; }
    }

    public class RegisterUserDto
    {
        public string? Phone { get; set; }
    }

    public class LoginUserDto : RegisterUserDto
    {
        
    }

    public class AccessTokenDto : RegisterUserDto
    {
        public string? Token { get; set; }
    }
}