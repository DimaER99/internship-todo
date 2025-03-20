using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student.WindowsTodo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var task = new Task("", "");

            FormModalTest modalForm = new FormModalTest(task);

            DialogResult result = modalForm.ShowDialog();

            if (task != null)
            {
                dataGridView1.Rows.Add(task.Title, task.Description);
            }
        }

        public void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.AutoResizeRow(row.Index, DataGridViewAutoSizeRowMode.AllCells);
            }

            dataGridView1.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            dataGridView1.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);

            dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;

            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                var curentCelsRow = dataGridView1.Rows[hit.RowIndex].Cells;

                if (hit.ColumnIndex == 2 && curentCelsRow[0].Value != null && curentCelsRow[1].Value != null)
                {
                    FormDelete deleteModalForm = new FormDelete(dataGridView1, hit.RowIndex);
                    DialogResult result = deleteModalForm.ShowDialog();
                }
            }
        }
    }
}