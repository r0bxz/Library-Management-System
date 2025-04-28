using LibraryMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LibraryMS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LibraryMSController : AbpControllerBase
{
    protected LibraryMSController()
    {
        LocalizationResource = typeof(LibraryMSResource);
    }
}
