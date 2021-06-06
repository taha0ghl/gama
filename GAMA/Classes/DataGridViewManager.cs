using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GAMA
{
    public class DataGridViewManager
    {
        //Methods******************************
        #region

        public static void Clear(DataGridView dgv)
        {
            dgv.DataSource = null;
            //dgv.Rows.Clear();
            //dgv.Columns.Clear();
        }

        // Display
        public static void SetWidth(DataGridView dgv, params object[] columnName_percent)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            double unit = dgv.Width / 100;
            int sumWidth = 0;

            for (int i = 0; i < columnName_percent.Length; i += 2)
            {
                string name = Convert.ToString(columnName_percent[i]);
                int percent = Convert.ToInt32(columnName_percent[i + 1]);

                dgv.Columns[name].Width = Convert.ToInt32(unit * percent);
                sumWidth += Convert.ToInt32(unit * percent);
            }
            dgv.Columns[Convert.ToString(columnName_percent[0])].Width += dgv.Width - sumWidth;
            //int s = 0;
            //for (int i = 0; i < dgv.Columns.Count; i++)
            //{
            //    s += dgv.Columns[i].Width;
            //}
            //dgv.Columns[Convert.ToString(columnName_percent[0])].Width -= dgv.Width - s;
        }
        public static void SetDisplayIndex(DataGridView dgv, params object[] columnName_index)
        {
            for (int i = 0; i < columnName_index.Length; i += 2)
            {
                string name = Convert.ToString(columnName_index[i]);
                int index = Convert.ToInt32(columnName_index[i + 1]);

                dgv.Columns[name].DisplayIndex = index;
            }
        }

        // Row
        public static void DeleteRow(DataGridView dgv, int RowIndex)
        {
            dgv.Rows.RemoveAt(RowIndex);
            if (dgv.RowCount != 0)
            {
                if (RowIndex < dgv.RowCount - 1)
                {
                    dgv.CurrentCell = dgv.Rows[RowIndex].Cells[0];
                }
                else
                {
                    dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[0];
                }
            }

        }
        public static void AddRowAtEnd(DataGridView dgv, params object[] colData)
        {
            DataTable table = dgv.DataSource as DataTable;
            table.Rows.Add(colData);
            dgv.DataSource = table;
        }
        public static void EditRow(DataGridView dgv, int RowIndex, params object[] ColData)
        {
            for (int i = 0; i < ColData.Length; i++)
            {
                dgv.Rows[RowIndex].Cells[i].Value = ColData[i];
            }
        }

        // Column
        public static void AddColumn(DataGridView dgv, string columnName, int index)
        {
            DataTable table = dgv.DataSource as DataTable;
            DataColumn column = new DataColumn(columnName);

            if (table.Columns.Contains(columnName))
            {
                table.Columns.Remove(columnName);
            }

            table.Columns.Add(column);
            dgv.DataSource = table;
            dgv.Columns[columnName].DisplayIndex = index;
        }
        public static void WriteColumnData(DataGridView dgv, string columnName, ArrayList data)
        {
            DataTable table;

            if (dgv.DataSource == null)
            {
                table = new DataTable();
            }
            else
            {
                table = (DataTable)dgv.DataSource;
            }

            if (!table.Columns.Contains(columnName))
            {
                table.Columns.Add(columnName);
            }

            while (table.Rows.Count < data.Count)
            {
                table.Rows.Add(table.NewRow());
            }

            for (int i = 0; i < data.Count; i++)
            {
                table.Rows[i].SetField<object>(columnName, data[i]);
            }

            dgv.DataSource = table;
        }

        public static bool IsOneRowSelected(DataGridView dgv, string dialog, string field = "")
        {
            bool output = true;

            if (dgv.SelectedRows.Count != 1 || (field != string.Empty && dgv.SelectedRows[0].Cells[field].Value == null))
            {
                MessageBox.Show(dialog);
                output = false;
            }

            return output;
        }

        #endregion
        //*************************************
    }
}
