using System.Data;

namespace Student.Todo.Data
{
    public class TaskServiceEF : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskServiceEF(string connectionString)
        {
            _context = new AppDbContext(connectionString);
        }

        public TaskServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public void AddTaskInDataBase(Task task)
        {
            _context.Todo.Add(task);
            _context.SaveChanges();
        }

        public void ChangeTaskFromId(int id, string title, string description)
        {
            var task = _context.Todo.Find(id);
            if (task == null) return;

            task.Title = title;
            task.Description = description;
            _context.SaveChanges();
        }

        public void DeleteTaskFromId(int id)
        {
            var task = _context.Todo.Find(id);
            if (task != null)
            {
                _context.Todo.Remove(task);
                _context.SaveChanges();
            }
        }

       public DataSet GetTasksFromDataBase()
        {
            var dataSet = new DataSet();
            var table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Description", typeof(string));

            foreach (var task in _context.Todo)
            {
                table.Rows.Add(task.Id, task.Title, task.Description);
            }

            dataSet.Tables.Add(table);
            return dataSet;
        }
    }
}
