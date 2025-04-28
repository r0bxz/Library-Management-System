using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LibraryMS.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class LibraryMSDbContextFactory : IDesignTimeDbContextFactory<LibraryMSDbContext>
{
    public LibraryMSDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        LibraryMSEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<LibraryMSDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default")).EnableSensitiveDataLogging()   // Logs parameterized queries
            .LogTo(Console.WriteLine, LogLevel.Information);  // Outputs SQL queries to console


        return new LibraryMSDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LibraryMS.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
