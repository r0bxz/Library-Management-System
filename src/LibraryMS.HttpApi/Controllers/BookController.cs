using System.Threading.Tasks;
using LibraryMS.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace LibraryMS.Controllers
{
    [Route("api/books")]
    public class BookController : LibraryMSController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetAsync(int id)
        {
            return await _bookAppService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<BookDto>> GetAllAsync([FromQuery] PagedAndSortedResultRequestDto input,[FromQuery] string category = null,
            [FromQuery] string searchQuery = null)
        {
            return await _bookAppService.GetAllAsync(input,category,searchQuery);
        }

        [HttpPost]
        public async Task<BookDto> CreateAsync([FromBody] CreateBookDto input)
        {
            return await _bookAppService.CreateAsync(input);
        }

        [HttpPut]
        public async Task<BookDto> UpdateAsync( [FromBody] UpdateBookDto input)
        {
            return await _bookAppService.UpdateAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _bookAppService.DeleteAsync(id);
        }
    }
}
