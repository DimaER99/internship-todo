using System.Data.Entity;

namespace Student.Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Task> Todo { get; set; }
    }
}
