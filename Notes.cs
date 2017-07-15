using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Notes
{
	public Notes()
	{

	}

    protected void CreateNote()
    {
        DialogText f = new DialogText()
        {
            Height = SystemInformation.VirtualScreen.Height / 2,
            Width = SystemInformation.VirtualScreen.Width / 2,
            StartPosition = FormStartPosition.CenterScreen,
        };
        f.ShowDialog();
        if (f.textBoxNote.Text != "") CreateLbl(f.textBoxNote.Text);
    }
}
