using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryMS.EntityFrameworkCore;
using LibraryMS.Borrowers;
using Volo.Abp.Domain.Repositories;


    public class BorrowerRepository
        : EfCoreRepository<LibraryMSDbContext, Borrower, int>, IRepository<Borrower, int>
    {
        public BorrowerRepository(IDbContextProvider<LibraryMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

       
    }

