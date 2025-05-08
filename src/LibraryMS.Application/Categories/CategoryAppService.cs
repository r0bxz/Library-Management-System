using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using LibraryMS.Managers;
using Volo.Abp;
using LibraryMS.Borrowers;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Categories
{
    [RemoteService(false)]
    public class CategoryAppService : LibraryMSAppService, ICategoryAppService
    {
        private readonly CategoryManager _categoryManager;

        public CategoryAppService(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var category = await _categoryManager.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<PagedResultDto<CategoryDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var categoriesList = await _categoryManager.GetAllAsync();          
            return new PagedResultDto<CategoryDto>(
                categoriesList.Count,
                ObjectMapper.Map<List<Category>, List<CategoryDto>>(categoriesList)
            );
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            var category = await _categoryManager.CreateAsync(input.Name, input.Description);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto input)
        {
           
            var category = await _categoryManager.UpdateAsync(input.Id, input.Name, input.Description);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryManager.DeleteAsync(id);
        }
    }
}
