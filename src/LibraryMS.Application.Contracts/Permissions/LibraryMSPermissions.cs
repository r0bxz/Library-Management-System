namespace LibraryMS.Permissions;

public static class LibraryMSPermissions
{
    public const string GroupName = "LibraryMS";


    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
