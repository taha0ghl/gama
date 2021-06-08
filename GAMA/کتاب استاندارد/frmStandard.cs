using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    public partial class FrmStandard : FrmMaster
    {
        public FrmStandard()
        {
            InitializeComponent();
        }


        //Variables****************************
        #region

        public static DataGridViewRow selected_row;
        private const string fieldCondition = "نام دوره";

        #endregion
        //*************************************

        //Events*******************************
        #region

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            (new FrmAddEditCourse(Moods.Add)).ShowDialog();

            ComboSearch_SelectedIndexChanged(null, null);
            dataGridView1.ClearSelection();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای ویرایش انتخاب کنید", fieldCondition))
            {
                return;
            }

            CaptureRow();

            (new FrmAddEditCourse(Moods.Edit)).ShowDialog();

            ComboSearch_SelectedIndexChanged(null, null);
            dataGridView1.ClearSelection();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای حذف کردن انتخاب کنید", fieldCondition))
            {
                return;
            }

            if (MessageBox.Show("آیا از حذف کردن اطمینان دارید ؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = SqlServerClass.Select(TableNames.Course, "Id", string.Format("courseName = N'{0}'", Convert.ToString(dataGridView1.SelectedRows[0].Cells[fieldCondition].Value)));

                if (SqlServerClass.Delete(TableNames.Course, "Id = " + id))
                {
                    DataGridViewManager.DeleteRow(dataGridView1, dataGridView1.CurrentCell.RowIndex);
                    MessageBox.Show("حذف شد");
                }
            }
        }
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای نمایش جزییات انتخاب کنید", fieldCondition))
            {
                return;
            }

            CaptureRow();

            string name, time, date;

            // test!!!!!!!!!!!
            name = string.Empty;

            time = SqlServerClass.Select(TableNames.Course, "InsertTime", string.Format("courseName = N'{0}'", selected_row.Cells[fieldCondition].Value));
            date = SqlServerClass.Select(TableNames.Course, "InsertDate", string.Format("courseName = N'{0}'", selected_row.Cells[fieldCondition].Value));

            (new frmDetails(name, date, time)).ShowDialog();
        }
        private void FrmStandard_Load(object sender, EventArgs e)
        {
            ControlManager.SetComboItems(comboBranch, SqlCaptureManager.AllBranchs());
            ControlManager.SetComboItems(comboGroup, SqlCaptureManager.AllGroups());

            comboSearch.SelectedItem = "همه";

            Theme.Set(this, pnlSearch, pnlBranch, pnlGroup);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            SetLocations();
        }
        private void FrmStandard_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                btnDetails.Left,
                btnDetails.Top - 10,
                btnEdit.Right,
                btnDetails.Top - 10);
        }
        private void Comboes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            DataGridViewManager.Clear(dataGridView1);

            if (combo.SelectedIndex == -1)
            {
                return;
            }

            if (combo.Name == comboBranch.Name)
            {
                LoadBranchData();
            }
            else if (combo.Name == comboGroup.Name)
            {
                LoadGroupData();
            }
        }
        private void ComboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewManager.Clear(dataGridView1);

            if (comboSearch.SelectedIndex == -1)
            {
                return;
            }

            switch (Convert.ToString(comboSearch.SelectedItem))
            {
                case "همه":
                    pnlGroup.Hide();
                    pnlBranch.Hide();
                    comboBranch.SelectedIndex = -1;
                    comboGroup.SelectedIndex = -1;
                    LoadAllData();
                    break;
                case "خوشه":
                    comboGroup.SelectedIndex = -1;
                    FindPnl();
                    break;
                case "گروه":
                    comboBranch.SelectedIndex = -1;
                    FindPnl();
                    break;
                default:
                    break;
            }

            dataGridView1.ClearSelection();
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        private void FindPnl()
        {
            foreach (Panel item in Controls.OfType<Panel>())
            {
                if (Convert.ToString(item.Tag) == "search")
                {
                    continue;
                }

                if (item.Tag == comboSearch.SelectedItem)
                {
                    item.Show();
                }
                else
                {
                    item.Hide();
                }
            }
        }
        private void CaptureRow()
        {
            selected_row = dataGridView1.SelectedRows[0];
        }
        private void LoadAllData()
        {
            SqlServerClass.ShowQueryInDataGridView(dataGridView1, "EXEC Get_Course_All");
        }
        private void SetLocations()
        {
            // Y
            pnlSearch.Top = 20 + HeaderHeight;
            pnlBranch.Top = pnlGroup.Top = pnlSearch.Bottom + 15;
            dataGridView1.Top = pnlBranch.Bottom + 15;
            Locations.Down(dataGridView1, 25, false, btnAdd, btnDelete, btnDetails, btnEdit);

            // X
            Locations.CenterWidth(this, dataGridView1, pnlBranch, pnlGroup, pnlSearch);
            btnAdd.Left = dataGridView1.Left + dataGridView1.Width / 2 + 3;
            Locations.Right(btnAdd, 3, true, btnEdit);
            Locations.Left(btnAdd, 3, true, btnDelete, btnDetails);
            Locations.RightOrder(pnlSearch, 1, lblSearch);
            Locations.RightOrder(pnlBranch, 1, lblBranch);
            Locations.RightOrder(pnlGroup, 1, lblGroup);
        }
        private void LoadGroupData()
        {
            string groupId = SqlServerClass.Select(TableNames.GroupCourse, "Id", string.Format("groupName = N'{0}'", comboGroup.SelectedItem));

            SqlServerClass.ShowQueryInDataGridView(dataGridView1, string.Format("EXEC Get_Course_Condition_GroupId @groupId = {0}", groupId));
        }
        private void LoadBranchData()
        {
            string branchId = SqlServerClass.Select(TableNames.BranchCourse, "Id", string.Format("branchName = N'{0}'", comboBranch.SelectedItem));

            SqlServerClass.ShowQueryInDataGridView(dataGridView1, string.Format("EXEC Get_Course_Condition_BranchId @branchId = {0}", branchId));
        }

        #endregion
        //*************************************
    }
}
