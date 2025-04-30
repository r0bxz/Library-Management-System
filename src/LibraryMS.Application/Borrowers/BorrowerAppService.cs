using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using LibraryMS.Managers;
using Volo.Abp;

namespace LibraryMS.Borrowers
{
    [RemoteService(false)]
    public class BorrowerAppService : LibraryMSAppService, IBorrowerAppService
    {
        private readonly BorrowerManager _borrowerManager;

        public BorrowerAppService(BorrowerManager borrowerManager)
        {
            _borrowerManager = borrowerManager;
        }

        public async Task<BorrowerDto> GetAsync(int id)
        {
            var borrower = await _borrowerManager.GetAsync(id);
            return ObjectMapper.Map<Borrower, BorrowerDto>(borrower);
        }

        public async Task<PagedResultDto<BorrowerDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var items = await _borrowerManager.GetAllAsync();
            return new PagedResultDto<BorrowerDto>(
                items.Count,
                ObjectMapper.Map<List<Borrower>, List<BorrowerDto>>(items)
            );
        }

        public async Task<BorrowerDto> CreateAsync(CreateBorrowerDto input)
        {
            var borrower = await _borrowerManager.CreateAsync(input.FullName, input.Email, input.PhoneNumber);
            return ObjectMapper.Map<Borrower, BorrowerDto>(borrower);
        }

        public async Task<BorrowerDto> UpdateAsync( UpdateBorrowerDto input)
        {
            var borrower =await _borrowerManager.UpdateAsync(input.Id, input.FullName, input.Email, input.PhoneNumber);

            return ObjectMapper.Map<Borrower, BorrowerDto>(borrower);
        }

        public async Task DeleteAsync(int id)
        {
            await _borrowerManager.DeleteAsync(id);
        }
    }
}
