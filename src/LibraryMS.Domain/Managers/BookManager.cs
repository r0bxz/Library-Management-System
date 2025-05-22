using LibraryMS.BookCategories;
using LibraryMS.Books;
using LibraryMS.Categories;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class BookManager : DomainService
{
    private readonly IRepository<Book, int> _bookRepository;
    private readonly IRepository<BookCategory> _bookCategoryRepository;
    private readonly IRepository<Category, int> _categoryRepository;

    public BookManager(
        IRepository<Book, int> bookRepository,
        IRepository<BookCategory> bookCategoryRepository,
        IRepository<Category, int> categoryRepository)
    {
        _bookRepository = bookRepository;
        _bookCategoryRepository = bookCategoryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Book> CreateAsync(string title, string author, DateTime publishedDate, string isbn, string coverImagePath, List<int> categoryIds)
    {
        var book = new Book(title, author, publishedDate, isbn, coverImagePath, categoryIds);
        await _bookRepository.InsertAsync(book);

        var bookCategories = categoryIds.Select(categoryId => new BookCategory(book.Id, categoryId)).ToList();
        await _bookCategoryRepository.InsertManyAsync(bookCategories);

        book.BookCategories = bookCategories;

        return book;
    }

    public async Task<Book> UpdateAsync(int id, string title, string author, DateTime publishedDate, string isbn, string coverImagePath, List<int> categoryIds)
    {
        var book = await _bookRepository.GetAsync(id);

        book.ChangeISBN(isbn);
        book.ChangeTitle(title);
        book.ChangeAuthor(author);
        book.ChangePublishedDate(publishedDate);
        book.ChangeCoverImagePath(coverImagePath);

        var existingCategories = await _bookCategoryRepository.GetListAsync(bc => bc.BookId == book.Id);
        await _bookCategoryRepository.DeleteManyAsync(existingCategories);

        var newBookCategories = categoryIds.Select(categoryId => new BookCategory(book.Id, categoryId)).ToList();
        await _bookCategoryRepository.InsertManyAsync(newBookCategories);

        book.BookCategories = newBookCategories;

        return await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteAsync(int id)
    {
        var existingCategories = await _bookCategoryRepository.GetListAsync(bc => bc.BookId == id);
        await _bookCategoryRepository.DeleteManyAsync(existingCategories);
        await _bookRepository.DeleteAsync(id);
    }

    public async Task<Book?> GetAsync(int id)
    {
        var queryable = await _bookRepository.GetQueryableAsync();

        var book = await queryable
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

        return book;
    }

    public async Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>> predicate = null)
    {
        var query = await _bookRepository.GetQueryableAsync();

        query = query
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category);

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }

}
