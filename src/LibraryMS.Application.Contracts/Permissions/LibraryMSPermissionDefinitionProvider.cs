using LibraryMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace LibraryMS.Permissions;

public class LibraryMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LibraryMSPermissions.GroupName); 

        var booksPermission = myGroup.AddPermission(LibraryMSPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(LibraryMSPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(LibraryMSPermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LibraryMSResource>(name);
    }
}
