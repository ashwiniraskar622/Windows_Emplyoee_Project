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
    public partial class frm_Job : Form
    {
        int id = 0;
        public frm_Job()
        {
            InitializeComponent();
        }

        private void frm_Job_Load(object sender, EventArgs e)
        {
            fillgridview();
            fillDeptaname();
        }

        private void fillDeptaname()
        {
            SQLDataAccessHelper1 objgetdata = new SQLDataAccessHelper1();
            var ds = objgetdata.getDataset("select * from dept");

            cmbBDept_Name.ValueMember = "deptno";
            cmbBDept_Name.DisplayMember = "dtname";
            cmbBDept_Name.DataSource = ds.Tables[0];
        }
        private void fillgridview()
        {
            SQLDataAccessHelper1 objgetdata = new SQLDataAccessHelper1();
            var ds = objgetdata.getDataset("select * from Job_master");

            dataGridViewJob.DataSource = ds.Tables[0];
        }
        private void cleardata()
        {
            txtName.Text = "";
        }

        private void dataGridViewJob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridViewJob.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dataGridViewJob.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtBJob_Type.Text = dataGridViewJob.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("INSERT INTO Job_master(deptno,job_name,Job_type) Values('"+cmbBDept_Name.SelectedValue+"','" + txtName.Text + "','"+TxtBJob_Type.Text+"')");
            if (result == 1)
            {
                MessageBox.Show("Query execute successfully");
            }
            else
            {
                MessageBox.Show("Query not execute successfully");
            }
            MessageBox.Show("Job Inserted");
            fillgridview();
            cleardata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("UPDATE Job_master SET deptno = '"+cmbBDept_Name.SelectedValue+"', job_name='" + txtName.Text + "',Job_type= '"+TxtBJob_Type.Text+"' where job_id=" + id);
            MessageBox.Show("Job Updated");
            fillgridview();
            cleardata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("Delete  from Job_master Where job_id=" + id);
            MessageBox.Show("Job Deleted");
            fillgridview();
            cleardata();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frm_master_form objmain = new frm_master_form();
            this.Hide();
            objmain.Show();
        }
    }
}
