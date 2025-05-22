using LibraryMS.Categories;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryMS.BookCategories;
using System;
using Volo.Abp;

namespace LibraryMS.Managers
{
    public class CategoryManager : DomainService
    {
        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IRepository<BookCategory> _bookCategoryRepository;
        public CategoryManager(IRepository<Category, int> categoryRepository, IRepository<BookCategory> bookCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }
        public async Task<Category> CreateAsync(string name, string description)
        {
            var category = new Category(name, description);

            return await _categoryRepository.InsertAsync(category);
        }
        public async Task<Category> UpdateAsync(int id, string name, string description)
        {
            var category = await _categoryRepository.GetAsync(id);

            category.ChangeName(name);
            category.ChangeDescription(description);

            return await _categoryRepository.UpdateAsync(category);
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            var relatedBookCategories = await _bookCategoryRepository.GetListAsync(x => x.CategoryId == id);
            await _bookCategoryRepository.DeleteManyAsync(relatedBookCategories);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<Category?> GetAsync(int id)
        {
            var queryable = await _categoryRepository.GetQueryableAsync();
            var category = await queryable
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Book)
                .FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            var query = await _categoryRepository.GetQueryableAsync();
            query = query
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Book);

            return await query.ToListAsync();
        }
    }
}
