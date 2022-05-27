using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;

namespace Library.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BooksDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IBooksDbContext>(provider => provider.GetService<BooksDbContext>());
            return services;
        }
    }
}
