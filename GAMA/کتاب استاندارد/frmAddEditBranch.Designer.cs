
namespace GAMA
{
    partial class FrmAddEditBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditBranch));
            this.btnAdd = new GAMA.BtnSimple();
            this.panel1 = new GAMA.PnlAutoDesign();
            this.txtName = new GAMA.TxtSimple();
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
            this.btnAdd.Location = new System.Drawing.Point(128, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PareName = null;
            this.btnAdd.RowIndex = 0;
            this.btnAdd.Size = new System.Drawing.Size(95, 37);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.ColumnCount = 1;
            this.panel1.ColumnIndex = 0;
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.mainlbl1);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.mainlbl2);
            this.panel1.Location = new System.Drawing.Point(9, 34);
            this.panel1.Name = "panel1";
            this.panel1.PareName = null;
            this.panel1.RowCount = 2;
            this.panel1.RowIndex = 0;
            this.panel1.Size = new System.Drawing.Size(359, 100);
            this.panel1.Space = 10;
            this.panel1.TabIndex = 12;
            this.panel1.XSpace = 25;
            this.panel1.YSpace = 5;
            // 
            // txtName
            // 
            this.txtName.ColumnIndex = 1;
            this.txtName.Font = new System.Drawing.Font("B Nazanin", 10.2F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(32, 53);
            this.txtName.Name = "txtName";
            this.txtName.PareName = null;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.RowIndex = 2;
            this.txtName.Size = new System.Drawing.Size(183, 33);
            this.txtName.TabIndex = 14;
            this.txtName.Tag = "نام خوشه";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl1
            // 
            this.mainlbl1.AutoSize = true;
            this.mainlbl1.ColumnIndex = 1;
            this.mainlbl1.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl1.ForeColor = System.Drawing.Color.Black;
            this.mainlbl1.Location = new System.Drawing.Point(224, 53);
            this.mainlbl1.Name = "mainlbl1";
            this.mainlbl1.PareName = "txtName";
            this.mainlbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl1.RowIndex = 2;
            this.mainlbl1.Size = new System.Drawing.Size(70, 28);
            this.mainlbl1.TabIndex = 11;
            this.mainlbl1.Text = "نام خوشه:";
            // 
            // txtId
            // 
            this.txtId.ColumnIndex = 1;
            this.txtId.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtId.ForeColor = System.Drawing.Color.Black;
            this.txtId.Location = new System.Drawing.Point(32, 14);
            this.txtId.Name = "txtId";
            this.txtId.PareName = null;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.RowIndex = 1;
            this.txtId.Size = new System.Drawing.Size(183, 33);
            this.txtId.TabIndex = 13;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl2
            // 
            this.mainlbl2.AutoSize = true;
            this.mainlbl2.ColumnIndex = 1;
            this.mainlbl2.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl2.ForeColor = System.Drawing.Color.Black;
            this.mainlbl2.Location = new System.Drawing.Point(224, 14);
            this.mainlbl2.Name = "mainlbl2";
            this.mainlbl2.PareName = "txtId";
            this.mainlbl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl2.RowIndex = 1;
            this.mainlbl2.Size = new System.Drawing.Size(102, 28);
            this.mainlbl2.TabIndex = 12;
            this.mainlbl2.Text = "شماره ی ردیف:";
            // 
            // FrmAddEditBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(387, 199);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(387, 199);
            this.MinimumSize = new System.Drawing.Size(387, 199);
            this.Name = "FrmAddEditBranch";
            this.Text = "خوشه";
            this.Load += new System.EventHandler(this.FrmAddEditBranch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmAddEditBranch_Paint);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BtnSimple btnAdd;
        private PnlAutoDesign panel1;
        private TxtSimple txtName;
        private LblSimple mainlbl1;
        private TxtSimple txtId;
        private LblSimple mainlbl2;
    }
}