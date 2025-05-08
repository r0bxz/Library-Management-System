using LibraryMS.BorrowedBooks;
using LibraryMS.Managers;
using Volo.Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using LibraryMS.Books;
using Volo.Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using LibraryMS.Borrowers;

namespace LibraryMS.Application
{
    [RemoteService(false)]
    public class BorrowedBookAppService : LibraryMSAppService, IBorrowedBookAppService
    {
        private readonly BorrowedBookManager _borrowedBookManager;

        public BorrowedBookAppService(BorrowedBookManager borrowedBookManager)
        {
            _borrowedBookManager = borrowedBookManager;
        }
        public async Task<BorrowedBookDto> CreateAsync(CreateBorrowedBookDto input)
        {
            var borrowedBook = await _borrowedBookManager.CreateAsync(input.BookId, input.BorrowerId, input.BorrowDate, (DateTime)input.ReturnDate ,
                b => b.BookId == input.BookId && b.BorrowerId == input.BorrowerId && !b.IsReturned);
            return ObjectMapper.Map<BorrowedBook, BorrowedBookDto>(borrowedBook);
        }
        public async Task<BorrowedBookDto> ReturnAsync(ReturnBorrowedBookDto input)
        {
       
            var borrowedBook = await _borrowedBookManager.ReturnAsync(input.Id, input.ReturnDate);

            return ObjectMapper.Map<BorrowedBook, BorrowedBookDto>(borrowedBook);
        }
        public async Task<PagedResultDto<BorrowedBookDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var borrowedBooks = await _borrowedBookManager.GetAllAsync(b => !b.IsReturned);  
            return new PagedResultDto<BorrowedBookDto>(
                borrowedBooks.Count,
                ObjectMapper.Map<List<BorrowedBook>, List<BorrowedBookDto>>(borrowedBooks)
            );
        }
        public async Task<List<BorrowedBookDto>> GetReturnedAsync()
        {
            var returnedBooksList = await _borrowedBookManager.GetReturnedAsync(b=>b.IsReturned);
            return ObjectMapper.Map<List<BorrowedBook>, List<BorrowedBookDto>>(returnedBooksList);
        }
        public async Task<List<BorrowedBookDto>> GetOverdueAsync(DateTime currentDate)
        {
            var overDueBooks = await _borrowedBookManager.GetOverdueAsync(currentDate, b => !b.IsReturned && b.ReturnDate < currentDate);
            return ObjectMapper.Map<List<BorrowedBook>, List<BorrowedBookDto>>(overDueBooks);
        }
    }
}
