using Volo.Abp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IBorrowedBookAppService
{
    Task<BorrowedBookDto> CreateAsync(CreateBorrowedBookDto input);
    Task<PagedResultDto<BorrowedBookDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
    Task<BorrowedBookDto> ReturnAsync(ReturnBorrowedBookDto input);
    Task<List<BorrowedBookDto>> GetReturnedAsync();
    Task<List<BorrowedBookDto>> GetOverdueAsync(DateTime currentDate);
  
}
