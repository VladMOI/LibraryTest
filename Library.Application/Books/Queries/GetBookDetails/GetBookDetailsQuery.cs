using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<BookDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

    }
}
