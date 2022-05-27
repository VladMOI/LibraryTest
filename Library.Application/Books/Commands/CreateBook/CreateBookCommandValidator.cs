using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createBookCommand => createBookCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createBookCommand => createBookCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
