using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseForm form = new ChooseForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Payroll form = new Payroll();
            form.ShowDialog();
        }
    }
}
