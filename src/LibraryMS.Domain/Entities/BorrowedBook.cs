using System;
using LibraryMS.Books;
using LibraryMS.Borrowers;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace LibraryMS.BorrowedBooks
{
    public class BorrowedBook : Entity<int>
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        internal BorrowedBook() { }

        public BorrowedBook(int bookId, int borrowerId, DateTime borrowDate, DateTime returnDate)
        {
            BookId = bookId;
            BorrowerId = borrowerId;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
            IsReturned = false;
        }

        public BorrowedBook ReturnBook(DateTime returnDate)
        {
            ReturnDate = returnDate;
            IsReturned = true;
            return this;
        }
    }
}
