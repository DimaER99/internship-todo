using Microsoft.EntityFrameworkCore;

namespace Student.Todo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions<AppDbContext> GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public DbSet<Task> Todo { get; set; }
    }
}
