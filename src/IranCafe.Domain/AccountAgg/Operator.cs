using Framework.Domain;

namespace IranCafe.Domain.AccountAgg
{
    public class Operator : EntityBase
    {
        public string FullName { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }

        public Operator(string fullName, string mobile, string password)
        {
            FullName = fullName;
            Mobile = mobile;
            Password = password;
        }

        public void Edit(string fullName, string mobile, string password)
        {
            FullName = fullName;
            Mobile = mobile;

            if (string.IsNullOrWhiteSpace(password))
                Password = password;
        }
    }
}