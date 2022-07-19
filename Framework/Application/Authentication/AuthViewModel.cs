namespace Framework.Application.Authentication
{
    public class OperatorAuthViewModel
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public string? Fullname { get; set; }
        public string? Mobile { get; set; }

        public OperatorAuthViewModel() { }

        public OperatorAuthViewModel(Guid id,string roleName, string fullname, string mobile)
        {
            Id = id;
            RoleName = roleName;
            Fullname = fullname;
            Mobile = mobile;
        }
    }
}