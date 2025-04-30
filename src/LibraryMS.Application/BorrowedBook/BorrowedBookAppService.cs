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

            
            var borrowedBook = await _borrowedBookManager.CreateAsync(input.BookId, input.BorrowerId, input.BorrowDate, (DateTime)input.ReturnDate);
            return ObjectMapper.Map<BorrowedBook, BorrowedBookDto>(borrowedBook);
        }


        public async Task<BorrowedBookDto> ReturnAsync(ReturnBorrowedBookDto input)
        {
       
            var borrowedBook = await _borrowedBookManager.ReturnAsync(input.Id, input.ReturnDate);

            return ObjectMapper.Map<BorrowedBook, BorrowedBookDto>(borrowedBook);
        }

        public async Task<PagedResultDto<BorrowedBookDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var items = await _borrowedBookManager.GetAllAsync(b=>!b.IsReturned);

            return new PagedResultDto<BorrowedBookDto>(
                items.Count,
                ObjectMapper.Map<List<BorrowedBook>, List<BorrowedBookDto>>(items)
            );
        }

        public async Task<List<BorrowedBookDto>> GetReturnedAsync()
        {
            var borrowedBooks = await _borrowedBookManager.GetAllAsync(b=>b.IsReturned);
            return ObjectMapper.Map<List<BorrowedBook>, List<BorrowedBookDto>>(borrowedBooks);
        }

        public async Task<List<BorrowedBookDto>> GetOverdueAsync(DateTime currentDate)
        {
            var borrowedBooks = await _borrowedBookManager.GetOverdueAsync(currentDate);
            return ObjectMapper.Map<List<BorrowedBook>, List<BorrowedBookDto>>(borrowedBooks);
        }
    }
}
