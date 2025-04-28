using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryMS.EntityFrameworkCore;
using LibraryMS.Categories;
using Volo.Abp.Domain.Repositories;


    public class CategoryRepository
        : EfCoreRepository<LibraryMSDbContext, Category, int>, IRepository<Category, int>
    {
        public CategoryRepository(IDbContextProvider<LibraryMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

       
    }

