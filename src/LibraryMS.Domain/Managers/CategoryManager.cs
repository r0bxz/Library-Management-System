using LibraryMS.Categories;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using System.Collections.Generic;


namespace LibraryMS.Managers
{
    public class CategoryManager:DomainService
    {
        private readonly IRepository<Category, int> _categoryRepository;


        public CategoryManager(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateAsync(string name, string description)
        {
            var category = new Category
            {
                Name = name,
                Description = description
            };

            return await _categoryRepository.InsertAsync(category);
        }

        public async Task<Category> UpdateAsync(int id, string name, string description)
        {
            var category = await _categoryRepository.GetAsync(id);
            category.Name = name;
            category.Description = description;

            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetListAsync();
        }
    }
}
