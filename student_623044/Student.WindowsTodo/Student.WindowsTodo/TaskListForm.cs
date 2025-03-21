using System;
using System.Windows.Forms;

namespace Student.WindowsTodo
{
    public partial class TaskListForm : Form
    {
        public TaskListForm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }
        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddTask(object sender, EventArgs e)
        {
            var task = new Task("", "");

            AddTaskForm modalForm = new AddTaskForm(task);

            DialogResult result = modalForm.ShowDialog();

            if (task != null)
            {
                dataGridView1.Rows.Add(task.Title, task.Description);
            }
        }
        /// <summary>
        /// Основная форма DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DataGridView(object sender, MouseEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            dataGridView1.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            dataGridView1.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);

            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                var curentCelsRow = dataGridView1.Rows[hit.RowIndex].Cells;

                if (hit.ColumnIndex == 2 && curentCelsRow[0].Value != null && curentCelsRow[1].Value != null)
                {
                    DeleteForm deleteModalForm = new DeleteForm(dataGridView1, hit.RowIndex);
                    DialogResult result = deleteModalForm.ShowDialog();
                }
            }
        }
    }
}