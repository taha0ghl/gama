
namespace GAMA
{
    partial class FrmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroup));
            this.mainlbl1 = new GAMA.LblSimple();
            this.mainCombo1 = new GAMA.ComboSimple();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDetails = new GAMA.BtnSimple();
            this.btnDelete = new GAMA.BtnSimple();
            this.btnAdd = new GAMA.BtnSimple();
            this.btnEdit = new GAMA.BtnSimple();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddCourse = new GAMA.BtnSimple();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainlbl1
            // 
            this.mainlbl1.AutoSize = true;
            this.mainlbl1.Font = new System.Drawing.Font("B Nazanin", 13F);
            this.mainlbl1.ForeColor = System.Drawing.Color.Black;
            this.mainlbl1.Location = new System.Drawing.Point(224, 3);
            this.mainlbl1.Name = "mainlbl1";
            this.mainlbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl1.Size = new System.Drawing.Size(161, 32);
            this.mainlbl1.TabIndex = 1;
            this.mainlbl1.Text = "فیلتر بر اساس خوشه :";
            // 
            // mainCombo1
            // 
            this.mainCombo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainCombo1.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.mainCombo1.FormattingEnabled = true;
            this.mainCombo1.Location = new System.Drawing.Point(3, 3);
            this.mainCombo1.Name = "mainCombo1";
            this.mainCombo1.Size = new System.Drawing.Size(189, 37);
            this.mainCombo1.TabIndex = 2;
            this.mainCombo1.SelectedIndexChanged += new System.EventHandler(this.MainCombo1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(691, 338);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.BackgroundImage")));
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(186, 484);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(95, 37);
            this.btnDetails.TabIndex = 9;
            this.btnDetails.Text = "جزِییات";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.BtnDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(287, 484);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 37);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(388, 484);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 37);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(489, 484);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 37);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainCombo1);
            this.panel1.Controls.Add(this.mainlbl1);
            this.panel1.Location = new System.Drawing.Point(169, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 43);
            this.panel1.TabIndex = 10;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCourse.BackgroundImage")));
            this.btnAddCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCourse.FlatAppearance.BorderSize = 0;
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnAddCourse.ForeColor = System.Drawing.Color.White;
            this.btnAddCourse.Location = new System.Drawing.Point(85, 484);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(95, 37);
            this.btnAddCourse.TabIndex = 11;
            this.btnAddCourse.Text = "ثبت دوره";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.BtnAddCourse_Click);
            // 
            // FrmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(745, 583);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridView1);
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmGroup";
            this.Text = "گروه ها";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGroup_FormClosed);
            this.Load += new System.EventHandler(this.FrmGroup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmGroup_Paint);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnAddCourse, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LblSimple mainlbl1;
        private ComboSimple mainCombo1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BtnSimple btnDetails;
        private BtnSimple btnDelete;
        private BtnSimple btnAdd;
        private BtnSimple btnEdit;
        private System.Windows.Forms.Panel panel1;
        private BtnSimple btnAddCourse;
    }
}