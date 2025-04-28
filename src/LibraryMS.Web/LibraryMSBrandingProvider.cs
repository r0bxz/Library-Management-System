using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using LibraryMS.Localization;

namespace LibraryMS.Web;

[Dependency(ReplaceServices = true)]
public class LibraryMSBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<LibraryMSResource> _localizer;

    public LibraryMSBrandingProvider(IStringLocalizer<LibraryMSResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
