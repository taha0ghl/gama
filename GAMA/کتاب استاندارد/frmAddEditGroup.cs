using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    public partial class FrmAddEditGroup : FrmMaster
    {
        public FrmAddEditGroup(Moods m)
        {
            InitializeComponent();
            mood = m;
        }

        //Variables****************************
        #region

        private readonly Moods mood;
        private string id = string.Empty;
        private string branchId = string.Empty;

        #endregion
        //*************************************

        //Events*******************************
        #region 

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ControlManager.CheckEmptyControls(panel1))
            {
                return;
            }

            string time = DateTimeManager.GetTime(DateTime.Now);
            branchId = SqlServerClass.Select(TableNames.BranchCourse, "Id", string.Format("branchName = N'{0}'", mainCombo1.SelectedItem));

            string[] fields = { "IdBranch", "groupName", "InsertDate", "InsertTime", "UserId" };
            string[] values = { branchId, mainTxt1.Text, StaticData.current_date, time, Convert.ToString(StaticData.current_user.Id) };

            switch (mood)
            {
                case Moods.Add:
                    if (SqlServerClass.RowExists(TableNames.GroupCourse, string.Format("groupName = N'{0}'", mainTxt1.Text)))
                    {
                        MessageBox.Show("گروهی با همین نام ثبت شده است");
                        return;

                    }
                    if (SqlServerClass.InsertWithFields(TableNames.GroupCourse, fields[0], values[0], fields[1], values[1], fields[2], values[2], fields[3], values[3], fields[4], values[4]))
                    {
                        MessageBox.Show("درج شد");
                        Close();
                    }
                    break;
                case Moods.Edit:
                    if (SqlServerClass.Update(TableNames.GroupCourse, fields, values, string.Format("Id = {0}", id)))
                    {
                        MessageBox.Show("ویرایش شد");
                        Close();
                    }
                    break;
                default:
                    break;
            }
        }
        private void FrmAddEditGroup_Load(object sender, EventArgs e)
        {
            ControlManager.SetComboItems(mainCombo1, SqlCaptureManager.AllBranchs());
            string headerText = string.Empty;
            txtId.ReadOnly = true;

            switch (mood)
            {
                case Moods.Add:
                    headerText = "اضافه کردن";
                    btnAdd.Text = "ثبت";
                    FindId();
                    FindBranch();
                    break;
                case Moods.Edit:
                    headerText = "ویرایش";
                    btnAdd.Text = "ویرایش";
                    LoadData();
                    break;
                default:
                    break;
            }

            Text = string.Format("{0} گروه", headerText);
            SetLocations();
        }
        private void FrmAddEditGroup_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                    panel1.Left + 20,
                    btnAdd.Top - 10,
                    panel1.Right - 20,
                    btnAdd.Top - 10);
        }

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void FindId()
        {
            txtId.Text = Convert.ToString(SqlServerClass.RowCount(TableNames.GroupCourse, "Id") + 1);
        }
        private void LoadData()
        {
            txtId.Text = Convert.ToString(FrmGroup.selected_row.Cells["شماره ردیف"].Value);
            mainTxt1.Text = Convert.ToString(FrmGroup.selected_row.Cells["نام گروه"].Value);

            id = SqlServerClass.Select(TableNames.GroupCourse, "Id", string.Format("groupName = N'{0}'", Convert.ToString(FrmGroup.selected_row.Cells["نام گروه"].Value)));
            branchId = SqlServerClass.Select(TableNames.GroupCourse, "IdBranch", string.Format("Id = {0}", id));

            mainCombo1.SelectedItem = FrmGroup.selected_row.Cells["نام خوشه"].Value;
        }
        private void FindBranch()
        {
            if (FrmBranch.selected_row == null)
            {
                return;
            }

            mainCombo1.SelectedItem = FrmBranch.selected_row.Cells["نام خوشه"].Value;
        }
        private void SetLocations()
        {
            panel1.Designer.SetSize();
            panel1.Height += 10;
            panel1.Designer.SetLocation();

            // Y
            panel1.Top = HeaderHeight + 15;
            btnAdd.Top = panel1.Bottom + 20;

            // x
            Locations.CenterWidth(this, panel1, btnAdd);
        }

        #endregion
        //*************************************
    }
}
