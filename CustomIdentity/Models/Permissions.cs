namespace CustomIdentity.Models
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }
        public static class Account
        {
            public const string View = "Permissions.Account.View";
            public const string Create = "Permissions.Account.Create";
            public const string Edit = "Permissions.Account.Edit";
            public const string Delete = "Permissions.Account.Delete";
        }
        public static class Category
        {
            public const string View = "Permissions.Category.View";
            public const string Create = "Permissions.Category.Create";
            public const string Edit = "Permissions.Category.Edit";
            public const string Delete = "Permissions.Category.Delete";
        }
        public static class SubCategory
        {
            public const string View = "Permissions.SubCategory.View";
            public const string Create = "Permissions.SubCategory.Create";
            public const string Edit = "Permissions.SubCategory.Edit";
            public const string Delete = "Permissions.SubCategory.Delete";
        }
        public static class Products
        {
            public const string View = "Permissions.Product.View";
            public const string Create = "Permissions.Product.Create";
            public const string Edit = "Permissions.Product.Edit";
            public const string Delete = "Permissions.Product.Delete";
        }

    }
}
