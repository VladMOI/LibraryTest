using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Common.Mappings;
using Library.Domain;
using MediatR;
namespace Library.Application.Books.Queries.GetBooksList
{
    public class BookLookupDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Title, 
                opt  => opt.MapFrom(book => book.Title));
        }
    }
}
