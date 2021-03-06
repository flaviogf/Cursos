using AutoMapper;
using Library.Api.Entities;
using Library.Api.Models;

namespace Library.Api.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember((it) => it.AuthorFirstName, (it) => it.MapFrom(x => x.Author.FirstName))
                .ForMember((it) => it.AuthorLastName, (it) => it.MapFrom(x => x.Author.LastName));

            CreateMap<BookForCreationDto, Book>();

            CreateMap<Book, BookWithConcatenatedAuthorNameDto>()
                .ForMember((it) => it.Author, (it) => it.MapFrom(x => $"{x.Author.FirstName} {x.Author.LastName}"));
        }
    }
}
