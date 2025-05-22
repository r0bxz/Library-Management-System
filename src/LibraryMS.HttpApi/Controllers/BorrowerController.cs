using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace LibraryMS.Controllers
{
    [Route("api/borrowers")]
    public class BorrowerController : AbpController
    {
        private readonly IBorrowerAppService _borrowerAppService;

        public BorrowerController(IBorrowerAppService borrowerAppService)
        {
            _borrowerAppService = borrowerAppService;
        }

        [HttpGet("{id}")]
        public async Task<BorrowerDto> GetAsync(int id)
        {
            return await _borrowerAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<BorrowerDto>> GetAllAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _borrowerAppService.GetAllAsync(input);
        }

        [HttpPost]
        public async Task<BorrowerDto> CreateAsync([FromBody] CreateBorrowerDto input)
        {
            return await _borrowerAppService.CreateAsync(input);
        }

        [HttpPut]
        public async Task<BorrowerDto> UpdateAsync([FromBody] UpdateBorrowerDto input)
        {
            return await _borrowerAppService.UpdateAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _borrowerAppService.DeleteAsync(id);
        }
    }
}
