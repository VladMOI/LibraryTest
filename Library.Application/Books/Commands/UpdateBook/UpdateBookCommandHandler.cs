using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Library.Application.Common.Exceptions;
using Library.Domain;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBooksDbContext _dbContext;
        public UpdateBookCommandHandler(IBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellation)
        {
            var entity =
                await _dbContext.Books.FirstOrDefaultAsync(
                    book => book.Id == request.Id, cancellation
                    );
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellation);
            return Unit.Value;
        }
    }
}
