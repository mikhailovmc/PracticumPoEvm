using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PracticumPoEvm
{
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            infoBox.Text = "";
            StreamWriter sw = null;
            string fname; 
            if (fileNameBox.Text != "")
            {
                fname = fileNameBox.Text + ".txt";
                sw = new StreamWriter(fname, false);
            }
            string month = monthBox.Text;
            string year = yearBox.Text;
            if (sw != null) sw.WriteLine("Ведомость за " + month + " месяц " + year + " года");
            List<string> info = Controller.PayRoll(month, year);
            string tableHeader = "Ф.И.О сотрудника";
            int length = tableHeader.Length;
            for (int i = 0; i < 25 - length; i++)
                tableHeader += ' ';
            tableHeader += "Оклад, руб.";
            length = tableHeader.Length;
            for (int i = 0; i < 45 - length; i++)
                tableHeader += ' ';
            tableHeader += "Премия, руб.";
            length = tableHeader.Length;
            for (int i = 0; i < 65 - length; i++)
                tableHeader += ' ';
            tableHeader += "Подоходный налог, руб.";
            length = tableHeader.Length;
            for (int i = 0; i < 95 - length; i++)
                tableHeader += ' ';
            tableHeader += "Пенсионный налог, руб.";
            length = tableHeader.Length;
            for (int i = 0; i < 125 - length; i++)
                tableHeader += ' ';
            tableHeader += "К выдаче, руб.";
            infoBox.Text += tableHeader;
            infoBox.Text += Environment.NewLine;
            if (sw != null) sw.WriteLine(tableHeader);
            List<string> print = new List<string>();
            int predpSum = 0;
            while (info.Count != 0)
            {
                string[] arr = info[0].Split(' ');
                string dep = arr[arr.Length - 1];
                List<string> remove = new List<string>();
                int depSum = 0;
                print.Add("Отдел " + dep);
                for (int i = 0; i < info.Count; i++)
                {
                    arr = info[i].Split(' ');
                    if (dep == arr[arr.Length - 1])
                    {
                        print.Add(info[i]);
                        depSum += int.Parse(arr[arr.Length - 2]);
                        remove.Add(info[i]);
                        //info.RemoveAt(i);
                    }
                }
                for (int i = 0; i < remove.Count; i++)
                {
                    info.Remove(remove[i]);
                }
                print.Add("Итого по отделу: " + depSum);
                predpSum += depSum;
            }
            print.Add("Итого по предприятию: " + predpSum);
            for (int i = 0; i < print.Count; i++)
            {
                if (print[i].Split(' ')[0] != "Отдел" && print[i].Split(' ')[0] != "Итого")
                {
                    string viewstr = "";
                    string[] viearr = print[i].Split(' ');
                    viewstr += viearr[0];
                    length = viewstr.Length;
                    for (int k = 0; k < 25 - length; k++)
                        viewstr += ' ';
                    viewstr += viearr[1];
                    length = viewstr.Length;
                    for (int k = 0; k < 45 - length; k++)
                        viewstr += ' ';
                    int premcount = 0;
                    if (viearr.Length == 7) viewstr += viearr[2];
                    else premcount = 1;
                    length = viewstr.Length;
                    for (int k = 0; k < 65 - length; k++)
                        viewstr += ' ';
                    viewstr += viearr[3 - premcount];
                    length = viewstr.Length;
                    for (int k = 0; k < 95 - length; k++)
                        viewstr += ' ';
                    viewstr += viearr[4 - premcount];
                    length = viewstr.Length;
                    for (int k = 0; k < 125 - length; k++)
                        viewstr += ' ';
                    viewstr += viearr[5 - premcount];
                    print[i] = viewstr;
                }    
                infoBox.Text += print[i];
                infoBox.Text += Environment.NewLine;
                if (sw != null) sw.WriteLine(print[i]);
            }
            if (sw != null) sw.Close();
        }
    }
}
