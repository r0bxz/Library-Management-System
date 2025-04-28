using AutoMapper;
using LibraryMS.Books;
using LibraryMS.BorrowedBooks;
using LibraryMS.Borrowers;
using LibraryMS.Categories;

namespace LibraryMS;

public class LibraryMSApplicationAutoMapperProfile : Profile
{
    public LibraryMSApplicationAutoMapperProfile()
    {

        CreateMap<Book, BookDto>();
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<Borrower, BorrowerDto>();
        CreateMap<CreateBorrowerDto, Borrower>();
        CreateMap<UpdateBorrowerDto, Borrower>();


        CreateMap<BorrowedBook, BorrowedBookDto>();
        CreateMap<CreateBorrowedBookDto, BorrowedBook>();
        CreateMap<UpdateBorrowedBookDto, BorrowedBook>();



    }
}
