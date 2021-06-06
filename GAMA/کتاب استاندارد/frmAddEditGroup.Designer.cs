
namespace GAMA
{
    partial class FrmAddEditGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditGroup));
            this.btnAdd = new GAMA.BtnSimple();
            this.panel1 = new GAMA.PnlAutoDesign();
            this.mainCombo1 = new GAMA.ComboSimple();
            this.mainTxt1 = new GAMA.TxtSimple();
            this.mainlbl3 = new GAMA.LblSimple();
            this.mainlbl1 = new GAMA.LblSimple();
            this.txtId = new GAMA.TxtSimple();
            this.mainlbl2 = new GAMA.LblSimple();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.ColumnIndex = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(113, 170);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PareName = null;
            this.btnAdd.RowIndex = 0;
            this.btnAdd.Size = new System.Drawing.Size(95, 37);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.ColumnCount = 1;
            this.panel1.ColumnIndex = 0;
            this.panel1.Controls.Add(this.mainCombo1);
            this.panel1.Controls.Add(this.mainTxt1);
            this.panel1.Controls.Add(this.mainlbl3);
            this.panel1.Controls.Add(this.mainlbl1);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.mainlbl2);
            this.panel1.Location = new System.Drawing.Point(30, 33);
            this.panel1.Name = "panel1";
            this.panel1.PareName = null;
            this.panel1.RowCount = 3;
            this.panel1.RowIndex = 0;
            this.panel1.Size = new System.Drawing.Size(330, 131);
            this.panel1.Space = 10;
            this.panel1.TabIndex = 13;
            this.panel1.XSpace = 25;
            this.panel1.YSpace = 5;
            // 
            // mainCombo1
            // 
            this.mainCombo1.ColumnIndex = 1;
            this.mainCombo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainCombo1.Font = new System.Drawing.Font("B Nazanin", 10F);
            this.mainCombo1.FormattingEnabled = true;
            this.mainCombo1.Location = new System.Drawing.Point(12, 48);
            this.mainCombo1.Name = "mainCombo1";
            this.mainCombo1.PareName = null;
            this.mainCombo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainCombo1.RowIndex = 2;
            this.mainCombo1.Size = new System.Drawing.Size(183, 34);
            this.mainCombo1.TabIndex = 19;
            this.mainCombo1.Tag = "نام خوشه";
            // 
            // mainTxt1
            // 
            this.mainTxt1.ColumnIndex = 1;
            this.mainTxt1.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainTxt1.ForeColor = System.Drawing.Color.Black;
            this.mainTxt1.Location = new System.Drawing.Point(12, 88);
            this.mainTxt1.Name = "mainTxt1";
            this.mainTxt1.PareName = null;
            this.mainTxt1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainTxt1.RowIndex = 3;
            this.mainTxt1.Size = new System.Drawing.Size(183, 35);
            this.mainTxt1.TabIndex = 18;
            this.mainTxt1.Tag = "نام گروه";
            this.mainTxt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl3
            // 
            this.mainlbl3.AutoSize = true;
            this.mainlbl3.ColumnIndex = 1;
            this.mainlbl3.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl3.ForeColor = System.Drawing.Color.Black;
            this.mainlbl3.Location = new System.Drawing.Point(257, 88);
            this.mainlbl3.Name = "mainlbl3";
            this.mainlbl3.PareName = "mainTxt1";
            this.mainlbl3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl3.RowIndex = 3;
            this.mainlbl3.Size = new System.Drawing.Size(61, 28);
            this.mainlbl3.TabIndex = 17;
            this.mainlbl3.Text = "نام گروه:";
            // 
            // mainlbl1
            // 
            this.mainlbl1.AutoSize = true;
            this.mainlbl1.ColumnIndex = 1;
            this.mainlbl1.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl1.ForeColor = System.Drawing.Color.Black;
            this.mainlbl1.Location = new System.Drawing.Point(248, 48);
            this.mainlbl1.Name = "mainlbl1";
            this.mainlbl1.PareName = "mainCombo1";
            this.mainlbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl1.RowIndex = 2;
            this.mainlbl1.Size = new System.Drawing.Size(70, 28);
            this.mainlbl1.TabIndex = 14;
            this.mainlbl1.Text = "نام خوشه:";
            // 
            // txtId
            // 
            this.txtId.ColumnIndex = 1;
            this.txtId.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Location = new System.Drawing.Point(12, 7);
            this.txtId.Name = "txtId";
            this.txtId.PareName = null;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.RowIndex = 1;
            this.txtId.Size = new System.Drawing.Size(183, 35);
            this.txtId.TabIndex = 16;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl2
            // 
            this.mainlbl2.AutoSize = true;
            this.mainlbl2.ColumnIndex = 1;
            this.mainlbl2.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl2.ForeColor = System.Drawing.Color.Black;
            this.mainlbl2.Location = new System.Drawing.Point(216, 7);
            this.mainlbl2.Name = "mainlbl2";
            this.mainlbl2.PareName = "txtId";
            this.mainlbl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl2.RowIndex = 1;
            this.mainlbl2.Size = new System.Drawing.Size(102, 28);
            this.mainlbl2.TabIndex = 15;
            this.mainlbl2.Text = "شماره ی ردیف:";
            // 
            // FrmAddEditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 257);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(387, 257);
            this.MinimumSize = new System.Drawing.Size(387, 257);
            this.Name = "FrmAddEditGroup";
            this.Text = "گروه";
            this.Load += new System.EventHandler(this.FrmAddEditGroup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmAddEditGroup_Paint);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BtnSimple btnAdd;
        private PnlAutoDesign panel1;
        private ComboSimple mainCombo1;
        private TxtSimple mainTxt1;
        private LblSimple mainlbl3;
        private LblSimple mainlbl1;
        private TxtSimple txtId;
        private LblSimple mainlbl2;
    }
}