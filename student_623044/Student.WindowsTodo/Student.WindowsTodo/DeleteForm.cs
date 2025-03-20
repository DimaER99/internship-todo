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
    public partial class DeleteForm : Form
    {
        /// <summary>
        /// Поле для хранения ссылки
        /// </summary>
        private readonly DataGridView GridView;

        /// <summary>
        /// Поле для хранения индекса
        /// </summary>
        public readonly int Index;
        public DeleteForm(DataGridView gridView, int curentIndex)
        {
            InitializeComponent();

            GridView = gridView;
            Index = curentIndex;
        }
        /// <summary>
        /// Подтверждение удаления задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonDeleteTask(object sender, EventArgs e)
        {
            GridView.Rows.Remove(GridView.Rows[Index]);

            MessageBox.Show("Задача удалена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
