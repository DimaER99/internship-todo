using Student.Todo;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student.WebFormsTodo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cacheList = Cache["taskList"] as List<Task>;
                dataView.DataSource = cacheList;
                dataView.DataBind();
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

            ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", "const myModalAlternative = new bootstrap.Modal('#modalAddTask', null); myModalAlternative.show();", true);
        }

        protected void dataView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var cacheList = Cache["taskList"] as List<Task>;
            int selectedIndex = e.NewEditIndex;

            hfSelectIndex.Value = selectedIndex.ToString();

            tbEditTitle.Text = cacheList[selectedIndex].Title;
            tbEditDescription.Text = cacheList[selectedIndex].Description;

            dataView.DataSource = cacheList;
            dataView.DataBind();

            ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", "const myModalAlternative = new bootstrap.Modal('#modalEditTask', null); myModalAlternative.show();", true);
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

            dataView.DataSource = Cache["taskList"];
            dataView.DataBind();
        }

        protected void lbSaveEditChanges_OnClick(object sender, EventArgs e)
        {
            var cacheList = Cache["taskList"] as List<Task>;

            if (cacheList == null && hfSelectIndex.Value == null)
            {
                return;
            }

            int selectedIndex = Convert.ToInt32(hfSelectIndex.Value);
            var existingTask = cacheList[selectedIndex];

            if (existingTask != null)
            {
                existingTask.Title = tbEditTitle.Text.Trim();
                existingTask.Description = tbEditDescription.Text.Trim();
            }

            Cache["taskList"] = cacheList;
            hfSelectIndex.Value = string.Empty;
            dataView.DataSource = cacheList;
            dataView.DataBind();
        }

        protected void lbEditDeleteTask_OnClick(object sender, EventArgs e)
        {
            var cacheList = Cache["taskList"] as List<Task>;

            int selectedIndex = Convert.ToInt32(hfSelectIndex.Value);

            cacheList.Remove(cacheList[selectedIndex]);

            hfSelectIndex.Value = string.Empty;
            dataView.DataSource = cacheList;
            dataView.DataBind();
        }

        protected void lbRowDeletingTask(object sender, GridViewDeleteEventArgs e)
        {
            hfSelectIndex.Value = e.RowIndex.ToString();

            ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", "const myModalAlternative = new bootstrap.Modal('#modalDeleteTask', null); myModalAlternative.show();", true);
        }
    }
}