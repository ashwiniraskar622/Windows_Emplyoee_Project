using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Reg_form_Project
{
    public partial class frm_master_form : Form
    {
        int e_id;
        string job_type;
        DataTable dt;
        public frm_master_form()
        {
            InitializeComponent();           
        }

        private void frm_master_form_Load(object sender, EventArgs e)
        {           
            SQLDataAccessHelper1 objdataread = new SQLDataAccessHelper1();
            e_id = objdataread.getemp_id;
            dt = objdataread.getdataread("select emp_id,emp_name,Job_type from emp,Job_master where emp.job_id = Job_master.job_id and emp_id =" + e_id);
            job_type = dt.Rows[0]["Job_type"].ToString().TrimEnd();
        }
        frm_emp_reg obj_emp_reg = new frm_emp_reg();
        private void empRegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (job_type == "HRO")
            {
                this.Hide();
                obj_emp_reg.Show();
            }
            else
            {
                MessageBox.Show("You Will Not Be Able To Access To This Information");
            }
        }

        frm_dept obj_frm_dept = new frm_dept();
        private void departmentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (job_type == "SA")
            {
                this.Hide();
                obj_frm_dept.Show();
            }
            else
            {
                MessageBox.Show("You Will Not Be Able To Access To This Information");
            }
            
        }

        frm_Hobby obj_frm_hobby = new frm_Hobby();
        private void hobbyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (job_type == "SA")
            {
                this.Hide();
                obj_frm_hobby.Show();
            }
            else
            {
                MessageBox.Show("You Will Not Be Able To Access To This Information");
            }
        }

        frm_Job obj_frm_job = new frm_Job();
        private void jobMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (job_type == "SA")
            {
                this.Hide();
                obj_frm_job.Show();
            }
            else
            {
                MessageBox.Show("You Will Not Be Able To Access To This Information");
            }
        }

        frm_Report obj_frm_Report = new frm_Report();
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (job_type == "SACC")
            {
                this.Hide();
                obj_frm_Report.Show();
            }
            else
            {
                MessageBox.Show("You Will Not Be Able To Access To This Information");
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hRMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SQLDataAccessHelper1 objgetdataset = new SQLDataAccessHelper1();
            //var ds = objgetdataset.getDataset("select * from Login_master");
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 obj1 = new SQLDataAccessHelper1();
            int Dept_no = obj1.Deptno_Query();
            //string Job_name = obj1.Jobname_Query();
            if (job_type == "SwdM" && Dept_no == 1)
            {
                frm_manager1 mgr1 = new frm_manager1();
                mgr1.Show();
                this.Hide();
            }
            else
            {
                if (job_type == "AccM" && Dept_no == 2)
                {
                    frm_manager2 mgr2 = new frm_manager2();
                    mgr2.Show();
                    this.Hide();
                }
                else
                {
                    if (job_type == "HrM" && Dept_no == 3)
                    {
                        frm_manager3 mgr3 = new frm_manager3();
                        mgr3.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (job_type == "AdM" && Dept_no == 4)
                        {
                            frm_manager4 mgr4 = new frm_manager4();
                            mgr4.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("You Will Not Be Able To Access To This Information");
                        }
                    }
                }
            }
        }
    }
}
