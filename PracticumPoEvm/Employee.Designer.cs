
namespace PracticumPoEvm
{
    partial class Employee
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
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.monthBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.premiumBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.employeeIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.departmentIdBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fioBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.postBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(747, 156);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(163, 34);
            this.editButton.TabIndex = 33;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(871, 350);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(123, 45);
            this.deleteButton.TabIndex = 32;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(663, 350);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 45);
            this.addButton.TabIndex = 31;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(871, 207);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 137);
            this.textBox3.TabIndex = 30;
            this.textBox3.Text = "Для удаления записи, укажите код сотрудника (остальное указывать необязательно), " +
    "затем нажмите кнопку ниже";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(663, 207);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 137);
            this.textBox2.TabIndex = 29;
            this.textBox2.Text = "Для добавления новой записи, заполните поля выше и нажмите кнопку ниже";
            // 
            // monthBox
            // 
            this.monthBox.Location = new System.Drawing.Point(625, 127);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(163, 23);
            this.monthBox.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Месяц:";
            // 
            // premiumBox
            // 
            this.premiumBox.Location = new System.Drawing.Point(625, 98);
            this.premiumBox.Name = "premiumBox";
            this.premiumBox.Size = new System.Drawing.Size(163, 23);
            this.premiumBox.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Премия:";
            // 
            // salaryBox
            // 
            this.salaryBox.Location = new System.Drawing.Point(625, 69);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(163, 23);
            this.salaryBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Оклад:";
            // 
            // employeeIdBox
            // 
            this.employeeIdBox.Location = new System.Drawing.Point(625, 40);
            this.employeeIdBox.Name = "employeeIdBox";
            this.employeeIdBox.Size = new System.Drawing.Size(163, 23);
            this.employeeIdBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Код сотрудника:";
            // 
            // infoBox
            // 
            this.infoBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoBox.Location = new System.Drawing.Point(12, 40);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.infoBox.Size = new System.Drawing.Size(487, 399);
            this.infoBox.TabIndex = 20;
            this.infoBox.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(119, 23);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "таблица Сотрудник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Работа с данными:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Информация:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(795, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Код отделения:";
            // 
            // departmentIdBox
            // 
            this.departmentIdBox.Location = new System.Drawing.Point(891, 40);
            this.departmentIdBox.Name = "departmentIdBox";
            this.departmentIdBox.Size = new System.Drawing.Size(163, 23);
            this.departmentIdBox.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(795, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "ФИО:";
            // 
            // fioBox
            // 
            this.fioBox.Location = new System.Drawing.Point(891, 69);
            this.fioBox.Name = "fioBox";
            this.fioBox.Size = new System.Drawing.Size(163, 23);
            this.fioBox.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(795, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 38;
            this.label9.Text = "Должность:";
            // 
            // postBox
            // 
            this.postBox.Location = new System.Drawing.Point(891, 98);
            this.postBox.Name = "postBox";
            this.postBox.Size = new System.Drawing.Size(163, 23);
            this.postBox.TabIndex = 39;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 450);
            this.Controls.Add(this.postBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fioBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.departmentIdBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.monthBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.premiumBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.salaryBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.employeeIdBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Employee";
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Employee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox monthBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox premiumBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox salaryBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox employeeIdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox departmentIdBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fioBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox postBox;
    }
}