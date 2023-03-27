using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }

        private void RefreshInfo()
        {
            infoBox.Text = "";
            List<string> info = Controller.RefreshDeliveryInfo();
            string tableHeader = "Номер договора";
            int length = tableHeader.Length;
            for (int i = 0; i < 16 - length; i++)
                tableHeader += ' ';
            tableHeader += "Тип оборудования";
            length = tableHeader.Length;
            for (int i = 0; i < 40 - length; i++)
                tableHeader += ' ';
            tableHeader += "Комментарий пользователя";
            length = tableHeader.Length;
            for (int i = 0; i < 90 - length; i++)
                tableHeader += ' ';
            tableHeader += "Код сотрудника";
            length = tableHeader.Length;
            for (int i = 0; i < 106 - length; i++)
                tableHeader += ' ';
            tableHeader += "Ключ поставки";
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
                for (int k = 0; k < 4; k++)
                {
                    viewstr += strarray[j];
                    viewstr += ' ';
                    j++;
                }
                length = viewstr.Length;
                for (int k = 0; k < 40 - length; k++)
                    viewstr += ' ';
                if (j != strarray.Length - 3)
                {
                    for (int k = j; k < strarray.Length - 3; k++)
                    {
                        viewstr += strarray[j];
                        viewstr += ' ';
                        j++;
                    }
                }
                length = viewstr.Length;
                for (int k = 0; k < 90 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[j];
                length = viewstr.Length;
                for (int k = 0; k < 106 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[strarray.Length - 2];
                infoBox.Text += viewstr;
                infoBox.Text += Environment.NewLine;
            }
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string contractId = idBox.Text;
            string type = typeBox.Text;
            string comment = commentBox.Text;
            string employeeId = employeeIdBox.Text;
            string deliveryId = deliveryIdBox.Text;
            if (!Controller.EditDeliveryInfo(contractId, type, comment, employeeId, deliveryId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string contractId = idBox.Text;
            string type = typeBox.Text;
            string comment = commentBox.Text;
            string employeeId = employeeIdBox.Text;
            string deliveryId = deliveryIdBox.Text;
            if (!Controller.AddDeliveryInfo(contractId, type, comment, employeeId, deliveryId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string deliveryId = deliveryIdBox.Text;
            if (!Controller.DeleteDeliveryInfo(deliveryId))
            {
                MessageBox.Show(Controller.exmessage);
            }
            else RefreshInfo();
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Addition form = new Addition();
            form.Show();
        }
    }
}
