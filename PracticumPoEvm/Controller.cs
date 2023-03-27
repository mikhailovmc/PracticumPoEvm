using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace PracticumPoEvm
{
    static class Controller
    {
        public static string exmessage = "";

        public static int[] EmployeeKeys { get; set; }
        public static int[,] ContractKeys { get; set; }
        public static int[,] DeliveryKeys { get; set; }
        public static int[,] CompanyKeys { get; set; }

        public static string DeleteWhiteSpace(string str)
        {
            int start = 0, count = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == ' ' && j + 1 < str.Length)
                {
                    while ((j + 1 < str.Length) && (str[j + 1] == ' '))
                    {
                        start = j - count;
                        count++;
                        j++;
                    }
                    if (count != 0)
                    {
                        str = str.Remove(start, count);
                        j = start;
                        count = 0;
                    }
                }
            }
            return str;
        }

        public static List<string> RefreshContractInfo()
        {
            Model model = new Model();
            GetKeys();
            List<string> result = model.GetInfo("Договор");
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = DeleteWhiteSpace(result[i]);
            }
            return result;
        }

        public static List<string> RefreshCompanyInfo()
        {
            Model model = new Model();
            GetKeys();
            List<string> result = model.GetInfo("Организация");
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = DeleteWhiteSpace(result[i]);
            }
            return result;
        }

        public static List<string> RefreshDeliveryInfo()
        {
            Model model = new Model();
            GetKeys();
            List<string> result = model.GetInfo("Поставка");
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = DeleteWhiteSpace(result[i]);
            }
            return result;
        }

        public static List<string> RefreshEmployeeInfo()
        {
            Model model = new Model();
            GetKeys();
            List<string> result = model.GetInfo("Сотрудник");
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = DeleteWhiteSpace(result[i]);
            }
            return result;
        }

        public static List<string> RefreshAdditionInfo()
        {
            Model model = new Model();
            List<string> result = model.GetAdditionInfo();
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = DeleteWhiteSpace(result[i]);
            }
            return result;
        }

        public static List<string> PayRoll(string month, string year)
        {
            List<string> result = new List<string>();
            if (month != "" && year != "")
            {
                if (CheckMonth(month))
                {
                    Model model = new Model();
                    GetKeys();
                    List<string> employeeList = model.GetInfo("Сотрудник");
                    List<string> employeeWithPremiumList = new List<string>();
                    for (int i = 0; i < ContractKeys.Length / 2; i++)
                    {
                        string premiumEmployee = "";
                        List<object> contract = model.GetRow("Договор", "НомерДоговора", ContractKeys[i, 0]);
                        string date = contract[contract.Count - 2].ToString().Split(' ')[0];
                        string[] condate = date.Split(".");
                        if (condate[1] == month && condate[2] == year)
                        {
                            premiumEmployee += ContractKeys[i, 1];
                            if (employeeWithPremiumList.Contains(premiumEmployee))
                                employeeWithPremiumList.Remove(premiumEmployee);
                            employeeWithPremiumList.Add(premiumEmployee);
                        }
                    }
                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        int sum = 0;
                        employeeList[i] = DeleteWhiteSpace(employeeList[i]);
                        string[] employee = employeeList[i].Split(' ');
                        result.Add("");
                        result[i] += employee[5] + " ";                         //фио
                        result[i] += employee[1] + " ";                                          //зарплата
                        sum += int.Parse(employee[1]);
                        for (int j = 0; j < employeeWithPremiumList.Count; j++)
                            if (employee[0] == employeeWithPremiumList[j])
                            {
                                result[i] += employee[2] + " ";                                  //премия
                                sum += int.Parse(employee[2]);
                            }
                        float incomeTax = (float)sum / 100 * 12;
                        result[i] += incomeTax + " ";
                        float pensionTax = (float)sum / 100 * 1;
                        result[i] += pensionTax + " ";
                        sum -= (int)(incomeTax + pensionTax);
                        result[i] += sum + " ";
                        result[i] += employee[4];
                    }
                }
                else result.Add("Ошибка: введены неправильные данные");
            }
            else result.Add("Ошибка: данные не введены");
            return result;
        }

        public static void GetKeys()
        {
            Model model = new Model();
            exmessage = model.GetKeys();
            EmployeeKeys = model.EmployeeKeys;
            ContractKeys = model.ContractKeys;
            DeliveryKeys = model.DeliveryKeys;
            CompanyKeys = model.CompanyKeys;
        }

        public static void UpdateKeys(int table, int key, int value)
        {
            Model m = new Model();
            m.GetKeys();
            switch (table)
            {
                case 0:                            //код сотрудника в договоре
                    {
                        Model model = new Model();
                        List<object> columns = new List<object>();
                        List<object> values = new List<object>();
                        for (int j = 0; j < CompanyKeys.Length / 4; j++)
                            if (CompanyKeys[j, 3] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("НомерДоговора");
                                columns.Add("КодСотрудника");
                                values.Add(CompanyKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Организация", columns, values);
                            }
                        for (int j = 0; j < DeliveryKeys.Length / 3; j++)
                            if (DeliveryKeys[j, 2] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_поставки");
                                columns.Add("КодСотрудника");
                                values.Add(DeliveryKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Поставка", columns, values);
                            }
                        break;
                    }
                case 1:                            //код сотрудника в поставке
                    {
                        Model model = new Model();
                        List<object> columns = new List<object>();
                        List<object> values = new List<object>();
                        for (int j = 0; j < CompanyKeys.Length / 4; j++)
                            if (CompanyKeys[j, 3] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_организации");
                                columns.Add("КодСотрудника");
                                values.Add(CompanyKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Организация", columns, values);
                            }
                        for (int j = 0; j < DeliveryKeys.Length / 3; j++)
                            if (DeliveryKeys[j, 2] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_поставки");
                                columns.Add("КодСотрудника");
                                values.Add(DeliveryKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Поставка", columns, values);
                            }
                        for (int j = 0; j < ContractKeys.Length / 2; j++)
                            if (ContractKeys[j, 1] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("НомерДоговора");
                                columns.Add("КодСотрудника");
                                values.Add(CompanyKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Организация", columns, values);
                            }
                        break;
                    }
                case 2:                            //номер договора в поставке
                    {
                        Model model = new Model();
                        List<object> columns = new List<object>();
                        List<object> values = new List<object>();
                        for (int j = 0; j < CompanyKeys.Length / 4; j++)
                            if (CompanyKeys[j, 2] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_организации");
                                columns.Add("НомерДоговора");
                                values.Add(CompanyKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Организация", columns, values);
                            }
                        for (int j = 0; j < DeliveryKeys.Length / 3; j++)
                            if (DeliveryKeys[j, 2] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_поставки");
                                columns.Add("НомерДоговора");
                                values.Add(DeliveryKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Поставка", columns, values);
                            }
                        break;
                    }
                case 3:                            //код сотрудника в организации 
                    {
                        int i = 0;
                        while (CompanyKeys[i, 0] != key && i < CompanyKeys.Length / 4)
                            i++;
                        if (i < CompanyKeys.Length / 4)
                        {
                            Model model = new Model();
                            List<object> columns = new List<object>();
                            List<object> values = new List<object>();
                            for (int j = 0; j < CompanyKeys.Length / 4; j++)
                                if (CompanyKeys[j, 3] == key)
                                {
                                    columns.Clear(); values.Clear();
                                    columns.Add("Ключ_организации");
                                    columns.Add("КодСотрудника");
                                    values.Add(CompanyKeys[j, 0] + 1);
                                    values.Add(value);
                                    exmessage = model.EditInfo("Организация", columns, values);
                                }
                            for (int j = 0; j < DeliveryKeys.Length / 3; j++)
                                if (DeliveryKeys[j, 2] == key)
                                {
                                    columns.Clear(); values.Clear();
                                    columns.Add("Ключ_поставки");
                                    columns.Add("КодСотрудника");
                                    values.Add(DeliveryKeys[j, 0] + 1);
                                    values.Add(value);
                                    exmessage = model.EditInfo("Поставка", columns, values);
                                }
                            for (int j = 0; j < ContractKeys.Length / 2; j++)
                                if (ContractKeys[j, 1] == key)
                                {
                                    columns.Clear(); values.Clear();
                                    columns.Add("НомерДоговора");
                                    columns.Add("КодСотрудника");
                                    values.Add(CompanyKeys[j, 0] + 1);
                                    values.Add(value);
                                    exmessage = model.EditInfo("Организация", columns, values);
                                }
                        }
                        else exmessage = "Ошибка: несуществующий номер";
                        break;
                    }
                case 4:                            //номер договора в органзации
                    {
                        Model model = new Model();
                        List<object> columns = new List<object>();
                        List<object> values = new List<object>();
                        for (int j = 0; j < CompanyKeys.Length / 4; j++)
                            if (CompanyKeys[j, 2] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_организации");
                                columns.Add("НомерДоговора");
                                values.Add(CompanyKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Организация", columns, values);
                            }
                        for (int j = 0; j < DeliveryKeys.Length / 3; j++)
                            if (DeliveryKeys[j, 2] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_поставки");
                                columns.Add("НомерДоговора");
                                values.Add(DeliveryKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Поставка", columns, values);
                            }
                        break;
                    }
                case 5:                            //ключ поставки в организации
                    {
                        Model model = new Model();
                        List<object> columns = new List<object>();
                        List<object> values = new List<object>();
                        for (int j = 0; j < CompanyKeys.Length / 4; j++)
                            if (CompanyKeys[j, 1] == key)
                            {
                                columns.Clear(); values.Clear();
                                columns.Add("Ключ_организации");
                                columns.Add("Ключ_поставки");
                                values.Add(CompanyKeys[j, 0] + 1);
                                values.Add(value);
                                exmessage = model.EditInfo("Организация", columns, values);
                            }
                        break;
                    }
                default:
                    {
                        exmessage += "Ошибка: не существующая таблица";
                        break;
                    }
            }
        }

        public static void AddKeys(int table, int[] keys)
        {
            Model m = new Model();
            m.GetKeys();
            switch (table)
            {
                case 0:                            //добавление сотрудника
                    {
                        int[] empKeys = new int[EmployeeKeys.Length];
                        for (int i = 0; i < EmployeeKeys.Length; i++)
                            empKeys[i] = EmployeeKeys[i];
                        EmployeeKeys = new int[empKeys.Length + 1];
                        for (int i = 0; i < empKeys.Length; i++)
                            EmployeeKeys[i] = empKeys[i];
                        EmployeeKeys[empKeys.Length] = keys[0];
                        break;
                    }
                case 1:                            //добавление договора
                    {
                        int[,] conKeys = new int[ContractKeys.Length / 2, 2];
                        for (int i = 0; i < ContractKeys.Length / 2; i++)
                        {
                            conKeys[i, 0] = ContractKeys[i, 0];
                            conKeys[i, 1] = ContractKeys[i, 1];
                        }
                        ContractKeys = new int[ContractKeys.Length / 2 + 1, 2];
                        for (int i = 0; i < conKeys.Length / 2; i++)
                        {
                            ContractKeys[i, 0] = conKeys[i, 0];
                            ContractKeys[i, 1] = conKeys[i, 1];
                        }
                        ContractKeys[conKeys.Length / 2, 0] = keys[1];
                        ContractKeys[conKeys.Length / 2, 1] = keys[0];
                        break;
                    }
                case 2:                            //добавление поставки
                    {
                        int[,] devKeys = new int[DeliveryKeys.Length / 3, 3];
                        for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                        {
                            devKeys[i, 0] = DeliveryKeys[i, 0];
                            devKeys[i, 1] = DeliveryKeys[i, 1];
                            devKeys[i, 2] = DeliveryKeys[i, 2];
                        }
                        DeliveryKeys = new int[DeliveryKeys.Length / 3 + 1, 3];
                        for (int i = 0; i < devKeys.Length / 3; i++)
                        {
                            DeliveryKeys[i, 0] = devKeys[i, 0];
                            DeliveryKeys[i, 1] = devKeys[i, 1];
                            DeliveryKeys[i, 2] = devKeys[i, 2];
                        }
                        DeliveryKeys[DeliveryKeys.Length / 3 - 1, 0] = keys[2];
                        DeliveryKeys[DeliveryKeys.Length / 3 - 1, 1] = keys[1];
                        DeliveryKeys[DeliveryKeys.Length / 3 - 1, 2] = keys[0];
                        break;
                    }
                case 3:                            //добавление организации
                    {
                        int[,] comKeys = new int[CompanyKeys.Length / 4, 4];
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                        {
                            comKeys[i, 0] = CompanyKeys[i, 0];
                            comKeys[i, 1] = CompanyKeys[i, 1];
                            comKeys[i, 2] = CompanyKeys[i, 2];
                            comKeys[i, 3] = CompanyKeys[i, 3];
                        }
                        CompanyKeys = new int[CompanyKeys.Length / 4 + 1, 4];
                        for (int i = 0; i < comKeys.Length / 4; i++)
                        {
                            CompanyKeys[i, 0] = comKeys[i, 0];
                            CompanyKeys[i, 1] = comKeys[i, 1];
                            CompanyKeys[i, 2] = comKeys[i, 2];
                            CompanyKeys[i, 3] = comKeys[i, 3];
                        }
                        CompanyKeys[CompanyKeys.Length / 4 - 1, 0] = keys[3];
                        CompanyKeys[CompanyKeys.Length / 4 - 1, 1] = keys[2];
                        CompanyKeys[CompanyKeys.Length / 4 - 1, 2] = keys[1];
                        CompanyKeys[CompanyKeys.Length / 4 - 1, 3] = keys[0];
                        break;
                    }
            }
        }

        public static void DeleteKeys(int table, int key)
        {
            Model m = new Model();
            m.GetKeys();
            switch (table)
            {
                case 0:                            //удаление сотрудника
                    {
                        int[] empKeys = new int[EmployeeKeys.Length - 1];
                        int j = 0;
                        for (int i = 0; i < EmployeeKeys.Length; i++)
                        {
                            if (EmployeeKeys[i] != key)
                            {
                                empKeys[j] = EmployeeKeys[i];
                            }
                            else j--;
                            j++;
                        }
                        int count = 0;
                        for (int i = 0; i < ContractKeys.Length / 2; i++)
                            if (ContractKeys[i, 1] == key)
                                count++;
                        int[,] conKeys = new int[ContractKeys.Length / 2 - count, 2];
                        j = 0;
                        for (int i = 0; i < ContractKeys.Length / 2; i++)
                        {
                            if (ContractKeys[i, 1] != key)
                            {
                                conKeys[j, 0] = ContractKeys[i, 0];
                                conKeys[j, 1] = ContractKeys[i, 1];
                            }
                            else j--;
                            j++;
                        }
                        ContractKeys = new int[conKeys.Length / 2, 2];
                        for (int i = 0; i < conKeys.Length / 2; i++)
                        {
                            ContractKeys[i, 0] = conKeys[i, 0];
                            ContractKeys[i, 1] = conKeys[i, 1];
                        }
                        count = 0;
                        for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                            if (DeliveryKeys[i, 2] == key)
                                count++;
                        int[,] devKeys = new int[DeliveryKeys.Length / 3 - count, 3];
                        j = 0;
                        for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                        {
                            if (DeliveryKeys[i, 2] != key)
                            {
                                devKeys[j, 0] = DeliveryKeys[i, 0];
                                devKeys[j, 1] = DeliveryKeys[i, 1];
                                devKeys[j, 2] = DeliveryKeys[i, 2];
                            }
                            else j--;
                            j++;
                        }
                        DeliveryKeys = new int[devKeys.Length / 3, 3];
                        for (int i = 0; i < devKeys.Length / 3; i++)
                        {
                            DeliveryKeys[i, 0] = devKeys[i, 0];
                            DeliveryKeys[i, 1] = devKeys[i, 1];
                            DeliveryKeys[i, 2] = devKeys[i, 2];
                        }
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                            if (CompanyKeys[i, 3] == key)
                                count++;
                        int[,] comKeys = new int[CompanyKeys.Length / 4 - count, 4];
                        j = 0;
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                        {
                            if (CompanyKeys[i, 3] != key)
                            {
                                comKeys[j, 0] = CompanyKeys[i, 0];
                                comKeys[j, 1] = CompanyKeys[i, 1];
                                comKeys[j, 2] = CompanyKeys[i, 2];
                                comKeys[j, 3] = CompanyKeys[i, 3];
                            }
                            else j--;
                            j++;
                        }
                        CompanyKeys = new int[comKeys.Length / 4, 4];
                        for (int i = 0; i < comKeys.Length / 4; i++)
                        {
                            CompanyKeys[i, 0] = comKeys[i, 0];
                            CompanyKeys[i, 1] = comKeys[i, 1];
                            CompanyKeys[i, 2] = comKeys[i, 2];
                            CompanyKeys[i, 3] = comKeys[i, 3];
                        }
                        break;
                    }
                case 1:                            //удаление договора
                    {
                        int[,] conKeys = new int[ContractKeys.Length / 2 - 1, 2];
                        int j = 0;
                        for (int i = 0; i < ContractKeys.Length / 2; i++)
                        {
                            if (ContractKeys[i, 0] != key)
                            {
                                conKeys[j, 0] = ContractKeys[i, 0];
                                conKeys[j, 1] = ContractKeys[i, 1];
                            }
                            else j--;
                            j++;
                        }
                        ContractKeys = new int[conKeys.Length / 2, 3];
                        for (int i = 0; i < conKeys.Length / 2; i++)
                        {
                            ContractKeys[i, 0] = conKeys[i, 0];
                            ContractKeys[i, 1] = conKeys[i, 1];
                        }
                        int count = 0;
                        for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                            if (DeliveryKeys[i, 1] == key)
                                count++;
                        int[,] devKeys = new int[DeliveryKeys.Length / 3 - count, 3];
                        j = 0;
                        for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                        {
                            if (DeliveryKeys[i, 1] != key)
                            {
                                devKeys[j, 0] = DeliveryKeys[i, 0];
                                devKeys[j, 1] = DeliveryKeys[i, 1];
                                devKeys[j, 2] = DeliveryKeys[i, 2];
                            }
                            else j--;
                            j++;
                        }
                        DeliveryKeys = new int[devKeys.Length / 3, 3];
                        for (int i = 0; i < devKeys.Length / 3; i++)
                        {
                            DeliveryKeys[i, 0] = devKeys[i, 0];
                            DeliveryKeys[i, 1] = devKeys[i, 1];
                            DeliveryKeys[i, 2] = devKeys[i, 2];
                        }
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                            if (CompanyKeys[i, 2] == key)
                                count++;
                        int[,] comKeys = new int[CompanyKeys.Length / 4 - count, 4];
                        j = 0;
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                        {
                            if (CompanyKeys[i, 2] != key)
                            {
                                comKeys[j, 0] = CompanyKeys[i, 0];
                                comKeys[j, 1] = CompanyKeys[i, 1];
                                comKeys[j, 2] = CompanyKeys[i, 2];
                                comKeys[j, 3] = CompanyKeys[i, 3];
                            }
                            else j--;
                            j++;
                        }
                        CompanyKeys = new int[comKeys.Length / 4, 4];
                        for (int i = 0; i < comKeys.Length / 4; i++)
                        {
                            CompanyKeys[i, 0] = comKeys[i, 0];
                            CompanyKeys[i, 1] = comKeys[i, 1];
                            CompanyKeys[i, 2] = comKeys[i, 2];
                            CompanyKeys[i, 3] = comKeys[i, 3];
                        }
                        break;
                    }
                case 2:                            //удаление поставки
                    {
                        int[,] devKeys = new int[DeliveryKeys.Length / 3 - 1, 3];
                        int j = 0;
                        for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                        {
                            if (DeliveryKeys[i, 0] != key)
                            {
                                devKeys[j, 0] = DeliveryKeys[i, 0];
                                devKeys[j, 1] = DeliveryKeys[i, 1];
                                devKeys[j, 2] = DeliveryKeys[i, 2];
                            }
                            else j--;
                            j++;
                        }
                        DeliveryKeys = new int[devKeys.Length / 3, 3];
                        for (int i = 0; i < devKeys.Length / 3; i++)
                        {
                            DeliveryKeys[i, 0] = devKeys[i, 0];
                            DeliveryKeys[i, 1] = devKeys[i, 1];
                            DeliveryKeys[i, 2] = devKeys[i, 2];
                        }
                        int count = 0;
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                            if (CompanyKeys[i, 1] == key)
                                count++;
                        int[,] comKeys = new int[CompanyKeys.Length / 4 - count, 4];
                        j = 0;
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                        {
                            if (CompanyKeys[i, 1] != key)
                            {
                                comKeys[j, 0] = CompanyKeys[i, 0];
                                comKeys[j, 1] = CompanyKeys[i, 1];
                                comKeys[j, 2] = CompanyKeys[i, 2];
                                comKeys[j, 3] = CompanyKeys[i, 3];
                            }
                            else j--;
                            j++;
                        }
                        CompanyKeys = new int[comKeys.Length / 4, 4];
                        for (int i = 0; i < comKeys.Length / 4; i++)
                        {
                            CompanyKeys[i, 0] = comKeys[i, 0];
                            CompanyKeys[i, 1] = comKeys[i, 1];
                            CompanyKeys[i, 2] = comKeys[i, 2];
                            CompanyKeys[i, 3] = comKeys[i, 3];
                        }
                        break;
                    }
                case 3:                            //удаление организации
                    {
                        int[,] comKeys = new int[CompanyKeys.Length / 4 - 1, 4];
                        int j = 0;
                        for (int i = 0; i < CompanyKeys.Length / 4; i++)
                        {
                            if (CompanyKeys[i, 0] != key)
                            {
                                comKeys[j, 0] = CompanyKeys[i, 0];
                                comKeys[j, 1] = CompanyKeys[i, 1];
                                comKeys[j, 2] = CompanyKeys[i, 2];
                                comKeys[j, 3] = CompanyKeys[i, 3];
                            }
                            else j--;
                            j++;
                        }
                        CompanyKeys = new int[comKeys.Length / 4, 4];
                        for (int i = 0; i < comKeys.Length / 4; i++)
                        {
                            CompanyKeys[i, 0] = comKeys[i, 0];
                            CompanyKeys[i, 1] = comKeys[i, 1];
                            CompanyKeys[i, 2] = comKeys[i, 2];
                            CompanyKeys[i, 3] = comKeys[i, 3];
                        }
                        break;
                    }
            }
        }

        public static bool EditContractInfo(string contractId, string companyName, string date, string employeeId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(contractId))
            {
                int i = 0;
                int conId = int.Parse(contractId);
                while (i < ContractKeys.Length / 2 && ContractKeys[i, 0] != conId)
                    i++;
                if (i < ContractKeys.Length / 2)
                {
                    Model model = new Model();
                    //model.GetKeys();
                    List<object> source = model.GetRow("Договор", "НомерДоговора", conId);
                    if (companyName == "")
                        companyName = source[1].ToString();
                    if (date == "")
                        date = source[2].ToString();
                    if (employeeId == "")
                        employeeId = source[3].ToString();
                    else
                    {
                        if (CheckNumber(employeeId))
                        {
                            int empId = int.Parse(employeeId);
                            int count = 0;
                            for (int k = 0; k < EmployeeKeys.Length; k++)
                                if (EmployeeKeys[k] == empId)
                                    count++;
                            if (count > 0)
                            {
                                int oldvalue = int.Parse(source[3].ToString());                 
                                UpdateKeys(0, oldvalue, empId);
                            }
                            else employeeId = source[3].ToString();
                        }
                        else employeeId = source[3].ToString();
                    }
                    if (CheckChar(companyName) && CheckDate(date) && CheckNumber(employeeId))    
                    {
                        int empId = int.Parse(employeeId);
                        DateTime datetime;
                        DateTime.TryParse(date, out datetime);
                        List<object> data = new List<object>();
                        data.Add(conId);
                        data.Add("\'" + companyName + "\'");
                        data.Add("\'" + datetime.Month + '.' + datetime.Day + '.' + datetime.Year + "\'");
                        data.Add(empId);
                        List<object> columns = new List<object>();
                        columns.Add("НомерДоговора");
                        columns.Add("НаименованиеОрганизации");
                        columns.Add("ДатаЗаключения");
                        columns.Add("КодСотрудника");
                        exmessage = model.EditInfo("Договор", columns, data);
                    }
                    else exmessage = "Неправильно набраны данные!";
                }
                else exmessage = "Несуществующий номер!";
            }
            else exmessage = "Неправильно набранный номер!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool EditCompanyInfo(string country, string city, string address, string phone, string email, string website,
                                           string contractId, string employeeId, string deliveryId, string companyId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(companyId))
            {
                int i = 0;
                int comId = int.Parse(companyId);
                while (i < CompanyKeys.Length / 4 && CompanyKeys[i, 0] != comId)
                    i++;
                if (i < CompanyKeys.Length / 4)
                {
                    Model model = new Model();
                    model.GetKeys();
                    List<object> source = model.GetRow("Организация", "Ключ_организации", comId);
                    if (country == "") country = source[0].ToString();
                    if (city == "") city = source[1].ToString();
                    if (address == "") address = source[2].ToString();
                    if (phone == "") phone = source[3].ToString();
                    if (email == "") email = source[4].ToString();
                    if (website == "") website = source[5].ToString();
                    if (contractId == "") contractId = source[6].ToString();
                    else
                    {
                        if (CheckNumber(contractId))
                        {
                            int conId = int.Parse(contractId);
                            int count = 0;
                            for (int k = 0; k < ContractKeys.Length / 2; k++)
                                if (ContractKeys[k, 0] == conId)
                                    count++;
                            if (count > 0)
                            {
                                int oldvalue = int.Parse(source[6].ToString());                  
                                UpdateKeys(4, oldvalue, conId);
                            }
                            else employeeId = source[6].ToString();
                        }
                        else contractId = source[6].ToString();
                    }
                    if (employeeId == "") employeeId = source[7].ToString();
                    else
                    {
                        if (CheckNumber(employeeId))
                        {
                            int empId = int.Parse(employeeId);
                            int count = 0;
                            for (int k = 0; k < EmployeeKeys.Length; k++)
                                if (EmployeeKeys[k] == empId)
                                    count++;
                            if (count > 0)
                            {
                                int oldvalue = int.Parse(source[7].ToString());                  
                                UpdateKeys(3, oldvalue, empId);
                            }
                            else employeeId = source[7].ToString();
                        }
                        else employeeId = source[7].ToString();
                    }
                    if (deliveryId == "") deliveryId = source[8].ToString();
                    else
                    {
                        if (CheckNumber(deliveryId))
                        {
                            int devId = int.Parse(deliveryId);
                            int count = 0;
                            for (int k = 0; k < DeliveryKeys.Length / 3; k++)
                                if (DeliveryKeys[k, 0] == devId)
                                    count++;
                            if (count > 0)
                            {
                                int oldvalue = int.Parse(source[8].ToString());                  
                                UpdateKeys(5, oldvalue, devId);
                            }
                            else deliveryId = source[8].ToString();
                        }
                        else deliveryId = source[8].ToString();
                    }
                    if (CheckNumber(country) && CheckChar(city) && CheckPhone(phone) && CheckMail(email) && CheckWebSite(website))
                    {
                        int countryId = int.Parse(country);
                        int conId = int.Parse(contractId);
                        int empId = int.Parse(contractId);
                        int devId = int.Parse(deliveryId);
                        List<object> data = new List<object>();
                        data.Add(comId);
                        data.Add(countryId);
                        data.Add("\'" + city + "\'");
                        data.Add("\'" + address + "\'");
                        data.Add("\'" + phone + "\'");
                        data.Add("\'" + email + "\'");
                        data.Add("\'" + website + "\'");
                        data.Add(conId);
                        data.Add(empId);
                        data.Add(devId);
                        List<object> columns = new List<object>();
                        columns.Add("Ключ_организации");
                        columns.Add("КодСтраны");
                        columns.Add("Город");
                        columns.Add("Адрес");
                        columns.Add("Телефон");
                        columns.Add("E_MAIL");
                        columns.Add("АдресWEB_Сайта");
                        columns.Add("НомерДоговора");
                        columns.Add("КодСотрудника");
                        columns.Add("Ключ_поставки");
                        exmessage = model.EditInfo("Организация", columns, data);
                    }
                    else exmessage = "Неправильно набраны данные";
                }
                else exmessage = "Несуществующий ключ";
            }
            else exmessage = "Неправильно набранный ключ";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool EditDeliveryInfo(string contractId, string type, string comment, string employeeId, string deliveryId)
        {
            //проверка уникальности номера договора
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(deliveryId))
            {
                int i = 0;
                int devId = int.Parse(deliveryId);
                while (i < DeliveryKeys.Length / 3 && DeliveryKeys[i, 0] != devId)
                    i++;
                if (i < DeliveryKeys.Length / 3)
                {
                    Model model = new Model();
                    model.GetKeys(); 
                    List<object> source = model.GetRow("Поставка", "Ключ_поставки", devId);
                    if (type == "") type = source[1].ToString();
                    object com;
                    if (comment == "") com = "null";
                    else com = "\'" + comment + "\'";
                    if (contractId == "") contractId = source[0].ToString();
                    else
                    {
                        if (CheckNumber(contractId))
                        {
                            int conId = int.Parse(contractId);
                            int count = 0;
                            for (int k = 0; k < ContractKeys.Length / 2; k++)
                                if (ContractKeys[k, 0] == conId)
                                    count++;
                            if (count == 0)
                            {
                                int oldvalue = int.Parse(source[0].ToString());                
                                UpdateKeys(2, oldvalue, conId);
                            }
                            else employeeId = source[0].ToString();
                        }
                        else contractId = source[0].ToString();
                    }
                    if (employeeId == "") employeeId = source[3].ToString();
                    else
                    {
                        if (CheckNumber(employeeId))
                        {
                            int empId = int.Parse(employeeId);
                            int count = 0;
                            for (int k = 0; k < EmployeeKeys.Length; k++)
                                if (EmployeeKeys[k] == empId)
                                    count++;
                            if (count > 0)
                            {
                                int oldvalue = int.Parse(source[3].ToString());
                                UpdateKeys(1, oldvalue, empId);
                            }
                            else employeeId = source[3].ToString();
                        }
                        else employeeId = source[3].ToString();
                    }
                    if (CheckType(type))
                    {
                        int conId = int.Parse(contractId);
                        int empId = int.Parse(contractId);
                        devId = int.Parse(deliveryId);
                        List<object> data = new List<object>();
                        data.Add(devId);
                        data.Add(conId);
                        data.Add("\'" + type + "\'");
                        data.Add(com);
                        data.Add(empId);
                        List<object> columns = new List<object>();
                        columns.Add("Ключ_поставки");
                        columns.Add("НомерДоговора");
                        columns.Add("ТипОборудования");
                        columns.Add("КомментарийПользователя");
                        columns.Add("КодСотрудника");
                        exmessage = model.EditInfo("Поставка", columns, data);
                    }
                    else exmessage = "Неправильно набраны данные";
                }
                else exmessage = "Несуществующий ключ";
            }
            else exmessage = "Неправильно набранный ключ";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool EditEmployeeInfo(string employeeId, string salary, string premium, string month, string departmentId, string fio, string post)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(employeeId))
            {
                int i = 0;
                int empId = int.Parse(employeeId);
                while (i < EmployeeKeys.Length && EmployeeKeys[i] != empId)
                    i++;
                if (i < EmployeeKeys.Length)
                {
                    Model model = new Model();
                    model.GetKeys();
                    List<object> source = model.GetRow("Сотрудник", "КодСотрудника", empId);
                    if (salary == "") salary = source[1].ToString();
                    if (premium == "") premium = source[2].ToString();
                    if (month == "") month = source[3].ToString();
                    if (departmentId == "") departmentId = source[4].ToString();
                    if (fio == "") fio = source[5].ToString();
                    if (post == "") post = source[6].ToString();
                    if (CheckNumber(employeeId) && CheckNumber(salary) && CheckNumber(premium) && CheckMonth(month) && CheckNumber(departmentId) && CheckChar(fio) && CheckChar(post))
                    {
                        int sal = int.Parse(salary);
                        int pre = int.Parse(premium);
                        int mon = int.Parse(month);
                        int dep = int.Parse(departmentId);
                        List<object> data = new List<object>();
                        data.Add(empId); 
                        data.Add(sal); 
                        data.Add(pre); 
                        data.Add(mon); 
                        data.Add(dep); 
                        data.Add("\'" + fio + "\'");
                        data.Add("\'" + post + "\'");
                        List<object> columns = new List<object>();
                        columns.Add("КодСотрудника");
                        columns.Add("Оклад");
                        columns.Add("Премия");
                        columns.Add("Месяц"); 
                        columns.Add("КодОтделения"); 
                        columns.Add("ФИО"); 
                        columns.Add("Должность");
                        exmessage = model.EditInfo("Сотрудник", columns, data);
                    }
                    else exmessage = "Неправильно набраны данные!";
                }
                else exmessage = "Несуществующий код!";
            }
            else exmessage = "Неправильно набранный код!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool AddContractInfo(string contractId, string companyName, string date, string employeeId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(contractId))
            {
                int ic = 0;
                int conId = int.Parse(contractId);
                for (int i = 0; i < ContractKeys.Length / 2; i++)
                    if (ContractKeys[i, 0] == conId)
                        ic++;
                if (ic == 0)
                {
                    Model model = new Model();
                    model.GetKeys();
                    if (companyName != "" && date != "" && employeeId != "")
                    {
                        if (CheckNumber(employeeId))
                        {
                            int empId = int.Parse(employeeId);
                            int count = 0;
                            for (int k = 0; k < EmployeeKeys.Length; k++)
                                if (EmployeeKeys[k] == empId)
                                    count++;
                            if (count > 0)
                            {
                                if (CheckChar(companyName) && CheckDate(date) && CheckNumber(employeeId))
                                {
                                    int[] keys = new int[2] { empId, conId };
                                    AddKeys(1, keys);
                                    DateTime datetime;
                                    DateTime.TryParse(date, out datetime);
                                    List<object> data = new List<object>();
                                    data.Add(conId);
                                    data.Add("\'" + companyName + "\'");
                                    data.Add("\'" + datetime.Month + '.' + datetime.Day + '.' + datetime.Year + "\'");
                                    data.Add(empId);
                                    List<object> columns = new List<object>();
                                    columns.Add("НомерДоговора");
                                    columns.Add("НаименованиеОрганизации");
                                    columns.Add("ДатаЗаключения");
                                    columns.Add("КодСотрудника");
                                    exmessage = model.AddInfo("Договор", columns, data);
                                }
                                else exmessage = "Неправильно набраны данные!";
                            }
                            else exmessage = "Несуществующий код сотрудника";
                        }
                        else exmessage = "Неправильно набран код сотрудника";
                    }
                    else exmessage = "Не все поля заполнены";
                }
                else exmessage = "Не уникальный номер!";
            }
            else exmessage = "Неправильно набранный номер!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool AddCompanyInfo(string country, string city, string address, string phone, string email, string website,
                                           string contractId, string employeeId, string deliveryId, string companyId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(companyId))
            {
                int ic = 0;
                int comId = int.Parse(companyId);
                for (int i = 0; i < CompanyKeys.Length / 4; i++)
                    if (CompanyKeys[i, 0] == comId)
                        ic++;
                if (ic == 0)
                {
                    if (country != "" && city != "" && address != "" && phone != "" && email != "" && website != "" && contractId != "" && employeeId != "" && deliveryId != "")
                    {
                        if (CheckNumber(contractId))
                        {
                            int conId = int.Parse(contractId);
                            int count = 0;
                            for (int k = 0; k < ContractKeys.Length / 2; k++)
                                if (ContractKeys[k, 0] == conId)
                                    count++;
                            if (count > 0)
                            {
                                if (CheckNumber(employeeId))
                                {
                                    int empId = int.Parse(employeeId);
                                    count = 0;
                                    for (int k = 0; k < EmployeeKeys.Length; k++)
                                        if (EmployeeKeys[k] == empId)
                                            count++;
                                    if (count > 0)
                                    {
                                        if (CheckNumber(deliveryId))
                                        {
                                            int devId = int.Parse(deliveryId);
                                            count = 0;
                                            for (int k = 0; k < DeliveryKeys.Length / 3; k++)
                                                if (DeliveryKeys[k, 0] == devId)
                                                    count++;
                                            if (count > 0)
                                            {
                                                if (CheckNumber(country) && CheckChar(city) && CheckPhone(phone) && CheckMail(email) && CheckWebSite(website))
                                                {
                                                    Model model = new Model();
                                                    model.GetKeys();
                                                    int[] keys = new int[4] { empId, conId, devId, comId};
                                                    AddKeys(3, keys);
                                                    int countryId = int.Parse(country);
                                                    List<object> data = new List<object>();
                                                    data.Add(countryId);
                                                    data.Add("\'" + city + "\'");
                                                    data.Add("\'" + address + "\'");
                                                    data.Add("\'" + phone + "\'");
                                                    data.Add("\'" + email + "\'");
                                                    data.Add("\'" + website + "\'");
                                                    data.Add(conId);
                                                    data.Add(empId);
                                                    data.Add(devId);
                                                    data.Add(comId);
                                                    List<object> columns = new List<object>();
                                                    columns.Add("КодСтраны");
                                                    columns.Add("Город");
                                                    columns.Add("Адрес");
                                                    columns.Add("Телефон");
                                                    columns.Add("E_MAIL");
                                                    columns.Add("АдресWEB_Сайта");
                                                    columns.Add("НомерДоговора");
                                                    columns.Add("КодСотрудника");
                                                    columns.Add("Ключ_поставки");
                                                    columns.Add("Ключ_организации");
                                                    exmessage = model.AddInfo("Организация", columns, data);
                                                }
                                                else exmessage = "Неправильно набраны данные";
                                            }
                                            else exmessage = "Несуществующий ключ поставки";
                                        }
                                        else exmessage = "Неправильно набран ключ поставки";
                                    }
                                    else exmessage = "Несуществующий код сотрудника";
                                }
                                else exmessage = "Неправильно набран код сотрудника";
                            }
                            else exmessage = "Несуществующий номер договора";
                        }
                        else exmessage = "Неправильно набран номер договора";
                    }
                    else exmessage = "Не все поля заполнены";
                }
                else exmessage = "Не уникальный ключ!";
            }
            else exmessage = "Неправильно набранный ключ!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool AddDeliveryInfo(string contractId, string type, string comment, string employeeId, string deliveryId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(deliveryId))
            {
                int ic = 0;
                int devId = int.Parse(deliveryId);
                for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                    if (DeliveryKeys[i, 0] == devId)
                        ic++;
                if (ic == 0)
                {
                    if (contractId != "" && type != "" && employeeId != "" && deliveryId != "")
                    {
                        if (CheckNumber(contractId))
                        {
                            ic = 0;
                            int conId = int.Parse(contractId);
                            for (int i = 0; i < ContractKeys.Length / 2; i++)
                                if (ContractKeys[i, 0] == conId)
                                    ic++;
                            for (int i = 0; i < DeliveryKeys.Length / 3; i++)
                                if (DeliveryKeys[i, 1] == conId)
                                    ic++;
                            if (ic == 1)
                            {
                                if (CheckNumber(employeeId))
                                {
                                    int empId = int.Parse(employeeId);
                                    int count = 0;
                                    for (int k = 0; k < EmployeeKeys.Length; k++)
                                        if (EmployeeKeys[k] == empId)
                                            count++;
                                    if (count > 0)
                                    {
                                        if (CheckType(type))
                                        {
                                            Model model = new Model();
                                            model.GetKeys();
                                            int[] keys = new int[3] { empId, conId, devId};
                                            AddKeys(2, keys);
                                            object com;
                                            if (comment == "") com = "null";
                                            else com = "\'" + comment + "\'";
                                            List<object> data = new List<object>();
                                            data.Add(conId);
                                            data.Add("\'" + type + "\'");
                                            data.Add(com);
                                            data.Add(empId);
                                            data.Add(devId);
                                            List<object> columns = new List<object>();
                                            columns.Add("НомерДоговора");
                                            columns.Add("ТипОборудования");
                                            columns.Add("КомментарийПользователя");
                                            columns.Add("КодСотрудника");
                                            columns.Add("Ключ_поставки");
                                            exmessage = model.AddInfo("Поставка", columns, data);
                                        }
                                        else exmessage = "Неправильно набраны данные";
                                    }
                                    else exmessage = "Несуществующий код сотрудника!";
                                }
                                else exmessage = "Неправильно набранный код сотрудника!";
                            }
                            else exmessage = "Не уникальный номер договора!";
                        }
                        else exmessage = "Неправильно набранный номер договора!";
                    }
                    else exmessage = "Не все поля заполнены";
                }
                else exmessage = "Не уникальный ключ!";
            }
            else exmessage = "Неправильно набранный ключ!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool AddEmployeeInfo(string employeeId, string salary, string premium, string month, string departmentId, string fio, string post)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(employeeId))
            {
                int ic = 0;
                int empId = int.Parse(employeeId);
                for (int i = 0; i < EmployeeKeys.Length; i++)
                    if (EmployeeKeys[i] == empId)
                        ic++;
                if (ic == 0)
                {
                    if (salary != "" && premium != "" && month != "" && departmentId != "" && fio != "" && post != "")
                    {
                        if (CheckNumber(employeeId) && CheckNumber(salary) && CheckNumber(premium) && CheckMonth(month) && CheckNumber(departmentId) && CheckChar(fio) && CheckChar(post))
                        {
                            Model model = new Model();
                            model.GetKeys();
                            int[] keys = new int[1] { empId};
                            AddKeys(0, keys);
                            int sal = int.Parse(salary);
                            int pre = int.Parse(premium);
                            int mon = int.Parse(month);
                            int dep = int.Parse(departmentId);
                            List<object> data = new List<object>();
                            data.Add(empId);
                            data.Add(sal);
                            data.Add(pre);
                            data.Add(mon);
                            data.Add(dep);
                            data.Add("\'" + fio + "\'");
                            data.Add("\'" + post + "\'");
                            List<object> columns = new List<object>();
                            columns.Add("КодСотрудника");
                            columns.Add("Оклад");
                            columns.Add("Премия");
                            columns.Add("Месяц");
                            columns.Add("КодОтделения");
                            columns.Add("ФИО");
                            columns.Add("Должность");
                            exmessage = model.AddInfo("Сотрудник", columns, data);
                        }
                        else exmessage = "Неправильно набраны данные!";
                    }
                    else exmessage = "Не все поля заполнены";
                }
                else exmessage = "Не уникальный код!";
            }
            else exmessage = "Неправильно набранный код!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool DeleteContractInfo(string contractId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(contractId))
            {
                int i = 0;
                int conId = int.Parse(contractId);
                while (i < ContractKeys.Length / 2 && ContractKeys[i, 0] != conId)
                    i++;
                if (i < ContractKeys.Length / 2)
                {
                    Model model = new Model();
                    string res = "";
                    for (int k = 0; k < CompanyKeys.Length / 4; k++)
                        if (CompanyKeys[k, 2] == conId)
                            res += model.DeleteInfo("Организация", "Ключ_организации", CompanyKeys[k, 0]);
                    for (int k = 0; k < DeliveryKeys.Length / 3; k++)
                        if (DeliveryKeys[k, 1] == conId)
                            res += model.DeleteInfo("Поставка", "Ключ_поставки", DeliveryKeys[k, 0]);
                    if (res == "")
                    {
                        res = model.DeleteInfo("Договор", "НомерДоговора", conId);
                    }
                    else exmessage = res;
                }
                else exmessage = "Несуществующий номер договора!";
            }
            else exmessage = "Неправильно набранный номер!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool DeleteCompanyInfo(string companyId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(companyId))
            {
                int i = 0;
                int comId = int.Parse(companyId);
                while (i < CompanyKeys.Length / 4 && CompanyKeys[i, 0] != comId)
                    i++;
                if (i < CompanyKeys.Length / 4)
                {
                    Model model = new Model();
                    string res = model.DeleteInfo("Организация", "Ключ_организации", comId);
                    if (res == "") DeleteKeys(3, comId);
                    else exmessage = res;
                }
                else exmessage = "Несуществующий номер договора!";
            }
            else exmessage = "Неправильно набранный номер!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool DeleteDeliveryInfo(string deliveryId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(deliveryId))
            {
                int i = 0;
                int devId = int.Parse(deliveryId);
                while (i < DeliveryKeys.Length / 3 && DeliveryKeys[i, 0] != devId)
                    i++;
                if (i < DeliveryKeys.Length / 3)
                {
                    Model model = new Model();
                    string res = "";
                    for (int k = 0; k < CompanyKeys.Length / 4; k++)
                        if (CompanyKeys[k, 1] == devId)
                            res += model.DeleteInfo("Организация", "Ключ_организации", CompanyKeys[k, 0]);
                    if (res == "")
                    {
                        res = model.DeleteInfo("Поставка", "Ключ_поставки", devId);
                    }
                    else exmessage = res;

                }
                else exmessage = "Несуществующий номер договора!";
            }
            else exmessage = "Неправильно набранный номер!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool DeleteEmployeeInfo(string employeeId)
        {
            bool result = true;
            Model m = new Model();
            m.GetKeys();
            if (CheckNumber(employeeId))
            {
                int i = 0;
                int empId = int.Parse(employeeId);
                while (i < EmployeeKeys.Length && EmployeeKeys[i] != empId)
                    i++;
                if (i < EmployeeKeys.Length)
                {
                    Model model = new Model();
                    string res = "";
                    for (int k = 0; k < CompanyKeys.Length / 4; k++)
                        if (CompanyKeys[k, 3] == empId)
                            res += model.DeleteInfo("Организация", "Ключ_организации", CompanyKeys[k, 0]);
                    for (int k = 0; k < DeliveryKeys.Length / 3; k++)
                        if (DeliveryKeys[k, 2] == empId)
                            res += model.DeleteInfo("Поставка", "Ключ_поставки", DeliveryKeys[k, 0]);
                    for (int k = 0; k < ContractKeys.Length / 2; k++)
                        if (ContractKeys[k, 1] == empId)
                            res += model.DeleteInfo("Договор", "НомерДоговора", ContractKeys[k, 0]);
                    if (res == "")
                    {
                        res = model.DeleteInfo("Сотрудник", "КодСотрудника", empId);
                    }
                    else exmessage = res;
                }
                else exmessage = "Несуществующий код сотрудника!";
            }
            else exmessage = "Неправильно набранный код!";
            if (exmessage != "") result = false;
            return result;
        }

        public static bool CheckChar(string str)
        {
            bool result = true;
            int i = 0;
            while (i < str.Length && !char.IsDigit(str[i]))
                i++;
            if (i < str.Length) result = false;
            return result;
        }

        public static bool CheckNumber(string num)
        {
            int b = 0;
            return int.TryParse(num, out b) && b > -1;
        }

        public static bool CheckDate(string date)
        {
            DateTime dt = new DateTime();
            return DateTime.TryParse(date, out dt);
        }

        public static bool CheckPhone(string phone)
        {
            phone = DeleteWhiteSpace(phone);
            phone = phone.Trim();
            string pattern = @"^((8|\+7)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\-]{7,10}$";
            return Regex.IsMatch(phone, pattern);
        }

        public static bool CheckWebSite(string website)
        {
            website = DeleteWhiteSpace(website);
            website = website.Trim();
            string pattern = @".com|.ru";
            return Regex.IsMatch(website, pattern);
        }

        public static bool CheckMail(string email)
        {
            email = DeleteWhiteSpace(email);
            email = email.Trim();
            email = email.ToLower();
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool CheckType(string type)
        {
            type = DeleteWhiteSpace(type);
            type = type.Trim();
            return (type == "АЦП NM с AM1") || (type == "АЦП NM с AM2") || (type == "АЦП NM с U2") || (type == "АЦП NM без усилителя");
        }

        public static bool CheckMonth(string month)
        {
            int mon = 0;
            return int.TryParse(month, out mon) && (mon >= 0 && mon <= 12);
        }
    }
}
