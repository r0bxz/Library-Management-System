using System.Collections.Generic;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
public interface IBorrowerAppService : IApplicationService
{
    Task<BorrowerDto> CreateAsync(CreateBorrowerDto input);
    Task<BorrowerDto> UpdateAsync(UpdateBorrowerDto input);
    Task DeleteAsync(int id);
    Task<BorrowerDto> GetAsync(int id);
    Task<PagedResultDto<BorrowerDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
}
