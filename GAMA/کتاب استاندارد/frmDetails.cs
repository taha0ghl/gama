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
    public partial class frmDetails : FrmMaster
    {
        public frmDetails(string name, string date, string time)
        {
            InitializeComponent();
            insertName = name;
            insertDate = date;
            insertTime = time;
        }

        //Variables****************************
        #region

        private readonly string insertName;
        private readonly string insertDate;
        private readonly string insertTime;

        #endregion
        //*************************************

        //Events*******************************
        #region 

        private void FrmDetails_Load(object sender, EventArgs e)
        {
            LoadData();
            SetLocations();
            ControlManager.ReadOnly(panel1, true);
        }

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void LoadData()
        {
            txtName.Text = insertName;
            txtDate.Text = insertDate;
            txtTime.Text = insertTime;
        }
        private void SetLocations()
        {
            // Y
            Locations.CenterHeight(this, panel1);

            // X
            Locations.CenterWidth(this, panel1);
            Locations.RightOrder(panel1, 5, mainlbl1, mainlbl2, mainlbl3);
        }

        #endregion
        //*************************************
    }
}
