using System;
using System.Windows.Forms;

namespace Organaizer
{
    public partial class ReminderAdd : Form
    {
        public ReminderAdd()
        {
            InitializeComponent();
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxReminder.Text == "")
            {
                MessageBox.Show("Введите текст");
            }
            else
            {
                Close();
            }
        }
    }
}
