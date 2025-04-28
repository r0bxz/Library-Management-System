using Volo.Abp.Settings;

namespace LibraryMS.Settings;

public class LibraryMSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LibraryMSSettings.MySetting1));
    }
}
