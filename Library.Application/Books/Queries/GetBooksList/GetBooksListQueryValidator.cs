using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Library.Application.Books.Queries.GetBooksList
{
    public class GetBooksListQueryValidator : AbstractValidator<GetBooksListQuery>
    {
        public GetBooksListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }

    }
}
