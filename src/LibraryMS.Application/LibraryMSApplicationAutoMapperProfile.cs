using System.Linq;
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


        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();


        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<Borrower, BorrowerDto>();
        CreateMap<CreateBorrowerDto, Borrower>();
        CreateMap<UpdateBorrowerDto, Borrower>();


        CreateMap<BorrowedBook, BorrowedBookDto>();
        CreateMap<CreateBorrowedBookDto, BorrowedBook>();
        CreateMap<UpdateBorrowedBookDto, BorrowedBook>();

        CreateMap<Book, BookDto>()
        .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(
        src => src.BookCategories.Select(bc => bc.CategoryId)));

        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.BookIds, opt => opt.MapFrom(
                src => src.BookCategories.Select(bc => bc.BookId)));




    }
}
