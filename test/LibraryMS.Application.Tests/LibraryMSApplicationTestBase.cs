using Volo.Abp.Modularity;

namespace LibraryMS;

public abstract class LibraryMSApplicationTestBase<TStartupModule> : LibraryMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
