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

        [HttpPost("borrow-a-book")]
        public async Task<ActionResult<BorrowedBookDto>> CreateAsync([FromBody] CreateBorrowedBookDto input)
        {
            var result = await _borrowedBookAppService.CreateAsync(input);
            return Ok(result);
        }

        [HttpPut("return-a-book")]
        public async Task<ActionResult<BorrowedBookDto>> ReturnAsync([FromBody] ReturnBorrowedBookDto input)
        {
            var result = await _borrowedBookAppService.ReturnAsync(input);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<BorrowedBookDto>>> GetAllAsync([FromQuery] PagedAndSortedResultRequestDto input)
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
