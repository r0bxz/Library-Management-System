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

        //Define your own permissions here. Example:
        //myGroup.AddPermission(LibraryMSPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LibraryMSResource>(name);
    }
}
