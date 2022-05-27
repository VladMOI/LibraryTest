using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Common.Mappings;

namespace Notes.WebApi.Models
{
    public class CreateBookDto : IMapWith<CreateBookCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookCommand => bookCommand.Title,
                opt => opt.MapFrom(bookDto => bookDto.Title))
                .ForMember(bookCommand => bookCommand.Details,
                opt => opt.MapFrom(bookDto => bookDto.Details));
        }
    }
}
