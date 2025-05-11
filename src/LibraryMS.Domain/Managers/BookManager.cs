using LibraryMS.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using System.Linq;
using Volo.Abp;
using LibraryMS.BorrowedBooks;
using System.Linq.Expressions;
public class BookManager : DomainService
{
    private readonly IRepository<Book, int> _bookRepository;
    public BookManager(IRepository<Book, int> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book> CreateAsync(string title, string author, DateTime publishedDate, string isbn, string coverImagePath, int categoryId)
    {
        var book = new Book(categoryId, title, author, publishedDate, isbn, coverImagePath);

        return await _bookRepository.InsertAsync(book);
    }

    public async Task<Book> UpdateAsync(int id, string title, string author, DateTime publishedDate, string isbn, string coverImagePath, int categoryId)
    {
        var book = await _bookRepository.GetAsync(id);

        book.ChangeISBN(isbn);
        book.ChangeTitle(title);
        book.ChangeAuthor(author);
        book.ChangeCategoryId(categoryId);
        book.ChangePublishedDate(publishedDate);
        book.ChangeCoverImagePath(coverImagePath);

        return await _bookRepository.UpdateAsync(book);
    }
    public async Task DeleteAsync(int id)
    {
        await _bookRepository.DeleteAsync(id);
    }

    public async Task<Book> GetAsync(int id)
    {
        return await _bookRepository.GetAsync(id);
    }
    public async Task<List<Book>> GetAllAsync(
     Expression<Func<Book, bool>> predicate = null)
    {
        var query = await _bookRepository.GetQueryableAsync();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }

}

