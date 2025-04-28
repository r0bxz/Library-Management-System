using System.Collections.Generic;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;


public interface ICategoryAppService : IApplicationService
{
    Task<CategoryDto> CreateAsync(CreateCategoryDto input);
    Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto input);
    Task DeleteAsync(int id);
    Task<CategoryDto> GetAsync(int id);
    Task<PagedResultDto<CategoryDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
}
