using LibraryMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LibraryMS.Web.Pages;

public abstract class LibraryMSPageModel : AbpPageModel
{
    protected LibraryMSPageModel()
    {
        LocalizationResourceType = typeof(LibraryMSResource);
    }
}
