using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryMS.EntityFrameworkCore;
using LibraryMS.Books;
using Volo.Abp.Domain.Repositories;


    public class BookRepository
        : EfCoreRepository<LibraryMSDbContext, Book, int>, IRepository<Book, int>
    {
        public BookRepository(IDbContextProvider<LibraryMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

   
    }

