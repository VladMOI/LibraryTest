using Library.Application.Interfaces;
using Library.Domain;
using Library.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance
{
    public class BooksDbContext : DbContext, IBooksDbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BooksConfiguration());
            base.OnModelCreating(builder); 
        }
    }
}
