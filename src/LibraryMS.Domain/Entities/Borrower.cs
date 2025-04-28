using System.Collections.Generic;
using LibraryMS.BorrowedBooks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace LibraryMS.Borrowers
{
    public class Borrower : Entity<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }

        internal Borrower() { }

        public Borrower(string fullName, string email, string phoneNumber)
        {
            FullName = Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Email = Check.NotNullOrWhiteSpace(email, nameof(email));
            PhoneNumber = Check.NotNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
            BorrowedBooks = new List<BorrowedBook>();
        }

        public Borrower ChangeFullName(string fullName)
        {
            FullName = Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            return this;
        }

        public Borrower ChangeEmail(string email)
        {
            Email = Check.NotNullOrWhiteSpace(email, nameof(email));
            return this;
        }

        public Borrower ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = Check.NotNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
            return this;
        }
    }
}
