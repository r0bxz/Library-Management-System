using LibraryMS.BorrowedBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using System.Linq.Expressions;

namespace LibraryMS.Managers
{
    public class BorrowedBookManager : DomainService
    {
        private readonly IRepository<BorrowedBook, int> _borrowedBookRepository;
        public BorrowedBookManager(IRepository<BorrowedBook, int> borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }

        public async Task<BorrowedBook> CreateAsync(int bookId, int borrowerId, DateTime borrowDate, DateTime returnDate, Expression<Func<BorrowedBook, bool>> predicate)
        {
            var existingBorrowedBook = await _borrowedBookRepository
               .FirstOrDefaultAsync(predicate);
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

        public async Task<List<BorrowedBook>> GetAllAsync(Expression<Func<BorrowedBook, bool>> predicate)
        {
            var query = await _borrowedBookRepository.GetQueryableAsync();
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<List<BorrowedBook>> GetReturnedAsync(Expression<Func<BorrowedBook, bool>> predicate)
        {

            var query = await _borrowedBookRepository.GetQueryableAsync();
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<List<BorrowedBook>> GetOverdueAsync(DateTime currentDate, Expression<Func<BorrowedBook, bool>> predicate)
        {
            var query = await _borrowedBookRepository.GetQueryableAsync();
            return await query.Where(predicate).ToListAsync();
        }
    }
}
