
namespace GAMA
{
    partial class FrmStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudent));
            this.btnDetails = new GAMA.BtnSimple();
            this.btnDelete = new GAMA.BtnSimple();
            this.btnAdd = new GAMA.BtnSimple();
            this.btnEdit = new GAMA.BtnSimple();
            this.searchCombo = new GAMA.ComboSimple();
            this.mainLbl = new GAMA.LblSimple();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.BackgroundImage")));
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(188, 491);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(95, 37);
            this.btnDetails.TabIndex = 14;
            this.btnDetails.Text = "جزِییات";
            this.btnDetails.BorderColor = System.Drawing.Color.LightPink;
            this.btnDetails.BorderSize = 1;
            this.btnDetails.BorderRadius = 10;
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(289, 491);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 37);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.BorderColor = System.Drawing.Color.LightPink;
            this.btnDelete.BorderSize = 1;
            this.btnDelete.BorderRadius = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(390, 491);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 37);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.BorderColor = System.Drawing.Color.LightPink;
            this.btnAdd.BorderSize = 1;
            this.btnAdd.BorderRadius = 10;
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
            this.btnEdit.Location = new System.Drawing.Point(491, 491);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 37);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.BorderColor = System.Drawing.Color.LightPink;
            this.btnEdit.BorderSize = 1;
            this.btnEdit.BorderRadius = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(691, 338);
            this.dataGridView1.TabIndex = 10;
            // 
            // FrmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 583);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmStudent";
            this.Text = "کارآموز";
            this.Load += new System.EventHandler(this.FrmStudent_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            //
            //lbl Main
            //
            this.mainLbl.AutoSize = true;
            this.mainLbl.ForeColor = System.Drawing.Color.Black;
            this.mainLbl.Location = new System.Drawing.Point(224, 3);
            this.mainLbl.Name = "mainlbl1";
            this.mainLbl.Font = new System.Drawing.Font("B Nazanin", 14F);
            this.mainLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainLbl.Size = new System.Drawing.Size(161, 32);
            this.mainLbl.Text = "فیلتر بر اساس ... :";
            // 
            // searchCombo
            // 
            this.searchCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchCombo.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.searchCombo.FormattingEnabled = true;
            this.searchCombo.Location = new System.Drawing.Point(3, 3);
            this.searchCombo.Name = "mainCombo1";
            this.searchCombo.Size = new System.Drawing.Size(180, 40);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchCombo);
            this.panel1.Controls.Add(this.mainLbl);
            this.panel1.Location = new System.Drawing.Point(170, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 45);
            this.panel1.TabIndex = 11;
        }

        #endregion

        private BtnSimple btnDetails;
        private BtnSimple btnDelete;
        private BtnSimple btnAdd;
        private BtnSimple btnEdit;
        private ComboSimple searchCombo;
        private LblSimple mainLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}