
namespace Library.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(BooksDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
