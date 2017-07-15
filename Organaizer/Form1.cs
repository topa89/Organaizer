using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Organaizer
{
    public partial class Form1 : Form
    {
        List<TextBox> txtboxList = new List<TextBox>();
        List<CheckBox> chkboxList = new List<CheckBox>();
        public CheckBox chkbox;
     
        private TextBox txtBoxCheckBox;
        public List<string> timeRemind = new List<string>();
        public List<string> textRemind = new List<string>();
        public List<string> dateRemind = new List<string>();
        int positionTextBoxRemind = 0;
        int positionChkBox = 5;
        int j = 0;
        bool checkPressedButton = true;

    
        public Form1()
        {

            InitializeComponent();
          
            panel1.HorizontalScroll.Enabled = false;
            panel1.VerticalScroll.Enabled = true;
            panel1.VerticalScroll.Visible = false;
            timer1.Interval = 1000;
            timer1.Stop();
            buttonShowReminders.Enabled = false;
            panel2.HorizontalScroll.Enabled = false;
            panel2.HorizontalScroll.Visible = false;
        }

        void NotificShow(int secondClose, string text) // Метод для вызова уведомления.
        {
            Tasks notific = new Tasks(secondClose, text)
            {
                Width = SystemInformation.VirtualScreen.Width / 100,
                Height = SystemInformation.VirtualScreen.Height / 100,
                Visible = true
        };
        }


        public void CreateLbl(string text)
        {
            TextBox txtboxNote = new TextBox()
            {
                Multiline = true,
                WordWrap = true,
                ReadOnly = true,
                Size = new Size(panel1.ClientSize.Width, panel1.ClientSize.Height / 5),
                Text = text,
                Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top),
                Location = new Point(0, j),
                Font = new Font(Font.Name, 8, FontStyle.Regular),
                BackColor = Color.White  
        };
            txtboxNote.DoubleClick += new EventHandler(TextBoxDoubleClicked);
            j += panel1.ClientSize.Width / 3;
            panel1.Controls.Add(txtboxNote);

            txtboxList.Add(txtboxNote);
        }

        private void TextBoxDoubleClicked(object sender, EventArgs e)
        {
            //creating changed textbox
            TextBox doubleClickedTextBox = (TextBox)sender; 
            DialogText f = new DialogText();
            f.textBoxNote.Text = doubleClickedTextBox.Text;
            f.textBoxNote.SelectionStart = f.textBoxNote.TextLength+1;
            f.ShowDialog();

            if (f.textBoxNote.TextLength == 0)
            {
                txtboxList.Remove(doubleClickedTextBox);
                panel1.Controls.Clear();
                j = 0;
               foreach (TextBox txtbox in txtboxList)
                {
                    txtbox.Location = new Point(3, j);
                    j += Convert.ToInt32(panel3.Size.Width * 0.26);
                    panel1.Controls.Add(txtbox);
                }
                
            }
            else doubleClickedTextBox.Text = f.textBoxNote.Text;
            f.Dispose();
            
        }

        //создание заметки    
        private void Button1_Click(object sender, EventArgs e)
        {
            DialogText f = new DialogText() {
                Height = SystemInformation.VirtualScreen.Height / 2,
                Width = SystemInformation.VirtualScreen.Width / 2,
                StartPosition = FormStartPosition.CenterScreen,
            };
            f.ShowDialog();
            if (f.textBoxNote.Text != "") CreateLbl(f.textBoxNote.Text);
        }

        //обработка нажатия checkbox
        private void PressCheckBox(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            if (checkbox.Checked)
            {
                //изменение checkbox
                checkbox.Enabled = false;
                checkbox.Font = new Font(checkbox.Font, FontStyle.Strikeout);
               
                chkboxList.Remove(checkbox);
                chkboxList.Add(checkbox);

                positionChkBox = 5;
                panel2.Controls.Clear();
               foreach (CheckBox checkboxlst in chkboxList)
                {
                    checkboxlst.Location = new Point(0, positionChkBox);
                    positionChkBox += Convert.ToInt32(panel2.ClientSize.Width * 0.15);
                    checkboxlst.Size = new Size(panel2.ClientSize.Height, Convert.ToInt32(panel2.ClientSize.Width * 0.085));
                    panel2.Controls.Add(checkboxlst);
                    checkboxlst.Show();
                }
            }
        }

        //создане checkbox
        private void CreateCheckBox()
        {
            CheckBox chckbox = new CheckBox()
            {
                Size = new Size(panel2.ClientSize.Width, Convert.ToInt32(panel2.ClientSize.Height * 0.020)),
                Location = new Point(0, positionChkBox)
            };
            chckbox.Click += new EventHandler(PressCheckBox);

            TextBox txtbox = new TextBox()
            {
                Size = new Size(Convert.ToInt32(panel2.ClientSize.Width * 0.80), Convert.ToInt32(panel2.ClientSize.Width * 0.09)),
                Location = new Point(Convert.ToInt32(panel2.ClientSize.Width * 0.1), positionChkBox)
            };
            txtbox.KeyPress += new KeyPressEventHandler(textBoxForChkbox_Click);
            positionChkBox += Convert.ToInt32(panel2.ClientSize.Height * 0.09);
            panel2.Controls.Add(txtbox);
            txtbox.Show();
            chkbox = chckbox;
            panel2.Controls.Add(chckbox);
            chckbox.Show();
            chkboxList.Add(chckbox);
            txtbox.Focus();
            txtBoxCheckBox = txtbox;
           
        }

        //кнопка создания checkbox
        private void Button2_Click(object sender, EventArgs e)
        {
            CreateCheckBox();
        }

        //выбор даты
        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        //обработка textbox для checkbox, вписывание данных
        private void textBoxForChkbox_Click(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtBoxCheckBox.Text == "")
                {
                    txtBoxCheckBox.Dispose();
                    chkbox.Dispose();
                    positionChkBox -= 22;
                    chkboxList.Remove(chkbox);
                }

                else
                {
                    chkbox.Text = txtBoxCheckBox.Text.ToString();
                  
                    txtBoxCheckBox.Dispose(); //уничтожение обьекта
                    CreateCheckBox();
                }
            }

            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                MessageBox.Show("Нажат Escape");
            }
        }

        //код для напоминаний
        private void button3_Click(object sender, EventArgs e)
        {
            ReminderAdd reminder = new ReminderAdd()
            { 
                Width = SystemInformation.VirtualScreen.Width / 3,
                Height = SystemInformation.VirtualScreen.Height / 2,
                StartPosition = FormStartPosition.CenterScreen,
            };
            reminder.ShowDialog();
            if (reminder.textBoxReminder.Text != "")
            {
                timeRemind.Add(reminder.timePicker.Value.ToShortTimeString());
                textRemind.Add(reminder.textBoxReminder.Text.ToString());
                dateRemind.Add(reminder.datePicker.Value.ToShortDateString());
                CheckTimer();
                buttonShowReminders.Enabled = true;
                //if ((panel3.Size.Height > panel3.Size.Height * 0.25) && (panel3.Size.Width > panel3.Size.Height * 0.25))
                CreateRemindCard(dateRemind[dateRemind.Count - 1], timeRemind[timeRemind.Count - 1], textRemind[textRemind.Count - 1]);
            }
        }

        //создание карты напоминания
        void CreateRemindCard(string date, string time, string text)
        {
          
            TextBox txtbox = new TextBox()
            {
                Multiline = true,
                Text = "Время: " + time + "Текст: " + text,
                ReadOnly = true,
                Size = new Size(Convert.ToInt32(panel3.Size.Height * 0.22), Convert.ToInt32(panel3.Size.Width * 0.25)),
                Location = new Point(0, positionTextBoxRemind) 
            };
            positionTextBoxRemind += Convert.ToInt32(panel3.Size.Width * 0.25);
            panel3.Controls.Add(txtbox);
        }

        //проверка обьектов на наличие
        void CheckTimer()
        {
            if (timeRemind.Count == 0) { timer1.Stop(); buttonShowReminders.Enabled = false; }
            else timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckTimer();
            for (int i = 0; i < timeRemind.Count; i++)
            {
                
                if (timeRemind[i] == DateTime.Now.ToShortTimeString())
                {
                    NotificShow(10, textRemind[i]);
                    timeRemind.Remove(timeRemind[i]);
                    textRemind.Remove(textRemind[i]);
                    dateRemind.Remove(dateRemind[i]);
                    panel3.Controls.Clear();
                    int x = 0;
                    for (int k = 0; k < textRemind.Count; k++)
                    {
                        TextBox textbox = new TextBox()
                        {
                            Multiline = true,
                            Text = textRemind[k].ToString() + "\n" + timeRemind[k].ToString(),
                            Location = new Point(3, x),
                            Size = new Size(Convert.ToInt32(panel3.Size.Height * 0.91), Convert.ToInt32(panel3.Size.Width * 0.25)),
                        };

                        x += Convert.ToInt32(panel4.Size.Width * 0.26);
                        panel3.Controls.Add(textbox);
                    }
                    break;
                  
                }
            }
        }

        private void buttonShowReminders_Click(object sender, EventArgs e)
        {
            if (checkPressedButton)
            {
                groupBox4.Visible = true;
                panel4.Visible = true;
                int x = 0;
                panel4.Controls.Clear();
                for (int i = 0; i < textRemind.Count; i++)
                {
                    TextBox textbox = new TextBox()
                    {
                        Multiline = true,
                    Text = textRemind[i].ToString() + "\n" + timeRemind[i].ToString(),
                    Location = new Point(3, x),
                    Size = new Size(Convert.ToInt32(panel4.Size.Height * 0.91), Convert.ToInt32(panel4.Size.Width * 0.25)),
                };
                   
                    x += Convert.ToInt32(panel4.Size.Width * 0.26);
                    panel4.Controls.Add(textbox);
                }
                buttonShowReminders.Text = "Скрыть";
                checkPressedButton = false;
            }
            else
            {
                buttonShowReminders.Text = "Показать все";
                groupBox4.Visible = false;
                panel4.Visible = false;
                checkPressedButton = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

   
}
