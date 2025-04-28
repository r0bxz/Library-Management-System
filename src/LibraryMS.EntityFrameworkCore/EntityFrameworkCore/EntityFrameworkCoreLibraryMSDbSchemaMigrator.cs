using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryMS.Data;
using Volo.Abp.DependencyInjection;

namespace LibraryMS.EntityFrameworkCore;

public class EntityFrameworkCoreLibraryMSDbSchemaMigrator
    : ILibraryMSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLibraryMSDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LibraryMSDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LibraryMSDbContext>()
            .Database
            .MigrateAsync();
    }
}
