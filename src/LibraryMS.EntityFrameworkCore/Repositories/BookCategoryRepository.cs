using LibraryMS.BookCategories;
using LibraryMS.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public class BookCategoryRepository
    : EfCoreRepository<LibraryMSDbContext, BookCategory>
{
    public BookCategoryRepository(IDbContextProvider<LibraryMSDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}
