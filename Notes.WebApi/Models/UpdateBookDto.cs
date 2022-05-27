using AutoMapper;
using Library.Application.Books.Commands.UpdateBook;

namespace Notes.WebApi.Models
{
    public class UpdateBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
                .ForMember(bookCommand => bookCommand.Id,
                opt => opt.MapFrom(bookDto => bookDto.Id))
                .ForMember(bookCommand => bookCommand.Title,
                opt => opt.MapFrom(bookDto => bookDto.Title))
                .ForMember(bookCommand => bookCommand.Details,
                opt => opt.MapFrom(bookDto => bookDto.Details));

        }
    }
}
