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
    public partial class FrmAddEditStudent : FrmMaster
    {
        public FrmAddEditStudent(Moods mood, string id = "")
        {
            InitializeComponent();
            InitialDesign();
            this.mood = mood;
            this.id = id;
            AdjustMood();
        }

        #region Fields

        public readonly Moods mood;
        private string id;
        private string[] columns =
            {"fName",
                "lName",
                "nCode",
                "nationalCode",
                "Gender",
                "Married",
                "issuePlace",
                "birthDate",
                "Father",
                "Mother",
                "Education",
                "Tel",
                "Mobile",
                "TelegramNumber",
                "StudentJob",
            "Address",
            "PostalCode",
            "Email",
            "Pic",
            "Signature" };

        #endregion


        #region Properties


        #endregion


        #region Event Implication

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ControlManager.CheckEmptyControls(pnlAutoDesign1))
            {
                MessageBox.Show("لطفا همه فیلد ها را پر کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool success = false;
            switch (mood)
            {
                case Moods.Add:
                    success = AddStudent();
                    break;
                case Moods.Edit:
                    success = UpdateStudent();
                    break;
            }
            if (success)
                this.DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnChooseSignature_Click(object sender, EventArgs e)
        {
            //if (SelectImageFromFile(out Image img))
            //    picSignature.Image = img;
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            //if (SelectImageFromFile(out Image img))
            //    picImage.Image = img;
        }

        private void PicBirthDate_Click(object sender, EventArgs e)
        {
            string date = DateTimeManager.GetDate(DateTime.Now);
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));
            FrmDatePicker datePicker = new FrmDatePicker(year, month, day, Enum.GetNames(typeof(PersianMonthNames)));
            Locations.AlignCenters(this, datePicker);
            Locations.AlignMiddles(this, datePicker);
            datePicker.StartPosition = FormStartPosition.Manual;
            if (datePicker.ShowDialog(this) == DialogResult.OK)
                txtBirthDate.Text = String.Format("{0}/{1}/{2}", datePicker.Year.ToString().PadLeft(4, '0'), datePicker.Month.ToString().PadLeft(2, '0'), datePicker.Day.ToString().PadLeft(2, '0'));
        }

        #endregion


        #region Method

        private void InitialDesign()
        {
            //pnlAutoDesign1.ColumnCount = 4;
            //pnlAutoDesign1.RowCount = 13;
            //pnlAutoDesign1.Designer.SetSize();
            //pnlAutoDesign1.Designer.SetLocation();
            //throw new NotImplementedException();
            Locations.CenterWidth(this, btnAdd);
        }

        private void AdjustMood()
        {
            string headerText = string.Empty;
            string buttonText = string.Empty;
            switch (mood)
            {
                case Moods.Add:
                    headerText = "اضافه کردن";
                    buttonText = "ثبت";
                    break;
                case Moods.Edit:
                    headerText = "ویرایش";
                    buttonText = "ویرایش";
                    LoadDataFromBank();
                    break;
            }
            Text = string.Format("{0} دوره", headerText);
            btnAdd.Text = buttonText;
        }

        #region Bank Transaction
        private bool AddStudent()
        {
            id = CreateStudentID();
            object[] dataFromForm = GetDataFromForm();
            object[] additionalData = GetAdditionalFields();
            object[] values = new object[dataFromForm.Length + additionalData.Length + 1];
            values[0] = id;
            Array.Copy(dataFromForm, 0, values, 1, dataFromForm.Length);
            Array.Copy(additionalData, 0, values, dataFromForm.Length + 1, additionalData.Length);
            return SqlServerClass.Insert(TableNames.Student, values);
        }

        private bool UpdateStudent()
        {
            return SqlServerClass.Update(TableNames.Student, columns, GetDataFromForm(), "Id = \'" + id + "\'");
        }

        private DataRow GetSelectedRow()
        {
            return SqlServerClass.SelectOneRow(TableNames.Student, columns, "Id = " + id);
        }
        #endregion

        #region Related To Bank
        private void LoadDataFromBank()
        {
            DataRow row = GetSelectedRow();
            txtFName.Text = row["fName"].ToString();
            txtLName.Text = row["lName"].ToString();
            txtNCode.Text = row["nCode"].ToString();
            txtNationalCode.Text = row["nationalCode"].ToString();
            SetGender((bool)row["Gender"]);
            SetMarriage((bool)row["Married"]);
            txtIssuePlace.Text = row["issuePlace"].ToString();
            txtBirthDate.Text = row["birthDate"].ToString();
            txtFather.Text = row["Father"].ToString();
            txtMother.Text = row["Mother"].ToString();
            txtEducation.Text = row["Education"]?.ToString();
            txtTell.Text = row["Tel"].ToString();
            txtMobile.Text = row["Mobile"].ToString();
            txtTelegramID.Text = row["TelegramNumber"].ToString();
            txtStudentJob.Text = row["StudentJob"].ToString();
            txtAddress.Text = row["Address"].ToString();
            txtAddress.Text = row["Address"].ToString();
            txtPostalCode.Text = row["PostalCode"].ToString();
            txtEmail.Text = row["Email"].ToString();
            //picImage.Image = ConvertBinaryToImageIfNotNull(row["Pic"]);
            //picSignature.Image = ConvertBinaryToImageIfNotNull(row["Signature"]);
        }

        private object[] GetDataFromForm()
        {
            object[] result =
            {
                txtFName.Text,
                txtLName.Text,
                txtNCode.Text,
                txtNationalCode.Text,
                GetGender(),
                GetMarriage(),
                txtIssuePlace.Text,
                txtBirthDate.Text,
                txtFather.Text,
                txtMother.Text,
                txtEducation.Text,
                txtTell.Text,
                txtMobile.Text,
                txtTelegramID.Text,
                txtStudentJob.Text,
                txtAddress.Text,
                txtPostalCode.Text,
                txtEmail.Text
                //ConvertImageToBankValue(picImage.Image),
                //ConvertImageToBankValue(picSignature.Image)
            };
            return result;
        }

        private object[] GetAdditionalFields()
        {
            object[] result =
            {
                DateTimeManager.GetDate(DateTime.Now),
                DateTimeManager.GetTime(DateTime.Now).Substring(0, 5),
                StaticData.current_user.Id
            };
            return result;
            throw new NotImplementedException();
        }

        private string CreateStudentID()
        {
            string date = DateTimeManager.GetDate(DateTime.Now);
            string[] parameterNames = { "@year", "@month" };
            SqlDbType[] parameterTypes = { SqlDbType.Char, SqlDbType.Char };
            object[] values = { date.Substring(0, 4), date.Substring(5, 2) };
            return SqlServerClass.ExecuteScalerFunction("GetStudentId", parameterNames, parameterTypes, SqlDbType.Char, values).ToString();
        }
        #endregion

        private byte[] GetBinary(Image img)
        {
            byte[] result;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                result = stream.ToArray();
                stream.Flush();
            }
            return result;
        }

        private void SetGender(bool gender)
        {
            if (gender)
                rdbGenderMan.Checked = true;
            else
                rdbGenderWoman.Checked = true;
        }

        private bool GetGender()
        {
            bool result = rdbGenderMan.Checked;
            return result;
        }

        private void SetMarriage(bool marriage)
        {
            if (marriage)
                rdbMarriedYes.Checked = true;
            else
                rdbMarriedNo.Checked = true;
        }

        private bool GetMarriage()
        {
            bool result = rdbMarriedYes.Checked;
            return result;
        }

        private Image ConvertBinaryToImageIfNotNull(object binary)
        {
            if (IsDBNull(binary))
                return GetContactDefaultImage();
            Image result;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream((byte[])binary))
            {
                result = new Bitmap(stream);
                stream.Flush();
            }
            return result;
        }

        private byte[] ConvertImageToBankValue(Image img)
        {
            if (img is null || img.Equals(GetContactDefaultImage()))
                return null;
            byte[] result = GetBinary(img);
            return result;
        }

        private Image GetContactDefaultImage() => Properties.Resources.Contact;

        private Image GetSignatureDefaultImage() => Properties.Resources.Signature;

        private bool IsDBNull(object obj)
        {
            bool result = false;
            if (obj == DBNull.Value)
                result = true;
            return result;
        }

        private bool SelectImageFromFile(out Image result)
        {
            bool succuss = false;
            OpenFileDialog open = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "PNG Images |*.png | JPG Images |*.jpg| Bitmap Images |*.bmp| All Images |*.png;*.jpg;*.bmp",
                FilterIndex = 4,
                Multiselect = false
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                succuss = true;
                result = Image.FromFile(open.FileName);
            }
            else
                result = null;
            return succuss;
        }

        #endregion
    }
}
