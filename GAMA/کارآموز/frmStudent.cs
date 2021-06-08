using System;
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
    public partial class FrmStudent : FrmMaster
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        //Events*******************************
        #region

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            (new FrmAddEditSabtNam(Moods.Add)).Show();
        }
        private void FrmStudent_Load(object sender, EventArgs e)
        {
            SetLocations();
            Theme.Set(this);
            LoadData();
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        private void LoadData()
        {
            SqlServerClass.ShowQueryInDataGridView(dataGridView1,("EXEC Get_All_Student "));
        }
        private void SetLocations()
        {
            // Y
            Locations.CenterHeight(this, dataGridView1);
            dataGridView1.Top += 15;
            Locations.Down(dataGridView1, 25, false, btnAdd, btnDelete, btnDetails, btnEdit);

            // X
            Locations.CenterWidth(this, dataGridView1, btnAdd);
            Locations.CenterWidth(this, panel1);
            Locations.Right(btnAdd, 3, true, btnEdit);
            Locations.Left(btnAdd, 3, true, btnDelete, btnDetails);
        }

        #endregion
        //*************************************
    }
}
