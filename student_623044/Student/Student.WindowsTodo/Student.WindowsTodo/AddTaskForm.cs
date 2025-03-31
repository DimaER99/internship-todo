using Student.Todo;
using System;
using System.Windows.Forms;

namespace Student.WindowsTodo
{
    public partial class AddTaskForm : Form
    {
        private readonly Task _task;
        public AddTaskForm(Task task)
        {
            InitializeComponent();

            _task = task;
        }
        /// <summary>
        /// Подтверждение добавления задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonConfirmAddTask(object sender, EventArgs e)
        {
            _task.Title = textBox1.Text;
            _task.Description = textBox2.Text;

            MessageBox.Show("Задача добавлена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
