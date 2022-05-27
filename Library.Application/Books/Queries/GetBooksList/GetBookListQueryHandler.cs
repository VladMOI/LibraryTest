using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooksList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBooksListQuery, BookListVm>
    {
        private readonly IBooksDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookListQueryHandler(IBooksDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BookListVm> Handle(GetBooksListQuery request, CancellationToken cancellation)
        {
            var booksQuery = await _dbContext.Books.Where(book => book.UserId == request.UserId).ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellation);
            return new BookListVm { Books = booksQuery };
        }
    }
}
