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
    public partial class frm_dept : Form
    {
        int dept_id = 0;
        public frm_dept()
        {
            InitializeComponent();
        }

        private void frm_dept_Load(object sender, EventArgs e)
        {
            filldatagridview();
        }
        private void filldatagridview()
        {

            SQLDataAccessHelper1 objgetdata = new SQLDataAccessHelper1();
            var ds = objgetdata.getDataset("select * from dept");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dept_id = 0;

            txtDeptName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDeptLoc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dept_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        private void cleardata()
        {
            txtDeptLoc.Text = "";
            txtDeptName.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("INSERT INTO dept (dtname ,dloc)" + " Values ('" + txtDeptName.Text + "','" + txtDeptLoc.Text + "')");
            if (result == 1)
            {
                MessageBox.Show("Query execute successfully");
            }
            else
            {
                MessageBox.Show("Query not execute successfully");
            }
            MessageBox.Show("Department Inserted");
            cleardata();
            filldatagridview();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("UPDATE dept SET dtname = '" + txtDeptName.Text + "',dloc = '" + txtDeptLoc.Text + "' where  deptno = " + dept_id);
            MessageBox.Show("Department Updated");
            cleardata();
            filldatagridview();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("delete  from dept where deptno = " + dept_id);
            MessageBox.Show("Department Deleted");
            cleardata();
            filldatagridview();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frm_master_form objmain = new frm_master_form();
            this.Hide();
            objmain.Show();
        }
    }
}
