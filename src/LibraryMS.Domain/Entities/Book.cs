using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using LibraryMS.Categories;
using LibraryMS.BookCategories;
using System.Linq;

namespace LibraryMS.Books
{
    public class Book : FullAuditedEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public string CoverImagePath { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        internal Book()
        {

        }

        public Book(string title, string author, DateTime publishedDate, string isbn, string coverImagePath, List<int> categoryIds)
        {
            ISBN = isbn;
            PublishedDate = publishedDate;
            CoverImagePath = coverImagePath;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Author = Check.NotNullOrWhiteSpace(author, nameof(author));
        }

        public Book ChangeTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), maxLength: 255);
            return this;
        }

        public Book ChangeAuthor(string author)
        {
            Author = Check.NotNullOrWhiteSpace(author, nameof(author), maxLength: 255);
            return this;
        }

        public Book ChangePublishedDate(DateTime date)
        {
            PublishedDate = date;
            return this;
        }

        public Book ChangeISBN(string isbn)
        {
            ISBN = isbn;
            return this;
        }

        public Book ChangeCoverImagePath(string coverImagePath)
        {
            CoverImagePath = coverImagePath;
            return this;
        }
    }
}
