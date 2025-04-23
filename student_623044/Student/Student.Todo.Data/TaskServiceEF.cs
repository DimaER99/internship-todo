using System.Data;

namespace Student.Todo.Data
{
    public class TaskServiceEF : ITaskService
    {
        private readonly DatabaseConfiguration _db;

        public TaskServiceEF(DatabaseConfiguration db)
        {
            _db = db;
        }

        void ITaskService.AddTaskInDataBase(Task task)
        {
            _db.Todo.Add(task);
            _db.SaveChanges();
        }

        void ITaskService.ChangeTaskFromId(int idChangeTask, string changeTitle, string changeDescription)
        {
            var task = _db.Todo.Find(idChangeTask);
            if (task == null) return;

            task.Title = changeTitle;
            task.Description = changeDescription;
            _db.SaveChanges();
        }

        void ITaskService.DeleteTaskFromId(int idTaskDelete)
        {
            var task = _db.Todo.Find(idTaskDelete);
            if (task != null)
            {
                _db.Todo.Remove(task);
                _db.SaveChanges();
            }
        }

        DataSet ITaskService.GetTasksFromDataBase()
        {
            var dataSet = new DataSet();
            var table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Description", typeof(string));

            foreach (var task in _db.Todo)
            {
                table.Rows.Add(task.Id, task.Title, task.Description);
            }

            dataSet.Tables.Add(table);
            return dataSet;
        }
    }
}
