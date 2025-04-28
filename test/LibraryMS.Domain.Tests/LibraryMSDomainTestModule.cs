using Volo.Abp.Modularity;

namespace LibraryMS;

[DependsOn(
    typeof(LibraryMSDomainModule),
    typeof(LibraryMSTestBaseModule)
)]
public class LibraryMSDomainTestModule : AbpModule
{

}
