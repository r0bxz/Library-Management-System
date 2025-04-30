using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using LibraryMS.Categories;
using LibraryMS.Borrowers;
using LibraryMS.BorrowedBooks;
using LibraryMS.Books;
using System;


namespace LibraryMS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ConnectionStringName("Default")]
public class LibraryMSDbContext :
    AbpDbContext<LibraryMSDbContext>,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<BorrowedBook> BorrowedBooks { get; set; }


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    #endregion

    public LibraryMSDbContext(DbContextOptions<LibraryMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */
        builder.Entity<Book>(b =>
        {
            b.ToTable("Books");
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Title).IsRequired().HasMaxLength(255);
            b.Property(x => x.Author).IsRequired().HasMaxLength(255);
            b.Property(x => x.PublishedDate);
            b.Property(x => x.ISBN).HasMaxLength(20);
            b.Property(x => x.CoverImagePath).HasMaxLength(500);
            b.HasOne(x => x.Category)
             .WithMany(x => x.Books)
             .HasForeignKey(x => x.CategoryId);
        });


        builder.Entity<BorrowedBook>(b =>
        {
            b.ToTable("BorrowedBooks");
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId);
            b.HasOne(x => x.Borrower).WithMany(x => x.BorrowedBooks).HasForeignKey(x => x.BorrowerId);
            b.Property(x => x.BorrowDate);
            b.Property(x => x.ReturnDate);
            b.Property(x => x.IsReturned);
        });

        builder.Entity<Borrower>(b =>
        {
            b.ToTable("Borrowers");
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(x => x.FullName).IsRequired().HasMaxLength(255);
            b.Property(x => x.Email).IsRequired().HasMaxLength(255);
            b.Property(x => x.PhoneNumber).HasMaxLength(15);
        });

        builder.Entity<Category>(b =>
        {

            b.ToTable("Categories");
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.Property(x => x.Name).IsRequired().HasMaxLength(255);
            b.Property(x => x.Description).HasMaxLength(1000);
        });

      

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(LibraryMSConsts.DbTablePrefix + "YourEntities", LibraryMSConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
