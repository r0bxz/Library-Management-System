using Volo.Abp.Modularity;

namespace LibraryMS;

/* Inherit from this class for your domain layer tests. */
public abstract class LibraryMSDomainTestBase<TStartupModule> : LibraryMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
