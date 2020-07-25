namespace CleanArch.Application.Permissions
{
    public static class Permission
    {
        public static class Products
        {
            public const string Create = "Perm.Products.Create";
            public const string View = "Perm.Products.View";
            public const string Edit = "Perm.Products.Edit";
            public const string Delete = "Perm.Products.Delete";
        }

        public static class Categories
        {
            public const string Create = "Perm.Products.Create";
            public const string View = "Perm.Categories.View";
            public const string Edit = "Perm.Categories.Edit";
            public const string Delete = "Perm.Categories.Delete";
        }

        public static class Languages
        {
            public const string Create = "Perm.Languages.Create";
            public const string View = "Perm.Languages.View";
            public const string Edit = "Perm.Languages.Edit";
            public const string Delete = "Perm.Languages.Delete";
        }


        public static class Users
        {
            public const string View = "Perm.Users.View";
            public const string Create = "Perm.Users.Create";
            public const string Edit = "Perm.Users.Edit";
            public const string Delete = "Perm.Users.Delete";
        }

        public static class Roles
        {
            public const string View = "Perm.Roles.View";
            public const string Create = "Perm.Roles.Create";
            public const string Edit = "Perm.Roles.Edit";
            public const string Delete = "Perm.Roles.Delete";
        }
    }
}
