using System;
using LibraryMS.Categories;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace LibraryMS.Books
{
    public class Book : Entity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; } 
        public DateOnly PublishedDate { get; set; }
        public string ISBN { get; set; }
        public string CoverImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } 

        
        internal Book() { }

        
        public Book(int categoryId, string title, string author, DateOnly publishedDate, string isbn, string coverImagePath)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Author = Check.NotNullOrWhiteSpace(author, nameof(author));
            PublishedDate = Check.NotNull(publishedDate, nameof(publishedDate));
            ISBN = Check.NotNullOrWhiteSpace(isbn, nameof(isbn));
            CoverImagePath = Check.NotNullOrWhiteSpace(coverImagePath, nameof(coverImagePath));
            CategoryId = categoryId;
        }

        
        internal Book ChangeTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), maxLength: 255); 
            return this;
        }

        
        public Book ChangeAuthor(string author)
        {
            Author = Check.NotNullOrWhiteSpace(author, nameof(author), maxLength: 255); 
            return this;
        }

        public Book ChangePublishedDate(DateOnly date)
        {
            PublishedDate = date;
            return this;
        }




        public Book ChangeISBN(string isbn)
        {
            ISBN = Check.NotNullOrWhiteSpace(isbn, nameof(isbn), maxLength: 20); 
            return this;
        }

       
        public Book ChangeCoverImagePath(string coverImagePath)
        {
            CoverImagePath = Check.NotNullOrWhiteSpace(coverImagePath, nameof(coverImagePath));
            return this;
        }

        
        public Book ChangeCategoryId(int categoryId)
        {
            CategoryId = categoryId;
            return this;
        }
    }
}
