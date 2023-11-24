namespace CustomIdentity.Models.PermissionModel.ViewModel
{
    public class PermissionCategoryViewModel
    {
        public string CategoryName { get; set; }
        public IList<PermissionItemViewModel> Permissions { get; set; }
    }
}
