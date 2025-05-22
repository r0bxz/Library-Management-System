using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryMS.BorrowedBooks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace LibraryMS.Borrowers
{
    public class Borrower : FullAuditedEntity<int>
    {
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }

        internal Borrower() { }

        public Borrower(string fullName, string email, string phoneNumber)
        {
            FullName = Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Email = Check.NotNullOrWhiteSpace(email, nameof(email));
            PhoneNumber = phoneNumber;
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
            PhoneNumber = phoneNumber;
            return this;
        }
    }
}
