using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryMS.EntityFrameworkCore;
using LibraryMS.BorrowedBooks;
using Volo.Abp.Domain.Repositories;


    public class BorrowedBookRepository
        : EfCoreRepository<LibraryMSDbContext, BorrowedBook, int>, IRepository<BorrowedBook, int>
    {
        public BorrowedBookRepository(IDbContextProvider<LibraryMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }


    }

