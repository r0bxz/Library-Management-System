using System;
using LibraryMS.Books;
using LibraryMS.Borrowers;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace LibraryMS.BorrowedBooks
{
    public class BorrowedBook : FullAuditedEntity<int>
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
            IsReturned = false;
            BorrowerId = borrowerId;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
        }
        public BorrowedBook ReturnBook(DateTime returnDate)
        {
            ReturnDate = returnDate;
            IsReturned = true;
            return this;
        }
    }
}
