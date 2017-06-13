using System;
using System.Windows.Forms;

namespace Organaizer
{
    public partial class DialogText : Form
    {
     
        public DialogText()
        {
            InitializeComponent();
        }

        private void addNoteBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        ~DialogText(){

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxNote.Text = "";
            Close();
        }

        private void textBoxNote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
