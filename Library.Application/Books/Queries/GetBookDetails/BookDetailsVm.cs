using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Domain;
using Library.Application.Common.Mappings;

namespace Library.Application.Books.Queries.GetBookDetails
{
    public  class BookDetailsVm : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }
        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(
                bookVm => bookVm.Title,
                opt => opt.MapFrom(book => book.Title))
                .ForMember(bookVm => bookVm.Details,
                opt => opt.MapFrom(book => book.Details))
                .ForMember(bookVm => bookVm.Id,
                opt => opt.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.CreationDate,
                opt => opt.MapFrom(book => book.CreationDate))
                .ForMember(bookVm => bookVm.EditTime,
                opt => opt.MapFrom(book => book.EditDate));
        }
    }
}
