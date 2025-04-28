using System.Threading.Tasks;

namespace LibraryMS.Data;

public interface ILibraryMSDbSchemaMigrator
{
    Task MigrateAsync();
}
