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
    public partial class FormDelete : Form
    {
        private readonly DataGridView GridView;

        public readonly int Index;

        public FormDelete(DataGridView gridView, int curentIndex)
        {
            InitializeComponent();

            GridView = gridView;
            Index = curentIndex;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            GridView.Rows.Remove(GridView.Rows[Index]);

            MessageBox.Show("Задача удалена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
