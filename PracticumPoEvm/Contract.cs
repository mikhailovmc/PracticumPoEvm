using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{

    public partial class Contract : Form
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void RefreshInfo()
        {
            infoBox.Text = "";
            List<string> info = Controller.RefreshContractInfo();
            string tableHeader = "Номер договора";
            int length = tableHeader.Length;
            for (int i = 0; i < 16 - length; i++)
                tableHeader += ' ';
            tableHeader += "Наименование организации";
            length = tableHeader.Length;
            for (int i = 0; i < 60 - length; i++)
                tableHeader += ' ';
            tableHeader += "Дата Заключения";
            length = tableHeader.Length;
            for (int i = 0; i < 80 - length; i++)
                tableHeader += ' ';
            tableHeader += "Код сотрудника";
            infoBox.Text += tableHeader;
            infoBox.Text += Environment.NewLine;
            for (int i = 0; i < info.Count; i++)
            {
                string[] strarray = new string[10];
                strarray = info[i].Split(' ');
                string viewstr = "";
                viewstr += strarray[0];
                length = viewstr.Length;
                for (int k = 0; k < 16 - length; k++)
                    viewstr += ' ';
                int j = 1;
                while (!char.IsDigit(strarray[j][0]))
                {
                    viewstr += strarray[j];
                    viewstr += ' ';
                    j++;
                }
                length = viewstr.Length;
                for (int k = 0; k < 60 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 80 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[strarray.Length - 2];
                infoBox.Text += viewstr;
                infoBox.Text += Environment.NewLine;
            }
        }

        private void Contract_Load(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string contractId = "", companyName = "", date = "", employeeId = "";
            contractId += idBox.Text;
            companyName += companyNameBox.Text;
            date += dateBox.Text;
            employeeId += employeeIdBox.Text;
            if (!Controller.EditContractInfo(contractId, companyName, date, employeeId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string contractId = "", companyName = "", date = "", employeeId = "";
            contractId += idBox.Text;
            companyName += companyNameBox.Text;
            date += dateBox.Text;
            employeeId += employeeIdBox.Text;
            if (!Controller.AddContractInfo(contractId, companyName, date, employeeId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string contractId = "";
            contractId += idBox.Text;
            if (!Controller.DeleteContractInfo(contractId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }
    }
}
