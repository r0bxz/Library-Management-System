using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using LibraryMS.Managers;
using LibraryMS.Books;
using Volo.Abp;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LibraryMS.Books
{
    [RemoteService(false)]
    public class BookAppService : LibraryMSAppService, IBookAppService
    {
        private readonly BookManager _bookManager;

        public BookAppService(BookManager bookManager)
        {
            _bookManager = bookManager;
        }
        public async Task<BookDto> GetAsync(int id)
        {

            var book = await _bookManager.GetAsync(id);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(CreateBookDto input)
        {

            var book = await _bookManager.CreateAsync(
                input.Title,
                input.Author,
                input.PublishedDate,
                input.ISBN,
                input.CoverImagePath,
                input.CategoryId
            );

            return ObjectMapper.Map<Book, BookDto>(book);
        }
        public async Task<BookDto> UpdateAsync(UpdateBookDto input)
        {


            var book = await _bookManager.UpdateAsync(input.Id, input.Title, input.Author, input.PublishedDate, input.ISBN, input.CoverImagePath, input.CategoryId);

            return ObjectMapper.Map<Book, BookDto>(book);
        }
        public async Task DeleteAsync(int id)
        {

            var book = await _bookManager.GetAsync(id);
            await _bookManager.DeleteAsync(id);
        }
        public async Task<PagedResultDto<BookDto>> GetAllAsync(PagedAndSortedResultRequestDto input, string category = null, string searchQuery = null)
        {
            var books = await _bookManager.GetAllAsync(category, searchQuery);

            var pagedBooks = books
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToList();

            return new PagedResultDto<BookDto>(
                books.Count,
                ObjectMapper.Map<List<Book>, List<BookDto>>(pagedBooks)
            );
        }


    }
}
