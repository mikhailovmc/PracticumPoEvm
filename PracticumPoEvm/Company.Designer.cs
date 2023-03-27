
namespace PracticumPoEvm
{
    partial class Company
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
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cityBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.countryCodBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.webSiteBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.contractIdBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.employeeIdBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.deliveryIdBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.companyIdBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(716, 191);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(163, 34);
            this.editButton.TabIndex = 33;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(822, 374);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(123, 45);
            this.deleteButton.TabIndex = 32;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(633, 374);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 45);
            this.addButton.TabIndex = 31;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(822, 231);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 137);
            this.textBox3.TabIndex = 30;
            this.textBox3.Text = "Для удаления записи, укажите ключ организации (остальное указывать необязательно)" +
    ", затем нажмите кнопку ниже";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(633, 231);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 137);
            this.textBox2.TabIndex = 29;
            this.textBox2.Text = "Для добавления новой записи, заполните поля выше и нажмите кнопку ниже";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(595, 127);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(163, 23);
            this.phoneBox.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Телефон:";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(595, 98);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(163, 23);
            this.addressBox.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Адрес:";
            // 
            // cityBox
            // 
            this.cityBox.Location = new System.Drawing.Point(595, 69);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(163, 23);
            this.cityBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Город:";
            // 
            // countryCodBox
            // 
            this.countryCodBox.Location = new System.Drawing.Point(595, 40);
            this.countryCodBox.Name = "countryCodBox";
            this.countryCodBox.Size = new System.Drawing.Size(163, 23);
            this.countryCodBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(516, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Код страны:";
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
            this.textBox1.Size = new System.Drawing.Size(129, 23);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "таблица Организация";
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
            this.label7.Location = new System.Drawing.Point(516, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "email:";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(595, 157);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(163, 23);
            this.emailBox.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(764, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "web-сайт:";
            // 
            // webSiteBox
            // 
            this.webSiteBox.Location = new System.Drawing.Point(886, 40);
            this.webSiteBox.Name = "webSiteBox";
            this.webSiteBox.Size = new System.Drawing.Size(163, 23);
            this.webSiteBox.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(765, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 38;
            this.label9.Text = "№ Договора:";
            // 
            // contractIdBox
            // 
            this.contractIdBox.Location = new System.Drawing.Point(886, 69);
            this.contractIdBox.Name = "contractIdBox";
            this.contractIdBox.Size = new System.Drawing.Size(163, 23);
            this.contractIdBox.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(764, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 15);
            this.label10.TabIndex = 40;
            this.label10.Text = "Код сотрудника:";
            // 
            // employeeIdBox
            // 
            this.employeeIdBox.Location = new System.Drawing.Point(886, 99);
            this.employeeIdBox.Name = "employeeIdBox";
            this.employeeIdBox.Size = new System.Drawing.Size(163, 23);
            this.employeeIdBox.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(765, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 15);
            this.label11.TabIndex = 42;
            this.label11.Text = "Ключ поставки:";
            // 
            // deliveryIdBox
            // 
            this.deliveryIdBox.Location = new System.Drawing.Point(886, 128);
            this.deliveryIdBox.Name = "deliveryIdBox";
            this.deliveryIdBox.Size = new System.Drawing.Size(163, 23);
            this.deliveryIdBox.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(764, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 44;
            this.label12.Text = "Ключ организации:";
            // 
            // companyIdBox
            // 
            this.companyIdBox.Location = new System.Drawing.Point(886, 157);
            this.companyIdBox.Name = "companyIdBox";
            this.companyIdBox.Size = new System.Drawing.Size(163, 23);
            this.companyIdBox.TabIndex = 45;
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 450);
            this.Controls.Add(this.companyIdBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.deliveryIdBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.employeeIdBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.contractIdBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.webSiteBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countryCodBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Company";
            this.Text = "Company";
            this.Load += new System.EventHandler(this.Company_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cityBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox countryCodBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox webSiteBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox contractIdBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox employeeIdBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox deliveryIdBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox companyIdBox;
    }
}