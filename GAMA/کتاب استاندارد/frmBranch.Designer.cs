
namespace GAMA
{
    partial class FrmBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBranch));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new GAMA.BtnSimple();
            this.btnAdd = new GAMA.BtnSimple();
            this.btnEdit = new GAMA.BtnSimple();
            this.btnDetails = new GAMA.BtnSimple();
            this.btnAddGroup = new GAMA.BtnSimple();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(623, 307);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(294, 413);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 37);
            this.btnDelete.TabIndex = 4;
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
            this.btnAdd.Location = new System.Drawing.Point(395, 413);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 37);
            this.btnAdd.TabIndex = 3;
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
            this.btnEdit.Location = new System.Drawing.Point(496, 413);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 37);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.BackgroundImage")));
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(193, 413);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(95, 37);
            this.btnDetails.TabIndex = 5;
            this.btnDetails.Text = "جزِییات";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.BtnDetails_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.BackgroundImage")));
            this.btnAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddGroup.FlatAppearance.BorderSize = 0;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnAddGroup.ForeColor = System.Drawing.Color.White;
            this.btnAddGroup.Location = new System.Drawing.Point(92, 413);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(95, 37);
            this.btnAddGroup.TabIndex = 6;
            this.btnAddGroup.Text = "ثبت گروه";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.BtnAddGroup_Click);
            // 
            // FrmBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(675, 497);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBranch";
            this.Text = "خوشه ها";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBranch_FormClosed);
            this.Load += new System.EventHandler(this.FrmBranch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBranch_Paint);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnAddGroup, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BtnSimple btnEdit;
        private BtnSimple btnAdd;
        private BtnSimple btnDelete;
        private BtnSimple btnDetails;
        private BtnSimple btnAddGroup;
    }
}