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
        public frmDetails(string tableName, string idValue)
        {
            InitializeComponent();

            table = tableName;
            id = idValue;
        }

        //Variables****************************
        #region

        private readonly string id;
        private readonly string table;

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
            string condition = string.Format("id = {0}", id);

            string name = SqlServerClass.Select(table, "userId", condition); ;
            string time = SqlServerClass.Select(table, "InsertTime", condition);
            string date = SqlServerClass.Select(table, "InsertDate", condition);

            txtName.Text = name;
            txtDate.Text = date;
            txtTime.Text = time;
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
