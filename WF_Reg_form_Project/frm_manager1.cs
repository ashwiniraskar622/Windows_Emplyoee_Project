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
    public partial class frm_manager1 : Form
    {
        public frm_manager1()
        {
            InitializeComponent();
        }

        private void frm_manager1_Load(object sender, EventArgs e)
        {
            fillgridview();
        }
        private void fillgridview()
        {
            SQLDataAccessHelper1 objsQLDataAccessHelper1 = new SQLDataAccessHelper1();
            var dt = objsQLDataAccessHelper1.getdataread("select emp.emp_id, emp_name,[address], hiredate, emp.deptno, gender,salary,Email_id,emp.E_password,Mobile_no,emp.job_id,dtname,dloc,emp_details.hobbi_id,emp_details_id,emp_hobbies.hobbi_name " +
                                                   "from emp,dept,emp_details,emp_hobbies,job_master,Login_master where emp.deptno = dept.deptno AND emp.emp_id = emp_details.emp_id AND " +
                                                   "emp_details.hobbi_id = emp_hobbies.hobbi_id AND emp.job_id = job_master.job_id and emp.emp_id = Login_master.emp_id and job_master.job_id = Login_master.job_id and dept.deptno='"+ objsQLDataAccessHelper1.Deptno_Query()+ "' ORDER BY emp_id");
            dataGridView1.DataSource = dt;
        }
    }
}
