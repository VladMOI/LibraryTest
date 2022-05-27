using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(deleteBookCommand => deleteBookCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteBookCommand => deleteBookCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
