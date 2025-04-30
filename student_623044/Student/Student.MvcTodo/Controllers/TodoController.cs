using Student.Todo;
using Student.Todo.Data;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Student.MvcTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITaskService _service;

        public TodoController(ITaskService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            DataSet dataSet = _service.GetTasksFromDataBase();

            var model = dataSet.Tables[0].AsEnumerable()
                .Select(row => new Student.MvcTodo.Models.Todo
                {
                    Id = row.Field<int>("Id"),
                    Title = row.Field<string>("Title"),
                    Description = row.Field<string>("Description")
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddTask(Task task)
        {
            _service.AddTaskInDataBase(new Task
            {
                Title = task.Title,
                Description = task.Description
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            _service.DeleteTaskFromId(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var task = _service.GetTasksFromDataBase().Tables[0]
                      .AsEnumerable()
                      .FirstOrDefault(row => row.Field<int>("Id") == id);

            if (task == null) return HttpNotFound();

            var model = new Models.Todo
            {
                Id = task.Field<int>("Id"),
                Title = task.Field<string>("Title"),
                Description = task.Field<string>("Description")
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Todo model)
        {
            _service.ChangeTaskFromId(model.Id, model.Title, model.Description);
            return RedirectToAction("Index");
        }
    }
}