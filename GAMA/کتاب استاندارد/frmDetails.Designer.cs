
namespace GAMA
{
    partial class frmDetails
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
            this.panel1 = new GAMA.PnlAutoDesign();
            this.txtTime = new GAMA.TxtSimple();
            this.mainlbl3 = new GAMA.LblSimple();
            this.txtDate = new GAMA.TxtSimple();
            this.mainlbl1 = new GAMA.LblSimple();
            this.txtName = new GAMA.TxtSimple();
            this.mainlbl2 = new GAMA.LblSimple();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.mainlbl3);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.mainlbl1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.mainlbl2);
            this.panel1.Location = new System.Drawing.Point(9, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 128);
            this.panel1.TabIndex = 12;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.txtTime.ForeColor = System.Drawing.Color.Black;
            this.txtTime.Location = new System.Drawing.Point(7, 85);
            this.txtTime.Name = "txtTime";
            this.txtTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTime.Size = new System.Drawing.Size(183, 35);
            this.txtTime.TabIndex = 12;
            this.txtTime.Tag = "نام خوشه";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl3
            // 
            this.mainlbl3.AutoSize = true;
            this.mainlbl3.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl3.ForeColor = System.Drawing.Color.Black;
            this.mainlbl3.Location = new System.Drawing.Point(238, 88);
            this.mainlbl3.Name = "mainlbl3";
            this.mainlbl3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl3.Size = new System.Drawing.Size(79, 28);
            this.mainlbl3.TabIndex = 11;
            this.mainlbl3.Text = "ساعت ثبت:";
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Location = new System.Drawing.Point(7, 44);
            this.txtDate.Name = "txtDate";
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDate.Size = new System.Drawing.Size(183, 35);
            this.txtDate.TabIndex = 10;
            this.txtDate.Tag = "نام خوشه";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl1
            // 
            this.mainlbl1.AutoSize = true;
            this.mainlbl1.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl1.ForeColor = System.Drawing.Color.Black;
            this.mainlbl1.Location = new System.Drawing.Point(244, 47);
            this.mainlbl1.Name = "mainlbl1";
            this.mainlbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl1.Size = new System.Drawing.Size(73, 28);
            this.mainlbl1.TabIndex = 7;
            this.mainlbl1.Text = "تاریخ ثبت:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(7, 3);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(183, 35);
            this.txtName.TabIndex = 9;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mainlbl2
            // 
            this.mainlbl2.AutoSize = true;
            this.mainlbl2.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.mainlbl2.ForeColor = System.Drawing.Color.Black;
            this.mainlbl2.Location = new System.Drawing.Point(219, 6);
            this.mainlbl2.Name = "mainlbl2";
            this.mainlbl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainlbl2.Size = new System.Drawing.Size(98, 28);
            this.mainlbl2.TabIndex = 8;
            this.mainlbl2.Text = "نام ثبت کننده:";
            // 
            // frmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 186);
            this.Controls.Add(this.panel1);
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDetails";
            this.Text = "جزییات";
            this.Load += new System.EventHandler(this.FrmDetails_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PnlAutoDesign panel1;
        private TxtSimple txtTime;
        private LblSimple mainlbl3;
        private TxtSimple txtDate;
        private LblSimple mainlbl1;
        private TxtSimple txtName;
        private LblSimple mainlbl2;
    }
}