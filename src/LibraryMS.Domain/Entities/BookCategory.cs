using System;
using LibraryMS.Books;
using LibraryMS.Categories;
using Volo.Abp.Domain.Entities;

namespace LibraryMS.BookCategories
{
    public class BookCategory : Entity
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public BookCategory() { }

        public BookCategory(int bookId, int categoryId)
        {
            BookId = bookId;
            CategoryId = categoryId;
        }

        public override object?[] GetKeys()
        {
            return new object[] { BookId, CategoryId };

        }
    }
}
