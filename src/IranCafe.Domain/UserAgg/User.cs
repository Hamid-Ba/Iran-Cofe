using Framework.Domain;

namespace IranCafe.Domain.UserAgg
{
    public class User : EntityBase
    {
        public string Phone { get; private set; }
        public string PhoneCode { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        public User() { }

        public User(string phone, string phoneCode, string fullName, string email)
        {
            Guard(phone);

            Phone = phone;
            PhoneCode = phoneCode;
            FullName = fullName;
            Email = email;
        }

        public static User Register(string phone, string phoneCode) => new(phone, phoneCode, "", "");

        public void Edit(string fullName, string email)
        {
            FullName = fullName;
            Email = email;

            LastUpdateDate = DateTime.Now;
        }


        public void ControlActivation(bool isActive)
        {
            IsActive = isActive;
            LastUpdateDate = DateTime.Now;
        }

        public void ChangePhoneCode(string newPhoneCode) => PhoneCode = newPhoneCode;

        private void Guard(string phone) { if (string.IsNullOrWhiteSpace(phone)) throw new Exception("Phone Can Not Be Null Or Empty"); }
    }
}