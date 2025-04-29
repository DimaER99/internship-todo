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

        void ITaskService.AddTaskInDataBase(Task task)
        {
            _context.Todo.Add(task);
            _context.SaveChanges();
        }

        void ITaskService.ChangeTaskFromId(int idChangeTask, string changeTitle, string changeDescription)
        {
            var task = _context.Todo.Find(idChangeTask);
            if (task == null) return;

            task.Title = changeTitle;
            task.Description = changeDescription;
            _context.SaveChanges();
        }

        void ITaskService.DeleteTaskFromId(int idTaskDelete)
        {
            var task = _context.Todo.Find(idTaskDelete);
            if (task != null)
            {
                _context.Todo.Remove(task);
                _context.SaveChanges();
            }
        }

        DataSet ITaskService.GetTasksFromDataBase()
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
