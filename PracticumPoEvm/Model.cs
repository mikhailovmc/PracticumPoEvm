using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PracticumPoEvm
{
    class Model
    {
        string connection = "Server=MSI\\SQLEXPRESS;Database=NPP;TrustServerCertificate=True;Trusted_Connection=True;";     //строка подключения
        SqlConnection sqlcon;                                                                                               //подключение

        string selectFromContract = "SELECT * FROM dbo.Договор";                                                            //запросы
        string selectFromCompany = "SELECT * FROM dbo.Организация";
        string selectFromDelivery = "SELECT * FROM dbo.Поставка";
        string selectFromEmployee = "SELECT * FROM dbo.Сотрудник";

        public int[] EmployeeKeys { get; set; }                                                                             //ключи
        public int[,] ContractKeys { get; set; }
        public int[,] DeliveryKeys { get; set; }
        public int[,] CompanyKeys { get; set; }

        public List<string> GetInfo(string tableName)                                                                       //получение всех строк таблицы
        {
            string expr = "SELECT * " + "FROM dbo." + tableName;
            List<string> result = new List<string>();
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand(expr, sqlcon);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                string str = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        str = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                            str += (reader.GetValue(i).ToString() + " ");
                        result.Add(str);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                result.Add(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return result;
        }

        public List<string> GetAdditionInfo()
        {
            string expr = "SELECT Ключ_поставки, НаименованиеОрганизации, ТипОборудования, КомментарийПользователя, ФИО, ДатаЗаключения " +
                          "FROM dbo.Сотрудник INNER JOIN dbo.Поставка JOIN dbo.Договор ON (Поставка.НомерДоговора = Договор.НомерДоговора) " +
                          "ON (Поставка.КодСотрудника = Сотрудник.КодСотрудника) ORDER BY Поставка.Ключ_Поставки ASC";
            List<string> result = new List<string>();
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand(expr, sqlcon);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                string str = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        str = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                            str += (reader.GetValue(i).ToString() + " ");
                        result.Add(str);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                result.Add(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return result;
        }

        public string GetKeys()                                                                                             //получение всех ключей
        {
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();

                SqlCommand sqlcommand = new SqlCommand(selectFromEmployee, sqlcon);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                List<int> empkeys = new List<int>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empkeys.Add(reader.GetInt32(0));
                    }
                }
                EmployeeKeys = empkeys.ToArray();
                reader.Close();

                sqlcommand = new SqlCommand(selectFromContract, sqlcon);
                reader = sqlcommand.ExecuteReader();
                empkeys = new List<int>();
                List<int> conkeys = new List<int>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empkeys.Add(reader.GetInt32(3));
                        conkeys.Add(reader.GetInt32(0));
                    }
                }
                ContractKeys = new int[conkeys.Count, 2];
                for (int i = 0; i < conkeys.Count; i++)
                {
                    ContractKeys[i, 0] = conkeys[i];
                    ContractKeys[i, 1] = empkeys[i];
                }
                reader.Close();

                sqlcommand = new SqlCommand(selectFromDelivery, sqlcon);
                reader = sqlcommand.ExecuteReader();
                empkeys = new List<int>();
                conkeys = new List<int>();
                List<int> devkeys = new List<int>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empkeys.Add(reader.GetInt32(3));
                        conkeys.Add(reader.GetInt32(0));
                        devkeys.Add(reader.GetInt32(4));
                    }
                }
                DeliveryKeys = new int[devkeys.Count, 3];
                for (int i = 0; i < devkeys.Count; i++)
                {
                    DeliveryKeys[i, 0] = devkeys[i];
                    DeliveryKeys[i, 1] = conkeys[i];
                    DeliveryKeys[i, 2] = empkeys[i];
                }
                reader.Close();

                sqlcommand = new SqlCommand(selectFromCompany, sqlcon);
                reader = sqlcommand.ExecuteReader();
                empkeys = new List<int>();
                conkeys = new List<int>();
                devkeys = new List<int>();
                List<int> comkeys = new List<int>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empkeys.Add(reader.GetInt32(7));
                        conkeys.Add(reader.GetInt32(6));
                        devkeys.Add(reader.GetInt32(8));
                        comkeys.Add(reader.GetInt32(9));
                    }
                }
                CompanyKeys = new int[comkeys.Count, 4];
                for (int i = 0; i < comkeys.Count; i++)
                {
                    CompanyKeys[i, 0] = comkeys[i];
                    CompanyKeys[i, 1] = devkeys[i];
                    CompanyKeys[i, 2] = conkeys[i];
                    CompanyKeys[i, 3] = empkeys[i];
                }
                reader.Close();

                return "";
            }
            catch (SqlException ex)
            {
                return "" + ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
        }

        public string SetKeys(int[] empKeys, int[,] conKeys, int[,] devKeys, int[,] comKeys)                                //установка всех ключей в таблицу
        {
            string result = "";
            List<object> columns = new List<object>();
            List<object> values = new List<object>();
            columns.Add("КодСотрудника");
            for (int i = 0; i < empKeys.Length; i++)
            {
                values.Add(empKeys[i]);
                result += EditInfo("Сотрудник", columns, values);
                values.RemoveAt(0);
            }
            columns.Add("НомерДоговора");
            for (int i = 0; i < conKeys.Length / 2; i++)
            {
                values.Add(conKeys[i, 1]);
                values.Add(conKeys[i, 0]);
                result += EditInfo("Договор", columns, values);
                values.RemoveAt(1);
                values.RemoveAt(0);
            }
            columns.Add("Ключ_поставки");
            for (int i = 0; i < devKeys.Length / 3; i++)
            {
                values.Add(devKeys[i, 2]);
                values.Add(devKeys[i, 1]);
                values.Add(devKeys[i, 0]);
                result += EditInfo("Поставка", columns, values);
                values.RemoveAt(2);
                values.RemoveAt(1);
                values.RemoveAt(0);
            }
            columns.Add("Ключ_организации");
            for (int i = 0; i < comKeys.Length / 4; i++)
            {
                values.Add(comKeys[i, 3]);
                values.Add(comKeys[i, 2]);
                values.Add(comKeys[i, 1]);
                values.Add(comKeys[i, 0]);
                result += EditInfo("Организация", columns, values);
            }
            return result;
        }

        public List<object> GetRow(string tableName, string idName, int num)                                                //получение одной строки таблицы
        {
            string expr = "SELECT * " + "FROM dbo." + tableName + " WHERE " + idName + " = " + num;
            List<object> result = new List<object>();
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand(expr, sqlcon);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result.Add(reader.GetValue(i));
                        }
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                result.Add(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return result;
        }

        public string EditInfo(string tableName, List<object> columns, List<object> values)                                 //обновление одной строки таблицы
        {
            string result = "";
            string expr = "UPDATE " + "dbo." + tableName + " SET ";
            for (int i = 1; i < columns.Count - 1; i++)
                expr += columns[i].ToString() + " = " + values[i].ToString() + ", ";
            expr += columns[columns.Count - 1].ToString() + " = " + values[columns.Count - 1].ToString();
            expr += " WHERE " + columns[0] + " = " + values[0];
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand(expr, sqlcon);
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return result;
        }

        public string AddInfo(string tableName, List<object> columns, List<object> values)                                  //добавление одной строки в таблицу
        {
            string result = "";
            string expr = "INSERT INTO " + "dbo." + tableName + " (";
            for (int i = 0; i < columns.Count - 1; i++)
                expr += columns[i].ToString() + ", ";
            expr += columns[columns.Count - 1].ToString() + ") ";
            expr += "VALUES (";
            for (int i = 0; i < values.Count - 1; i++)
                expr += values[i].ToString() + ", ";
            expr += values[values.Count - 1].ToString() + ");";
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand(expr, sqlcon);
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return result;
        }

        public string DeleteInfo(string tableName, string column, int key)                                                  //удаление одной строки таблицы
        {
            string result = "";
            string expr = "DELETE FROM dbo." + tableName + " WHERE " + column + " = " + key;
            sqlcon = new SqlConnection(connection);
            try
            {
                sqlcon.Open();
                SqlCommand sqlcommand = new SqlCommand(expr, sqlcon);
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return result;
        }
    }
}
