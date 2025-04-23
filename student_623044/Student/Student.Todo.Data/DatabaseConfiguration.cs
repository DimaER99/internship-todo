using System.Data.Entity;

namespace Student.Todo.Data
{
    public class DatabaseConfiguration : DbContext
    {
        public DatabaseConfiguration(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Task> Todo { get; set; }
    }
}
