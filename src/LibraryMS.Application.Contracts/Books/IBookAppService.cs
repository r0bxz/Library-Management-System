using System.Collections.Generic;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;


public interface IBookAppService : IApplicationService
{
    Task<BookDto> CreateAsync(CreateBookDto input);
    Task<BookDto> UpdateAsync(int id, UpdateBookDto input);
    Task DeleteAsync(int id);
    Task<BookDto> GetAsync(int id);
    Task<PagedResultDto<BookDto>> GetAllAsync(PagedAndSortedResultRequestDto input, string category = null, string searchQuery = null);
}
