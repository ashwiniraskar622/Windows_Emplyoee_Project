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
    public partial class frm_Hobby : Form
    {
        int id;
        public frm_Hobby()
        {
            InitializeComponent();

        }

        private void frm_Hobby_Load(object sender, EventArgs e)
        {
            filldatagridview();
        }
        private void filldatagridview()
        {

            SQLDataAccessHelper1 objgetdata = new SQLDataAccessHelper1();
            var ds = objgetdata.getDataset("select * from emp_hobbies");

            dataGridView1.DataSource = ds.Tables[0];
        }
        private void cleardata()
        {
            txtName.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = 0;

            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("INSERT INTO emp_hobbies(hobbi_name)" + " values  ('" + txtName.Text + "')");
            if (result == 1)
            {
                MessageBox.Show("Query execute successfully");
            }
            else
            {
                MessageBox.Show("Query not execute successfully");
            }
            MessageBox.Show("Hobby Inserted");
            filldatagridview();
            cleardata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery("UPDATE emp_hobbies SET hobbi_name = '" + txtName.Text + "' where hobbi_id = " + id);
            MessageBox.Show("Hobby Updated");
            filldatagridview();
            cleardata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecute = new SQLDataAccessHelper1();
            int result = objExecute.ExecuteNonQuery(" delete from emp_hobbies where hobbi_id = " + id);
            MessageBox.Show("Hobby Deleted");
            filldatagridview();
            cleardata();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frm_master_form objmain = new frm_master_form();
            this.Hide();
            objmain.Show();
        }
    }
}

