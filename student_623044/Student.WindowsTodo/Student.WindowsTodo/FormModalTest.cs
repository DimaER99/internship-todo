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
    public partial class FormModalTest : Form
    {
        private readonly Task _task;

        public FormModalTest(Task task)
        {
            InitializeComponent();

            _task = task;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            _task.Title = textBox1.Text;
            _task.Description = textBox2.Text;

            MessageBox.Show("Задача добавлена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
