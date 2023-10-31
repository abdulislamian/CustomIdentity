namespace CustomIdentity.Models.ViewModels
{
    public class UserListVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } // Property to store roles
    }

}
