
namespace PracticumPoEvm
{
    partial class Payroll
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.monthBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.getButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(442, 42);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Ведомость выдачи заработной платы сотрудникам\r\nнаучно-производственного предприят" +
    "ия \"Новые аналитические системы\" за\r\n";
            // 
            // monthBox
            // 
            this.monthBox.Location = new System.Drawing.Point(463, 37);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(38, 23);
            this.monthBox.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(507, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(44, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "месяц";
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(557, 37);
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(56, 23);
            this.yearBox.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(619, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(33, 23);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "года";
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(670, 13);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(118, 42);
            this.getButton.TabIndex = 5;
            this.getButton.Text = "Получить";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // infoBox
            // 
            this.infoBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoBox.Location = new System.Drawing.Point(12, 66);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.infoBox.Size = new System.Drawing.Size(776, 372);
            this.infoBox.TabIndex = 6;
            this.infoBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Имф файла:";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(542, 8);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(110, 23);
            this.fileNameBox.TabIndex = 8;
            // 
            // Payroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.yearBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.monthBox);
            this.Controls.Add(this.textBox1);
            this.Name = "Payroll";
            this.Text = "Payroll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox monthBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNameBox;
    }
}