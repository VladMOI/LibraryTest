using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;
using Library.Domain;

namespace Library.Application.Books.Queries.GetBookDetails
{
    public  class GetBooksDetailQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IBooksDbContext _dbContext;

        public GetBooksDetailQueryHandler(IBooksDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<BookDetailsVm> Handle(GetBookDetailsQuery request, CancellationToken token)
        {
            var entity = await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, token);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            return _mapper.Map<BookDetailsVm>(entity);
        }
    }
}
