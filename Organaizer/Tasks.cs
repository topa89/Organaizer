using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Organaizer
{
    public partial class Tasks : Form
    {
        Point pt = Screen.PrimaryScreen.WorkingArea.Location;
        private int _secondClose = 0;
        internal int SecondClose
        {
            get { return _secondClose; }
            set { _secondClose = value; }
        }

        public Tasks(int secondToClose, string text)
        {
            InitializeComponent();
            SecondClose = secondToClose;
            label2.Text = text;
            StartPosition = FormStartPosition.Manual;
            pt.Offset(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pt.Offset(-Width, -Height);
            Location = pt;
            Location = new Point(Location.X, Location.Y + Height);
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < Height; i++)
                {
                    if (IsHandleCreated)
                    {
                        Invoke((Action)(() =>
                        {
                            Location = new Point(Location.X, Location.Y - 1);
                        }));
                    }
                    if (Location == pt) break;
                    Thread.Sleep(5);
                }
            });
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(_secondClose * 1000);
                this.Invoke((Action)(() =>
                {
                    ((IDisposable)this).Dispose();
                }));
            });
        }
    }
}
