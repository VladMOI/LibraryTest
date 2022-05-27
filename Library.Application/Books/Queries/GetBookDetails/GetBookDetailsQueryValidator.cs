using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Library.Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryValidator : AbstractValidator<GetBookDetailsQuery>
    {
        public GetBookDetailsQueryValidator()
        {
            RuleFor(book => book.Id).NotEqual(Guid.Empty);
            RuleFor(book => book.UserId).NotEqual(Guid.Empty);
        }
    }
}
