namespace Organaizer
{
    partial class DialogText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.addNoteBtn = new System.Windows.Forms.Button();
            this.buttonDelNote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(12, 41);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(265, 127);
            this.textBoxNote.TabIndex = 0;
            this.textBoxNote.TextChanged += new System.EventHandler(this.textBoxNote_TextChanged);
            // 
            // addNoteBtn
            // 
            this.addNoteBtn.Location = new System.Drawing.Point(12, 174);
            this.addNoteBtn.Name = "addNoteBtn";
            this.addNoteBtn.Size = new System.Drawing.Size(178, 35);
            this.addNoteBtn.TabIndex = 1;
            this.addNoteBtn.Text = "Добавить";
            this.addNoteBtn.UseVisualStyleBackColor = true;
            this.addNoteBtn.Click += new System.EventHandler(this.addNoteBtn_Click);
            // 
            // buttonDelNote
            // 
            this.buttonDelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelNote.Location = new System.Drawing.Point(202, 175);
            this.buttonDelNote.Name = "buttonDelNote";
            this.buttonDelNote.Size = new System.Drawing.Size(75, 34);
            this.buttonDelNote.TabIndex = 2;
            this.buttonDelNote.Text = "Удалить";
            this.buttonDelNote.UseVisualStyleBackColor = true;
            this.buttonDelNote.Click += new System.EventHandler(this.button1_Click);
            // 
            // DialogText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 221);
            this.Controls.Add(this.buttonDelNote);
            this.Controls.Add(this.addNoteBtn);
            this.Controls.Add(this.textBoxNote);
            this.Name = "DialogText";
            this.Text = "Введите текст";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox textBoxNote;
        public System.Windows.Forms.Button addNoteBtn;
        private System.Windows.Forms.Button buttonDelNote;
    }
}