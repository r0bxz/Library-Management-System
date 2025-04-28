using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LibraryMS.Data;

/* This is used if database provider does't define
 * ILibraryMSDbSchemaMigrator implementation.
 */
public class NullLibraryMSDbSchemaMigrator : ILibraryMSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
