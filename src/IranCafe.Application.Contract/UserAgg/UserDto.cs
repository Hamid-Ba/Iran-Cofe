using Framework.Application;
using System.ComponentModel.DataAnnotations;

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

    public class SendSmsUserDto
    {
        public Guid Id { get; set; }

        [Display(Name = "پیام")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(500, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string? Message { get; set; }
    }

    public class AccessTokenDto : RegisterUserDto
    {
        public string? Token { get; set; }
    }
}