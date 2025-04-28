using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LibraryMS.Controllers
{
    [Route("api/categories")]
    public class CategoryController : AbpController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetAsync(int id)
        {
            return await _categoryAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<CategoryDto>> GetAllAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _categoryAppService.GetAllAsync(input);
        }

        [HttpPost]
        public async Task<CategoryDto> CreateAsync([FromBody] CreateCategoryDto input)
        {
            return await _categoryAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<CategoryDto> UpdateAsync(int id, [FromBody] UpdateCategoryDto input)
        {
            return await _categoryAppService.UpdateAsync(id, input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _categoryAppService.DeleteAsync(id);
        }
    }
}
