using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class Company : Form
    {
        public Company()
        {
            InitializeComponent();
        }

        private void RefreshInfo()
        {
            infoBox.Text = "";
            List<string> info = Controller.RefreshCompanyInfo();
            string tableHeader = "Код страны";
            int length = tableHeader.Length;
            for (int i = 0; i < 11 - length; i++)
                tableHeader += ' ';
            tableHeader += "Город";
            length = tableHeader.Length;
            for (int i = 0; i < 30 - length; i++)
                tableHeader += ' ';
            tableHeader += "Адрес";
            length = tableHeader.Length;
            for (int i = 0; i < 60 - length; i++)
                tableHeader += ' ';
            tableHeader += "Телефон";
            length = tableHeader.Length;
            for (int i = 0; i < 80 - length; i++)
                tableHeader += ' ';
            tableHeader += "E-mail";
            length = tableHeader.Length;
            for (int i = 0; i < 100 - length; i++)
                tableHeader += ' ';
            tableHeader += "Web-сайт";
            length = tableHeader.Length;
            for (int i = 0; i < 114 - length; i++)
                tableHeader += ' ';
            tableHeader += "Номер договора";
            length = tableHeader.Length;
            for (int i = 0; i < 130 - length; i++)
                tableHeader += ' ';
            tableHeader += "Код сотрудника";
            length = tableHeader.Length;
            for (int i = 0; i < 146 - length; i++)
                tableHeader += ' ';
            tableHeader += "Ключ поставки";
            length = tableHeader.Length;
            for (int i = 0; i < 160 - length; i++)
                tableHeader += ' ';
            tableHeader += "Ключ организзации";
            infoBox.Text += tableHeader;
            infoBox.Text += Environment.NewLine;
            for (int i = 0; i < info.Count; i++)
            {
                string[] strarray = new string[15];
                strarray = info[i].Split(' ');
                string viewstr = "";
                viewstr += strarray[0];
                length = viewstr.Length;
                for (int k = 0; k < 11 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[1];
                length = viewstr.Length;
                for (int k = 0; k < 30 - length; k++)
                    viewstr += ' ';
                int j = 2;
                bool b = true;
                while (b)
                {
                    if (strarray[j].Length > 1)
                    {
                        if (char.IsDigit(strarray[j][0]) && strarray[j][1] == '(')
                            b = false;
                        else 
                        {
                            viewstr += strarray[j];
                            viewstr += ' ';
                            j++;
                        }
                    }
                    else
                    {
                        viewstr += strarray[j];
                        viewstr += ' ';
                        j++;
                    }
                }
                //viewstr += '\t';
                length = viewstr.Length;
                for (int k = 0; k < 60 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                j++;
                length = viewstr.Length;
                for (int k = 0; k < 80 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                j++;
                length = viewstr.Length;
                for (int k = 0; k < 100 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                j++;
                length = viewstr.Length;
                for (int k = 0; k < 114 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                j++;
                length = viewstr.Length;
                for (int k = 0; k < 130 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                j++;
                length = viewstr.Length;
                for (int k = 0; k < 146 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                j++;
                length = viewstr.Length;
                for (int k = 0; k < 160 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                infoBox.Text += viewstr;
                infoBox.Text += Environment.NewLine;
            }
        }


        private void Company_Load(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string country = countryCodBox.Text;
            string city = cityBox.Text;
            string address = addressBox.Text;
            string phone = phoneBox.Text;
            string email = emailBox.Text;
            string website = webSiteBox.Text;
            string contractId = contractIdBox.Text;
            string employeeId = employeeIdBox.Text;
            string deliveryId = deliveryIdBox.Text;
            string companyId = companyIdBox.Text;
            if (!Controller.EditCompanyInfo(country, city, address, phone, email, website, contractId, employeeId, deliveryId, companyId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string country = countryCodBox.Text;
            string city = cityBox.Text;
            string address = addressBox.Text;
            string phone = phoneBox.Text;
            string email = emailBox.Text;
            string website = webSiteBox.Text;
            string contractId = contractIdBox.Text;
            string employeeId = employeeIdBox.Text;
            string deliveryId = deliveryIdBox.Text;
            string companyId = companyIdBox.Text;
            if (!Controller.AddCompanyInfo(country, city, address, phone, email, website, contractId, employeeId, deliveryId, companyId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string companyId = companyIdBox.Text;
            if (!Controller.DeleteCompanyInfo(companyId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }
    }
}
