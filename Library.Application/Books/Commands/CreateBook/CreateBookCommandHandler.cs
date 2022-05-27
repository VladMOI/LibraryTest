using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBooksDbContext _dbContext;
        public CreateBookCommandHandler(IBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellation)
        {
            var book = new Book
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = DateTime.Now

            };
            await _dbContext.Books.AddAsync(book, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
            return book.Id;
        }
    }
}
