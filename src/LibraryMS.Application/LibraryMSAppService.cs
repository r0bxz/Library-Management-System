using LibraryMS.Localization;
using Volo.Abp.Application.Services;

namespace LibraryMS;

/* Inherit your application services from this class.
 */
public abstract class LibraryMSAppService : ApplicationService
{
    protected LibraryMSAppService()
    {
        LocalizationResource = typeof(LibraryMSResource);
    }
}
