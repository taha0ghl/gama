using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace MyClass
{
    static class SqlServerClass
    {
        //_________________________________________________________________________
        const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\GAMABANK.MDF;Integrated Security=True";
        //_________________________________________________________________________
        public static bool Insert(string tableName, params object[] valuesData)
        {
            SqlConnection connection = new SqlConnection();
            bool i = true;
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    string s = "";
                    for (int j = 0; j < valuesData.Length; j++)
                    {
                        s += "@f" + j + ",";
                        cmd.Parameters.AddWithValue("@f" + j, valuesData[j]);
                    }
                    s = s.Remove(s.Length - 1);//hazf coma akhar
                    cmd.CommandText = string.Format("Insert Into {0} Values ({1})", tableName, s);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                i = false;
            }
            finally
            {
                connection.Close();
            }
            return i;
        }
        //_________________________________________________________________________
        public static double MaxValueColumn(string tableName, string columnName, string Condition = "")
        {
            SqlConnection connection = new SqlConnection();
            double d = 0;
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    if (Condition != "" && !Condition.ToUpper().Contains("WHERE"))
                        Condition = "Where(" + Condition + ")";
                    cmd.CommandText = string.Format("Select max({0}) From {1} {2}", columnName, tableName, Condition);
                    object o = cmd.ExecuteScalar();
                    if (o == null || o == DBNull.Value)
                        d = 0;
                    else
                        d = Convert.ToInt32(o);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                d = -1;
            }
            finally
            {
                connection.Close();
            }
            return d;
        }
        //_________________________________________________________________________
        public static void ShowQueryInDataGridView(DataGridView dgr, string selectQuery)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                {
                    DataTable table1 = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
                    da.Fill(table1);
                    dgr.DataSource = table1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        //_________________________________________________________________________
        public static bool Edit(string tableName, string Condition, params object[] FieldsValues)
        {
            SqlConnection connection = new SqlConnection();
            bool i = true;
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    string s = "";
                    if (Condition != "" && !Condition.ToUpper().Contains("WHERE"))
                        Condition = "Where(" + Condition + ")";
                    for (int j = 0; j < FieldsValues.Length; j += 2)
                    {
                        s += FieldsValues[j] + "=@f" + j + ",";
                        cmd.Parameters.AddWithValue("@f" + j, FieldsValues[j + 1]);
                    }
                    s = s.Remove(s.Length - 1);//hazf coma akhar
                    cmd.CommandText = string.Format("Update {0} Set {1} {2}", tableName, s, Condition);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                i = false;
            }
            finally
            {
                connection.Close();
            }
            return i;
        }
        //_________________________________________________________________________
        public static bool Delete(string tableName, string Condition = "")
        {
            SqlConnection connection = new SqlConnection();
            bool d = true;
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    if (Condition != "" && !Condition.ToUpper().Contains("WHERE"))
                        Condition = "Where(" + Condition + ")";
                    cmd.CommandText = string.Format("Delete From {0} {1}", tableName, Condition);
                    cmd.ExecuteNonQuery();
                    d = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                d = false;
            }
            finally
            {
                connection.Close();
            }
            return d;
        }
        //_________________________________________________________________________
        public static bool InsertWithFields(string tableName, params string[] fieldNamesANDValues)
        {
            bool output = false;

            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                //create names
                string names = "";
                string parameters = "";
                for (int i = 0; i < fieldNamesANDValues.Length; i += 2)
                {
                    names += fieldNamesANDValues[i] + ",";
                    parameters += "@" + "Field" + i + ",";
                    command.Parameters.AddWithValue("Field" + i, fieldNamesANDValues[i + 1].ToString());
                }
                names = names.Remove(names.Length - 1);//end (,) remove
                parameters = parameters.Remove(parameters.Length - 1);//end (,) remove
                command.CommandText = "insert into " + tableName + " (" + names + ") values (" + parameters + ")";
                command.Connection = connection;
                command.ExecuteNonQuery();
                output = true;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }
        //_________________________________________________________________________
        public static ArrayList Search1Record_ArrayList(string tableName, string Condition = "")
        {
            ArrayList a = null;
            SqlConnection sq = new SqlConnection();
            try
            {
                sq.ConnectionString = ConnectionString;
                sq.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sq;
                if (Condition == "")
                {
                    cmd.CommandText = "SELECT * FROM " + tableName;
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM " + tableName + " WHERE (" + Condition + ")";
                }

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = new ArrayList();
                    for (int i = 0; i < dr.FieldCount; i++)
                        a.Add(dr[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                a = null;
            }
            finally
            {
                sq.Close();
            }
            if (a != null && a.Count == 0)
                a = null;
            return a;
        }
        //_________________________________________________________________________
        public static bool Update(string tableName, string[] fieldNames, string[] fieldValues, string criteria)
        {
            bool output = false;
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                string parameters = "";
                //create parameters
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    parameters += fieldNames[i] + "=@" + "Field" + i + ",";
                    command.Parameters.AddWithValue("Field" + i, fieldValues[i].ToString());
                }
                parameters = parameters.Remove(parameters.Length - 1);//end (,) remove
                command.CommandText = "update " + tableName + " set " + parameters + " where (" + criteria + ")";
                command.Connection = connection;
                command.ExecuteNonQuery();
                output = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }
            finally
            {
                connection.Close();
            }
            return output;
        }
        //_________________________________________________________________________
        public static int RowCount(string table_or_join_table, string fieldCount, string condition = "")
        {
            if (condition != "")
            {
                condition = " Where(" + condition + ")";
            }

            int r = 0;
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                SqlCommand sq = new SqlCommand("Select Count(" + fieldCount + ") From " + table_or_join_table + condition);
                sq.Connection = connection;
                object o = sq.ExecuteScalar();
                if (o == null)
                {
                    r = 0;
                }
                else
                {
                    r = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                r = 0;
            }
            finally
            {
                connection.Close();
            }
            return r;
        }
        //_________________________________________________________________________
        public static ArrayList GetAllField_ArrayList(string tblName, string fieldName, string condition = "")
        {
            ArrayList output = new ArrayList();
            SqlConnection connection = new SqlConnection();

            if (condition != string.Empty)
            {
                condition = "Where( " + condition + " )";
            }

            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                {
                    SqlCommand command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = string.Format("Select {0} From {1} {2}", fieldName, tblName, condition),
                        CommandType = CommandType.Text
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        output.Add(reader[fieldName].ToString());
                    }
                    connection.Close();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return output;
            }
        }
        //_________________________________________________________________________
        public static string Select(string table, string fieldName, string condition = "")
        {
            string output;

            if (condition != string.Empty)
            {
                condition = " Where(" + condition + ")";
            }

            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                SqlCommand sq = new SqlCommand(string.Format("Select {0} From {1} {2}", fieldName, table, condition));
                sq.Connection = connection;
                object o = sq.ExecuteScalar();

                if (o == null)
                {
                    output = string.Empty;
                }
                else
                {
                    output = Convert.ToString(o);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = string.Empty;
            }
            finally
            {
                connection.Close();
            }

            return output;
        }
        //_________________________________________________________________________
        public static bool RowExists(string tableName, string Condition)
        {
            bool yes_no = false;
            SqlConnection sq = new SqlConnection();
            try
            {
                sq.ConnectionString = ConnectionString;
                sq.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sq;
                if (Condition == "")
                    cmd.CommandText = "SELECT * FROM " + tableName;
                else
                    cmd.CommandText = "SELECT * FROM " + tableName + " WHERE (" + Condition + ")";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    yes_no = true;
                else
                    yes_no = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                yes_no = false;
            }
            finally
            {
                sq.Close();
            }
            return yes_no;
        }
    }
}
