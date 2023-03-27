using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            InitializeComponent();
        }

        private void toContractButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Contract form = new Contract();
            form.Show();
        }

        private void toCompanyButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Company form = new Company();
            form.Show();
        }

        private void toDeliveryButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Delivery form = new Delivery();
            form.Show();
        }

        private void toEmployeeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Employee form = new Employee();
            form.Show();
        }
    }
}
