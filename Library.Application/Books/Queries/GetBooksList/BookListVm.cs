using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Books.Queries.GetBooksList
{
    public class BookListVm 
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
