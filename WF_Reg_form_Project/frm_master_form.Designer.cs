
namespace WF_Reg_form_Project
{
    partial class frm_master_form
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hRMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empRegToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hobbyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hRMasterToolStripMenuItem,
            this.accountantToolStripMenuItem,
            this.managerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // hRMasterToolStripMenuItem
            // 
            this.hRMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empRegToolStripMenuItem,
            this.departmentMasterToolStripMenuItem,
            this.hobbyMasterToolStripMenuItem,
            this.jobMasterToolStripMenuItem});
            this.hRMasterToolStripMenuItem.Name = "hRMasterToolStripMenuItem";
            this.hRMasterToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.hRMasterToolStripMenuItem.Text = "HR_Master";
            this.hRMasterToolStripMenuItem.Click += new System.EventHandler(this.hRMasterToolStripMenuItem_Click);
            // 
            // empRegToolStripMenuItem
            // 
            this.empRegToolStripMenuItem.Name = "empRegToolStripMenuItem";
            this.empRegToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.empRegToolStripMenuItem.Text = "Emp";
            this.empRegToolStripMenuItem.Click += new System.EventHandler(this.empRegToolStripMenuItem_Click);
            // 
            // departmentMasterToolStripMenuItem
            // 
            this.departmentMasterToolStripMenuItem.Name = "departmentMasterToolStripMenuItem";
            this.departmentMasterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.departmentMasterToolStripMenuItem.Text = "Dept";
            this.departmentMasterToolStripMenuItem.Click += new System.EventHandler(this.departmentMasterToolStripMenuItem_Click);
            // 
            // hobbyMasterToolStripMenuItem
            // 
            this.hobbyMasterToolStripMenuItem.Name = "hobbyMasterToolStripMenuItem";
            this.hobbyMasterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.hobbyMasterToolStripMenuItem.Text = "Emp_hobbies";
            this.hobbyMasterToolStripMenuItem.Click += new System.EventHandler(this.hobbyMasterToolStripMenuItem_Click);
            // 
            // jobMasterToolStripMenuItem
            // 
            this.jobMasterToolStripMenuItem.Name = "jobMasterToolStripMenuItem";
            this.jobMasterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.jobMasterToolStripMenuItem.Text = "Job_Master";
            this.jobMasterToolStripMenuItem.Click += new System.EventHandler(this.jobMasterToolStripMenuItem_Click);
            // 
            // accountantToolStripMenuItem
            // 
            this.accountantToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem});
            this.accountantToolStripMenuItem.Name = "accountantToolStripMenuItem";
            this.accountantToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.accountantToolStripMenuItem.Text = "Accountant";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // managerToolStripMenuItem
            // 
            this.managerToolStripMenuItem.Name = "managerToolStripMenuItem";
            this.managerToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.managerToolStripMenuItem.Text = "Manager";
            this.managerToolStripMenuItem.Click += new System.EventHandler(this.managerToolStripMenuItem_Click);
            // 
            // frm_master_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_master_form";
            this.Text = "frm_master_form";
            this.Load += new System.EventHandler(this.frm_master_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hRMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empRegToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hobbyMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerToolStripMenuItem;
    }
}