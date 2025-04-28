using Volo.Abp.Modularity;

namespace LibraryMS;

[DependsOn(
    typeof(LibraryMSApplicationModule),
    typeof(LibraryMSDomainTestModule)
)]
public class LibraryMSApplicationTestModule : AbpModule
{

}
