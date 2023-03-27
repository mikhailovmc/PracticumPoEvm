using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void RefreshInfo()
        {
            infoBox.Text = "";
            List<string> info = Controller.RefreshEmployeeInfo();
            string tableHeader = "Код сотрудника";
            int length = tableHeader.Length;
            for (int i = 0; i < 16 - length; i++)
                tableHeader += ' ';
            tableHeader += "Оклад";
            length = tableHeader.Length;
            for (int i = 0; i < 23 - length; i++)
                tableHeader += ' ';
            tableHeader += "Премия";
            length = tableHeader.Length;
            for (int i = 0; i < 30 - length; i++)
                tableHeader += ' ';
            tableHeader += "Месяц";
            length = tableHeader.Length;
            for (int i = 0; i < 37 - length; i++)
                tableHeader += ' ';
            tableHeader += "Код отделения";
            length = tableHeader.Length;
            for (int i = 0; i < 52 - length; i++)
                tableHeader += ' ';
            tableHeader += "ФИО";
            length = tableHeader.Length;
            for (int i = 0; i < 65 - length; i++)
                tableHeader += ' ';
            tableHeader += "Должность";
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
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 23 - length; k++)
                    viewstr += ' ';
                j++;
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 30 - length; k++)
                    viewstr += ' ';
                j++;
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 37 - length; k++)
                    viewstr += ' ';
                j++;
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 52 - length; k++)
                    viewstr += ' ';
                j++;
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 65 - length; k++)
                    viewstr += ' ';
                j++;
                viewstr += strarray[j];
                infoBox.Text += viewstr;
                infoBox.Text += Environment.NewLine;
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string employeeId = employeeIdBox.Text;
            string salary = salaryBox.Text;
            string premium = premiumBox.Text;
            string month = monthBox.Text;
            string departmentId = departmentIdBox.Text;
            string fio = fioBox.Text;
            string post = postBox.Text;
            if (!Controller.EditEmployeeInfo(employeeId, salary, premium, month, departmentId, fio, post))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string employeeId = employeeIdBox.Text;
            string salary = salaryBox.Text;
            string premium = premiumBox.Text;
            string month = monthBox.Text;
            string departmentId = departmentIdBox.Text;
            string fio = fioBox.Text;
            string post = postBox.Text;
            if (!Controller.AddEmployeeInfo(employeeId, salary, premium, month, departmentId, fio, post))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string employeeId = employeeIdBox.Text;
            if (!Controller.DeleteEmployeeInfo(employeeId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }
    }
}
