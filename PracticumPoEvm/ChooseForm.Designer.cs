
namespace PracticumPoEvm
{
    partial class ChooseForm
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
            this.toContractButton = new System.Windows.Forms.Button();
            this.toCompanyButton = new System.Windows.Forms.Button();
            this.toDeliveryButton = new System.Windows.Forms.Button();
            this.toEmployeeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toContractButton
            // 
            this.toContractButton.Location = new System.Drawing.Point(12, 44);
            this.toContractButton.Name = "toContractButton";
            this.toContractButton.Size = new System.Drawing.Size(136, 54);
            this.toContractButton.TabIndex = 0;
            this.toContractButton.Text = "Договор";
            this.toContractButton.UseVisualStyleBackColor = true;
            this.toContractButton.Click += new System.EventHandler(this.toContractButton_Click);
            // 
            // toCompanyButton
            // 
            this.toCompanyButton.Location = new System.Drawing.Point(155, 43);
            this.toCompanyButton.Name = "toCompanyButton";
            this.toCompanyButton.Size = new System.Drawing.Size(138, 54);
            this.toCompanyButton.TabIndex = 1;
            this.toCompanyButton.Text = "Организация";
            this.toCompanyButton.UseVisualStyleBackColor = true;
            this.toCompanyButton.Click += new System.EventHandler(this.toCompanyButton_Click);
            // 
            // toDeliveryButton
            // 
            this.toDeliveryButton.Location = new System.Drawing.Point(12, 159);
            this.toDeliveryButton.Name = "toDeliveryButton";
            this.toDeliveryButton.Size = new System.Drawing.Size(136, 54);
            this.toDeliveryButton.TabIndex = 2;
            this.toDeliveryButton.Text = "Поставка";
            this.toDeliveryButton.UseVisualStyleBackColor = true;
            this.toDeliveryButton.Click += new System.EventHandler(this.toDeliveryButton_Click);
            // 
            // toEmployeeButton
            // 
            this.toEmployeeButton.Location = new System.Drawing.Point(155, 159);
            this.toEmployeeButton.Name = "toEmployeeButton";
            this.toEmployeeButton.Size = new System.Drawing.Size(136, 54);
            this.toEmployeeButton.TabIndex = 3;
            this.toEmployeeButton.Text = "Сотрудник";
            this.toEmployeeButton.UseVisualStyleBackColor = true;
            this.toEmployeeButton.Click += new System.EventHandler(this.toEmployeeButton_Click);
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 274);
            this.Controls.Add(this.toEmployeeButton);
            this.Controls.Add(this.toDeliveryButton);
            this.Controls.Add(this.toCompanyButton);
            this.Controls.Add(this.toContractButton);
            this.Name = "ChooseForm";
            this.Text = "ChooseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toContractButton;
        private System.Windows.Forms.Button toCompanyButton;
        private System.Windows.Forms.Button toDeliveryButton;
        private System.Windows.Forms.Button toEmployeeButton;
    }
}