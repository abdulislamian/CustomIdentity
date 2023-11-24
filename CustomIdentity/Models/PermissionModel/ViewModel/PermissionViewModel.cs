namespace CustomIdentity.Models.PermissionModel.ViewModel
{
    public class PermissionViewModel
    {
        public string RoleId { get; set; }
        public IList<PermissionCategoryViewModel> Categories { get; set; }
    }
}
