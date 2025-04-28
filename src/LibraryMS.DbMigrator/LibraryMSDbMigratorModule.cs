using LibraryMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LibraryMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LibraryMSEntityFrameworkCoreModule),
    typeof(LibraryMSApplicationContractsModule)
)]
public class LibraryMSDbMigratorModule : AbpModule
{
}
