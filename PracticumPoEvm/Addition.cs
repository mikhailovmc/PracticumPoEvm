using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class Addition : Form
    {
        public Addition()
        {
            InitializeComponent();
        }

        private void RefreshInfo()
        {
            List<string> info = Controller.RefreshAdditionInfo();
            string tableHeader = "Ключ поставки";
            int length = tableHeader.Length;
            for (int i = 0; i < 16 - length; i++)
                tableHeader += ' ';
            tableHeader += "НаименованиеОрганизации";
            length = tableHeader.Length;
            for (int i = 0; i < 60 - length; i++)
                tableHeader += ' ';
            tableHeader += "Тип оборудования";
            length = tableHeader.Length;
            for (int i = 0; i < 85 - length; i++)
                tableHeader += ' ';
            tableHeader += "Комментарий";
            length = tableHeader.Length;
            for (int i = 0; i < 135 - length; i++)
                tableHeader += ' ';
            tableHeader += "Имя сотрудника";
            length = tableHeader.Length;
            for (int i = 0; i < 155 - length; i++)
                tableHeader += ' ';
            tableHeader += "Дата Заключения";
            infoBox.Text += tableHeader;
            infoBox.Text += Environment.NewLine;
            for (int i = 0; i < info.Count; i++)
            {
                string[] strarray = new string[20];
                strarray = info[i].Split(' ');
                string viewstr = "";
                viewstr += strarray[0];
                length = viewstr.Length;
                for (int k = 0; k < 16 - length; k++)
                    viewstr += ' ';
                int j = 1;
                while (strarray[j] != "АЦП")
                {
                    viewstr += strarray[j];
                    viewstr += ' ';
                    j++;
                }
                length = viewstr.Length;
                for (int k = 0; k < 60 - length; k++)
                    viewstr += ' ';
                for (int k = 0; k < 4; k++)
                {
                    viewstr += strarray[j];
                    viewstr += ' ';
                    j++;
                }
                length = viewstr.Length;
                for (int k = 0; k < 85 - length; k++)
                    viewstr += ' ';
                if (j != strarray.Length - 4)
                {
                    for (int k = j; k < strarray.Length - 4; k++)
                    {
                        viewstr += strarray[j];
                        viewstr += ' ';
                        j++;
                    }
                }
                length = viewstr.Length;
                for (int k = 0; k < 135 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[strarray.Length - 4];
                length = viewstr.Length;
                for (int k = 0; k < 155 - length; k++)
                    viewstr += ' ';
                viewstr += strarray[strarray.Length - 3];
                infoBox.Text += viewstr;
                infoBox.Text += Environment.NewLine;
            }
        }

        private void Addition_Load(object sender, EventArgs e)
        {
            RefreshInfo();
        }
    }
}
