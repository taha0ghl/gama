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
    public partial class FrmAddEditSabtNamCourse : FrmMaster
    {
        public FrmAddEditSabtNamCourse(Moods m)
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
            if (ControlManager.CheckEmptyControls(panel1))
            {
                return;
            }

            string idDore = SqlCaptureManager.GetField(TableNames.Course, "id", string.Format("courseName = N'{0}'", mainCombo1.SelectedItem));

            string date = StaticData.current_date;
            string time = DateTimeManager.GetTime(DateTime.Now).Substring(0, 5);
            string userId = StaticData.current_user.Id;
            bool insert1, insert2;

            string[] fields1 = {
                "sabtnamdate",
                "studentId",
                "idDore",
                "nahve",
                "typeClass",
                "freeTime",
                "Cost",
                "sabtnamUser",
                "description",
                "insertDate",
                "insertTime",
                "UserId"
            };
            string[] values1 = {
                txtSabtnamDate.Text,
                txtCode.Text,
                idDore,
                txtNahveMoarefi.Text,
                txtNoeClass.Text,
                txtVaghtAzad.Text,
                txtShahrie.Text,
                txtSabtnamUser.Text,
                txtDescription.Text,
                date,
                time,
                userId
            };

            if (!SqlServerClass.RowExists(TableNames.Student, string.Format("Id = {0}", txtCode.Text)))
            {
                string[] fields2 = {
                    "id",
                    "fName",
                    "lName",
                    "nCode",
                    "nationalCode",
                    "gender",
                    "married",
                    "issuePlace",
                    "birthDate",
                    "father",
                    "mother",
                    "education",
                    "tel",
                    "mobile",
                    "telegramNumber",
                    "studentJob",
                    "address",
                    "postalCode",
                    "email",
                    "insertDate",
                    "insertTime",
                    "UserId"
                };
                string[] values2 = {
                    txtCode.Text,
                    txtName.Text,
                    txtLName.Text,
                    txtShomareShenasname.Text,
                    txtMeli.Text,
                    Convert.ToString(comboGensiat.SelectedIndex),
                    Convert.ToString(comboTahol.SelectedIndex),
                    txtMahalSodor.Text,
                    txtBirthDate.Text,
                    txtPedar.Text,
                    txtMother.Text,
                    txtTahsilat.Text,
                    txtTelephone.Text,
                    txtMobile.Text,
                    txtTelegram.Text,
                    txtShoghl.Text,
                    txtAdres.Text,
                    txtCodePosty.Text,
                    txtEmail.Text,
                    date,
                    time,
                    userId
                };

                insert2 = SqlServerClass.InsertWithFields(
                    TableNames.Student,
                    fields2[0], values2[0],
                    fields2[1], values2[1],
                    fields2[2], values2[2],
                    fields2[3], values2[3],
                    fields2[4], values2[4],
                    fields2[5], values2[5],
                    fields2[6], values2[6],
                    fields2[7], values2[7],
                    fields2[8], values2[8],
                    fields2[9], values2[9],
                    fields2[10], values2[10],
                    fields2[11], values2[11],
                    fields2[12], values2[12],
                    fields2[13], values2[13],
                    fields2[14], values2[14],
                    fields2[15], values2[15],
                    fields2[16], values2[16],
                    fields2[17], values2[17],
                    fields2[18], values2[18],
                    fields2[19], values2[19],
                    fields2[20], values2[20],
                    fields2[21], values2[21]
                    );
            }
            else
            {
                insert2 = true;
            }

            switch (mood)
            {
                case Moods.Add:
                    insert1 = SqlServerClass.InsertWithFields(
                        TableNames.SabtnamCourse,
                        fields1[0], values1[0],
                        fields1[1], values1[1],
                        fields1[2], values1[2],
                        fields1[3], values1[3],
                        fields1[4], values1[4],
                        fields1[5], values1[5],
                        fields1[6], values1[6],
                        fields1[7], values1[7],
                        fields1[8], values1[8],
                        fields1[9], values1[9],
                        fields1[10], values1[10],
                        fields1[11], values1[11]
                        );
                    break;
                case Moods.Edit:
                    insert1 = SqlServerClass.Update(TableNames.SabtnamCourse, fields1, values1, string.Format("id = {0}", id));
                    break;
                default:
                    insert1 = false;
                    break;
            }

            if (insert1 && insert2)
            {
                MessageBox.Show("با موفقیت انجام شد");
                Close();
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
            string headerText = string.Empty;
            txtLoggedUser.ReadOnly = txtId.ReadOnly = txtCode.ReadOnly = true;
            ControlManager.SetComboItems(mainCombo1, SqlCaptureManager.AllCourse());

            switch (mood)
            {
                case Moods.Add:
                    headerText = "ثبت نام جدید";
                    btnAdd.Text = "ثبت";
                    FindId();
                    break;
                case Moods.Edit:
                    headerText = "ویرایش اطلاعات ثبت نام";
                    btnAdd.Text = "ویرایش";
                    LoadData();
                    break;
                default:
                    break;
            }

            Text = headerText;
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
            txtId.Text = Convert.ToString(SqlServerClass.RowCount(TableNames.SabtnamCourse, "Id") + 1);
        }
        private void LoadData()
        {
            DataGridViewRow row = FrmSabtNamCourse.selected_row;

            txtName.Text = Convert.ToString(row.Cells["نام"].Value);
            txtLName.Text = Convert.ToString(row.Cells["نام خانوادگی"].Value);
            mainCombo1.SelectedItem = Convert.ToString(row.Cells["دوره"].Value);
            txtNoeClass.Text = Convert.ToString(row.Cells["نوع کلاس"].Value);
            txtSabtnamDate.Text = Convert.ToString(row.Cells["تاریخ ثبت نام"].Value);
            txtShahrie.Text = Convert.ToString(row.Cells["شهریه"].Value);
            txtNahveMoarefi.Text = Convert.ToString(row.Cells["نحوه معرفی"].Value);
            txtVaghtAzad.Text = Convert.ToString(row.Cells["وقت آزاد"].Value);
            txtSabtnamUser.Text = Convert.ToString(row.Cells["ثبت نام کننده"].Value);
            txtDescription.Text = Convert.ToString(row.Cells["توضیحات"].Value);
        }
        private void LoadDetails()
        {
            lblTitle.Text = string.Format("فرم ثبت نام دوره - آموزشگاه {0}", SqlCaptureManager.DepartmentName());
            lblDate.Text = string.Format("تاریخ ثبت نام : {0}", StaticData.current_date);
            txtLoggedUser.Text = StaticData.current_user.FirstName + " " + StaticData.current_user.LastName;
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
