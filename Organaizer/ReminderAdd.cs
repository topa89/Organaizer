using System;
using System.Windows.Forms;

namespace Organaizer
{
    public partial class ReminderAdd : Form
    {
        public ReminderAdd()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxReminder.Text == "") MessageBox.Show("Введите текст");
            else Close();
        }
    }
}
