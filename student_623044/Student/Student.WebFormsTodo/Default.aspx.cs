using Student.Todo;
using Student.Todo.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student.WebFormsTodo
{
    public partial class _Default : Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        TaskService service = new TaskService(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cacheList = Cache["taskList"] as List<Task>;

                if (cacheList != null)
                {
                    gvTask.DataSource = cacheList;
                    gvTask.DataBind();
                }
                else
                {
                    var dataSet = service.GetTasksFromDataBase();
                    gvTask.DataSource = dataSet.Tables[0];
                    gvTask.DataBind();
                    Cache["taskList"] = dataSet.Tables[0].AsEnumerable();
                }
            }
        }

        protected void bAddTask_OnClick(object sender, EventArgs e)
        {
            if (tbEditTitle.Text != null && tbEditDescription.Text != null)
            {
                tbEditTitle.Text = string.Empty;
                tbEditDescription.Text = string.Empty;
            }

            if (tbAddTitle.Text != null && tbAddDescription.Text != null)
            {
                tbAddTitle.Text = string.Empty;
                tbAddDescription.Text = string.Empty;
            }

            ClientScript.RegisterStartupScript(this.GetType(),
                "ShowAlert", "const myModalAlternative = new bootstrap.Modal('#modalAddTask', null); myModalAlternative.show();", true);
        }


        protected void lbSaveAddChanges_OnClick(object sender, EventArgs e)
        {
            var taskList = new List<Task>();
            var cacheList = Cache["taskList"] as List<Task>;

            if (cacheList == null)
            {
                taskList.Add(new Task(tbAddTitle.Text, tbAddDescription.Text));
                Cache["taskList"] = taskList;
            }
            else
            {
                cacheList.Add(new Task(tbAddTitle.Text, tbAddDescription.Text));
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            TaskService service = new TaskService(connectionString);

            Task task = new Task(tbAddTitle.Text, tbAddDescription.Text);
            service.AddTaskInDataBase(task);

            var dataSet = service.GetTasksFromDataBase();
            gvTask.DataSource = dataSet.Tables[0];
            gvTask.DataBind();
        }

        protected void lbSaveEditChanges_OnClick(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            TaskService service = new TaskService(connectionString);

            var idTask = (int)Cache["idTask"];
            string changeTitle = tbEditTitle.Text;
            string changeDescription = tbEditDescription.Text;

            service.ChangeTaskFromId(idTask, changeTitle, changeDescription);
            var dataSet = service.GetTasksFromDataBase();
            gvTask.DataSource = dataSet.Tables[0];
            gvTask.DataBind();
        }

        protected void gvTask_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            Cache["idTask"] = (int)gvTask.DataKeys[e.NewEditIndex].Values["Id"];
            var title = gvTask.Rows[e.NewEditIndex].Cells[1].Text;
            var description = gvTask.Rows[e.NewEditIndex].Cells[2].Text;

            tbEditTitle.Text = title;
            tbEditDescription.Text = description;

            ClientScript.RegisterStartupScript(this.GetType(),
                "ShowAlert", "const myModalAlternative = new bootstrap.Modal('#modalEditTask', null); myModalAlternative.show();", true);
        }

        protected void lbDeleteRow_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            TaskService service = new TaskService(connectionString);

            var idTask = (int)Cache["idTask"];

            service.DeleteTaskFromId(idTask);

            var dataSet = service.GetTasksFromDataBase();
            gvTask.DataSource = dataSet.Tables[0];
            gvTask.DataBind();
        }

        protected void gvTask_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Cache["idTask"] = (int)gvTask.DataKeys[e.RowIndex].Values["Id"];

            ClientScript.RegisterStartupScript(this.GetType(),
                "ShowAlert", "const myModalAlternative = new bootstrap.Modal('#modalDeleteTask', null); myModalAlternative.show();", true);
        }
    }
}