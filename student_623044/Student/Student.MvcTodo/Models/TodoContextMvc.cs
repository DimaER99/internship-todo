using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Student.MvcTodo.Models
{
    public class TodoContextMvc : DbContext
    {
        public TodoContextMvc(DbContextOptions<TodoContextMvc> options) : base(options) { }

        public DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TodoTasks"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

