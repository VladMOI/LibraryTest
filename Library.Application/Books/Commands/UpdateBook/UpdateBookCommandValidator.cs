using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(updateBookCommand => updateBookCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(updateBookCommand => updateBookCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateBookCommand => updateBookCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
