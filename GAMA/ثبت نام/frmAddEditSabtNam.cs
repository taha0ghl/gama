using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;
using System.Collections;

namespace GAMA
{
    public partial class FrmAddEditSabtNam : FrmMaster
    {
        public FrmAddEditSabtNam(Moods m)
        {
            InitializeComponent();
            mood = m;
        }

        //Variables****************************
        #region

        private string id;
        private readonly Moods mood;

        #endregion
        //*************************************

        //Events*******************************
        #region 

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            return;

            string[] fields1 = { "sabtnamdate", "studentId", "idDore", "nahve", "typeClass", "freeTime", "Cost", "sabtnamUser", "description", "insertDate", "insertTime", "UserId" };
            string[] values1 = { txtSabtnamDate.Text, ,, txtNahveMoarefi.Text, txtNoeClass.Text, txtVaghtAzad.Text, txtShahrie.Text, txtSabtnamUser.Text, txtDescription.Text, StaticData.current_date,, StaticData.current_user.Id };
            //bool insert1 = SqlServerClass.InsertWithFields();

            string[] fields2 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "insertDate", "insertTime", "UserId" };

            if (true)
            {

            }
        }
        private void BtnEmza_Click(object sender, EventArgs e)
        {
            OpenFileDialog picexplorer = OpenFileDialogManager.Picture(false, "لطفا تصویر امضا را انتخاب کنید");

            btnEmza.BackgroundImage = OpenFileDialogManager.Picture(picexplorer);
        }
        private void BtnTasvir_Click(object sender, EventArgs e)
        {
            OpenFileDialog picexplorer = OpenFileDialogManager.Picture(false, "لطفا تصویر کارآموز را انتخاب کنید");

            btnTasvir.BackgroundImage = OpenFileDialogManager.Picture(picexplorer);
        }
        private void FrmAddEditStudent_Load(object sender, EventArgs e)
        {
            txtLoggedUser.ReadOnly = txtId.ReadOnly = txtCode.ReadOnly = true;
            LoadDetails();
            SetLocations();
        }
        private void FrmAddEditStudent_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                    panel1.Left + 20,
                    btnAdd.Top - 10,
                    panel1.Right - 20,
                    btnAdd.Top - 10);

            graphic.DrawLine(Theme.Pen1,
                    panel1.Left - 20,
                    lblDate.Bottom + 5,
                    panel1.Right + 20,
                    lblDate.Bottom + 5);
        }
        private void BtnPics_BackgroundImageChanged(object sender, EventArgs e)
        {
            BaseBtn btn = sender as BaseBtn;

            btn.ImageList = btn.BackgroundImage == null ? imageList1 : null;
        }
        private void FrmAddEditStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtAdres.Width = txtMobile.Width;
            txtDocument.Text = string.Empty;
            ControlManager.ClearControls(this);
            btnTasvir.BackgroundImage = btnEmza.BackgroundImage = null;
        }

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void FindId()
        {
            txtId.Text = Convert.ToString(SqlServerClass.RowCount(TableNames.Student, "Id") + 1);
        }
        private void LoadData()
        {

        }
        private void LoadDetails()
        {
            lblTitle.Text = string.Format("فرم ثبت نام دوره - آموزشگاه {0}", SqlCaptureManager.DepartmentName());
            lblDate.Text = string.Format("تاریخ ثبت نام : {0}", StaticData.current_date);
            txtLoggedUser.Text = StaticData.current_user.FirstName + " " + StaticData.current_user.LastName;
            ControlManager.SetComboItems(mainCombo1, SqlCaptureManager.AllCourse());
            string doc = SqlCaptureManager.RequirdDocumants();

            string[] subDocs = doc.Split(',');
            txtDocument.Text += "*مدارک مورد نیاز*";

            for (int i = 0; i < subDocs.Length; i++)
            {
                txtDocument.Text += string.Format("{0}{1}-{2}", Environment.NewLine, (i + 1), subDocs[i]);
            }
        }
        private void SetLocations()
        {
            panel1.Designer.SetSize();
            panel1.Height += 20;
            panel1.Designer.SetLocation();

            txtAdres.Width = txtCodePosty.Right - txtNahveMoarefi.Left;
            panel1.Controls.Add(txtDocument);

            Height = panel1.Height + HeaderHeight + 150;

            // Y
            lblDate.Top = HeaderHeight + 15;
            panel1.Top = HeaderHeight + 70;
            pnlLoggedUser.Top = btnAdd.Top = panel1.Bottom + 20;
            mainlbl5.Top = mainlbl30.Top;
            //btnEmza.Top = mainlbl21.Top = mainlbl18.Top;
            //Locations.AlignBottoms(txtSabtnamDate, txtDocument);

            // x
            Locations.CenterWidth(this, panel1, btnAdd);
            Locations.AlignRights(txtCodePosty, txtAdres);
            Locations.AlignRights(panel1, lblTitle);
            Locations.AlignLefts(panel1, lblDate, pnlLoggedUser);
            txtDocument.AlignCenter(btnTasvir);
        }

        #endregion
        //*************************************
    }
}
