using LibraryMS.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LibraryMS.HttpApi.Controllers
{
    [Route("api/borrowed-books")]
    public class BorrowedBookController : LibraryMSController
    {
        private readonly IBorrowedBookAppService _borrowedBookAppService;

        public BorrowedBookController(IBorrowedBookAppService borrowedBookAppService)
        {
            _borrowedBookAppService = borrowedBookAppService;
        }

        // Create a new borrowed book record
        [HttpPost]
        public async Task<ActionResult<BorrowedBookDto>> CreateAsync([FromBody] CreateBorrowedBookDto input)
        {
            var result = await _borrowedBookAppService.CreateAsync(input);
            return Ok(result);
        }

        // Mark a book as returned
        [HttpPut("{id}/return")]
        public async Task<ActionResult<BorrowedBookDto>> ReturnAsync(int id, [FromBody] ReturnBorrowedBookDto input)
        {
            var result = await _borrowedBookAppService.ReturnAsync(id, input);
            return Ok(result);
        }

        
        [HttpGet]
        public async Task<ActionResult<PagedResultDto<BorrowedBookDto>>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await _borrowedBookAppService.GetAllAsync(input);
            return Ok(result);
        }

        
        [HttpGet("returned")]
        public async Task<ActionResult<List<BorrowedBookDto>>> GetReturnedAsync()
        {
            var result = await _borrowedBookAppService.GetReturnedAsync();
            return Ok(result);
        }

        
        [HttpGet("overdue")]
        public async Task<ActionResult<List<BorrowedBookDto>>> GetOverdueAsync([FromQuery] DateTime currentDate)
        {
            var result = await _borrowedBookAppService.GetOverdueAsync(currentDate);
            return Ok(result);
        }
    }
}
