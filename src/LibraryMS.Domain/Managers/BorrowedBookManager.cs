using LibraryMS.BorrowedBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace LibraryMS.Managers
{
    public class BorrowedBookManager : DomainService
    {
        private readonly IRepository<BorrowedBook, int> _borrowedBookRepository;

        public BorrowedBookManager(IRepository<BorrowedBook, int> borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }

        public async Task<BorrowedBook> CreateAsync(int bookId, int borrowerId, DateTime borrowDate, DateTime returnDate)
        {
          
            var existingBorrowedBook = await _borrowedBookRepository
                .FirstOrDefaultAsync(b => b.BookId == bookId && b.BorrowerId == borrowerId && !b.IsReturned);

            if (existingBorrowedBook != null)
            {
                throw new UserFriendlyException(LibraryMSDomainErrorCodes.BookAlreadyBorrowed);
            }

            var borrowedBook = new BorrowedBook(bookId, borrowerId, borrowDate, returnDate);
            return await _borrowedBookRepository.InsertAsync(borrowedBook);
        }

        public async Task<BorrowedBook> ReturnAsync(int id, DateTime returnDate)
        {
            var borrowedBook = await _borrowedBookRepository.GetAsync(id);


            borrowedBook.ReturnBook(returnDate);
            

            return await _borrowedBookRepository.UpdateAsync(borrowedBook);
        }

        public async Task<List<BorrowedBook>> GetAllAsync()
        {
           
            return await _borrowedBookRepository
                .GetListAsync(b => !b.IsReturned);
        }

        public async Task<List<BorrowedBook>> GetReturnedAsync()
        {
          
            return await _borrowedBookRepository
                .GetListAsync(b => b.IsReturned);
        }

        public async Task<List<BorrowedBook>> GetOverdueAsync(DateTime currentDate)
        {
            
            return await _borrowedBookRepository
                .GetListAsync(b => !b.IsReturned && b.ReturnDate < currentDate);
        }
    }
}
