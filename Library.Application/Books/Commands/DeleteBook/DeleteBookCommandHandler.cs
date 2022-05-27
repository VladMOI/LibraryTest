using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksDbContext _dbContext;
        public DeleteBookCommandHandler(IBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteBookCommand reques, CancellationToken cancellation)
        {
            var entity = await _dbContext.Books.FindAsync(new object[] { reques.Id }, cancellation);
            if(entity == null || entity.UserId != reques.UserId)
            {
                throw new NotFoundException(nameof(Book), reques.Id);
            }
            _dbContext.Books.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellation);
            return Unit.Value;
        }
    }
}
