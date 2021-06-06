using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAMA;

namespace MyClass
{
    public static class Theme
    {
        //Variables****************************
        #region

        public static string FontFamily = "B nazanin";

        // Colors
        #region 
        public static Color ControlBackColor1 = Color.FromArgb(53, 49, 72);
        public static Color ControlForeColor1 = Color.White;

        public static Color Color1 = Color.FromArgb(214, 203, 214);
        public static Color Color2 = Color.FromArgb(223, 221, 223);
        public static Color Color3 = Color.FromArgb(108, 70, 113);

        public static Color HeaderColor = Color.FromKnownColor(KnownColor.DarkGray);

        public static Color BackColor1 = Color.FromArgb(237, 237, 237);
        public static Color ForeColor1 = Color.Black;
        public static Color BackColor2 = Color.FromArgb(245, 245, 245);
        public static Color ForeColor2 = Color.Black;

        public static Color LineColor = Color.FromArgb(100, 100, 100);
        #endregion

        // Pen
        #region
        public static Pen Pen1 = new Pen(Color.FromArgb(203, 200, 204), 1);
        #endregion

        // Btn
        #region 
        public static int BORDERSIZE_Btn = 0;
        public static Cursor CURSOR_Btn = Cursors.Hand;
        public static FlatStyle FLATSTYLE_Btn = FlatStyle.Flat;
        #endregion

        // Panel
        #region
        public static BorderStyle BORDERSTYLE_Panel = BorderStyle.None;
        //public static Color BACKCOLOR_Panel = Color.FromArgb(217, 195, 158);
        public static Color BACKCOLOR_Panel = Color2;
        #endregion

        #endregion
        //*************************************

        //Methods******************************
        #region 

        public static void SetButton(params Button[] btns)
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Cursor = CURSOR_Btn;
                btns[i].FlatStyle = FLATSTYLE_Btn;
                //btns[i].ForeColor = ControlForeColor1;
                btns[i].FlatAppearance.BorderSize = BORDERSIZE_Btn;
                btns[i].BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        public static void SetDataGridView(DataGridView dgv)
        {
            #region
            //dgv.RowsDefaultCellStyle.BackColor = StaticData.DataGridView_Row_BackColor
            //dgv.ColumnHeadersDefaultCellStyle.ForeColor = StaticData.DataGridView_Column_ForeColor;
            //dgv.ColumnHeadersDefaultCellStyle.BackColor = StaticData.DataGridView_Column_BackColor;
            //dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = StaticData.DataGridView_Column_Selection_BackColor;
            #endregion

            dgv.ForeColor = Color.Black;
            dgv.BackgroundColor = BackColor2;

            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);

            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(201, 172, 204);

            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(201, 172, 204);

            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(215, 215, 215);

            dgv.GridColor = BackColor2;

            dgv.Font = new Font(FontFamily, 10);

            dgv.ColumnHeadersHeight = 35;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles = false;

            // Column Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color3;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily, 12);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Booleans
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            dgv.RightToLeft = RightToLeft.Yes;
            dgv.BorderStyle = BorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }
        public static void Set(Control ctrl, params Control[] exeptions)
        {
            foreach (Control item in ctrl.Controls)
            {
                if (exeptions.Contains(item))
                {
                    continue;
                }


                switch (Convert.ToString(item.GetType()).ToLower())
                {
                    case "system.windows.forms":
                        ctrl.BackColor = BackColor1;
                        ctrl.ForeColor = ForeColor1;
                        break;
                    case "gama.frmmaster":
                        ctrl.BackColor = BackColor2;
                        ctrl.ForeColor = ForeColor2;

                        (ctrl as FrmMaster).HeaderforeColor = Color.White;
                        (ctrl as FrmMaster).BorderColor = HeaderColor;
                        break;
                    case "gama.btnsimple":
                    case "gama.btnoption":
                    case "gama.btnsuboption":
                        SetButton(item as Button);
                        break;
                    case "gama.pnlautodesign":
                    case "gama.pnlsimple":
                        Panel pnl = item as Panel;
                        pnl.BackColor = pnl.Parent.BackColor;
                        break;
                    case "system.windows.forms.flowlayoutpanel":
                        FlowLayoutPanel fPnl = item as FlowLayoutPanel;
                        fPnl.BackColor = fPnl.Parent.BackColor;
                        break;
                    case "system.windows.forms.datagridview":
                        SetDataGridView(item as DataGridView);
                        break;
                    case "gama.combosimple":
                        ComboBox combo = item as ComboBox;
                        combo.DropDownStyle = ComboBoxStyle.DropDown;
                        break;
                    case "":
                        break;
                    default:
                        break;
                }
            }

            foreach (Control item in ctrl.Controls)
            {
                if (item.HasChildren)
                {
                    Set(item, exeptions);
                }
            }
        }

        #endregion
        //*************************************
    }
}
