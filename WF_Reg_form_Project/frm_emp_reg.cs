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
    public partial class frm_emp_reg : Form
    {
        int ID = 0;
        int Emp_id = 0;
        //int gender_id = 0;
        string gender;
        int e_h_id = 0;
        string dt;
       int jb_id = 0;
       // int log_id = 0;
        public frm_emp_reg()
        {
            InitializeComponent();
        }

        private void frm_emp_reg_Load(object sender, EventArgs e)
        {
            fillcomboDept_name();
            fillgridview();
            checklistbox_Hobbi();
        }
        private void fillcomboDept_name()
        {
            try
            {
                DataSet ds = new DataSet();
                SQLDataAccessHelper1 objSqlDataReader1 = new SQLDataAccessHelper1();
                ds = objSqlDataReader1.getDataset("Select * from dept");

                cmbDept_Name.ValueMember = "deptno";
                cmbDept_Name.DisplayMember = "dtname";
                cmbDept_Name.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               // ds.d
            }
        }
            private void fillgridview()
            {
                SQLDataAccessHelper1 objsQLDataAccessHelper1 = new SQLDataAccessHelper1();
                var ds = objsQLDataAccessHelper1.getDataset("select emp.emp_id, emp_name,[address], hiredate, emp.deptno, gender,salary,Email_id,emp.E_password,Mobile_no,emp.job_id,dtname,dloc,emp_details.hobbi_id,emp_details_id,emp_hobbies.hobbi_name " +
                                                   "from emp,dept,emp_details,emp_hobbies,job_master,Login_master where emp.deptno = dept.deptno AND emp.emp_id = emp_details.emp_id AND " +
                                                   "emp_details.hobbi_id = emp_hobbies.hobbi_id AND emp.job_id = job_master.job_id and emp.emp_id = Login_master.emp_id and job_master.job_id = Login_master.job_id ORDER BY emp_id");

                dataGridView1.DataSource = ds.Tables[0];
            }
        private void checklistbox_Hobbi()
        {
            {
                SQLDataAccessHelper1 objsQLDataAccessHelper1 = new SQLDataAccessHelper1();
                var ds = objsQLDataAccessHelper1.getDataset("select * from emp_hobbies");

                ckblistHobbi.DataSource = ds.Tables[0];
                ckblistHobbi.ValueMember = "hobbi_id";
                ckblistHobbi.DisplayMember = "hobbi_name";
            }
        }
        private void cleardata()
        {

            txbName.Text = "";
            txbAdrress.Text = "";
            txtBEmail.Text = "";
            txtBPassword.Text = "";
            txtBPhone_no.Text = "";
            txtBSalary.Text = "";
            cmbDept_Name.SelectedValue = 0;
            cmbBJob.SelectedValue = 0;
            cmbGender.SelectedValue = 0;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Emp_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txbName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txbAdrress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            dt = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime date1 = DateTime.Parse(dt, System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker1.Value = date1;

            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            cmbDept_Name.SelectedIndex = ID - 1;

            //gender_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            //cmbGender.SelectedIndex = gender_id - 1;

            txtBSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtBEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtBPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtBPhone_no.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

            jb_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
            //log_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString());
            e_h_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString());
            //ckblistHobbi.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecuteNonQuery1 = new SQLDataAccessHelper1();
            int result1 = objExecuteNonQuery1.ExecuteNonQuery("INSERT INTO emp (emp_name,address,hiredate,deptno,gender,salary,Email_id,E_password,Mobile_no,job_id)" +
                                "values  ('" + txbName.Text + "','" + txbAdrress.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + cmbDept_Name.SelectedValue + "','" + gender + "'," +
                                " '" + txtBSalary.Text + "','" + txtBEmail.Text + "','" + txtBPassword.Text + "','" + txtBPhone_no.Text + "','" + cmbBJob.SelectedValue + "')");

            MessageBox.Show("Record Insert Successfully");

            // first method to insert hobbi to freshly inserted  record

            foreach (object item in ckblistHobbi.CheckedItems)
            {
                string message = "";

                DataRowView row = item as DataRowView;         //datarowview select checked rows
                message += "Name : " + row["hobbi_name"];
                message += Environment.NewLine;                //next line
                message += "ID: " + row["hobbi_id"];
                message += Environment.NewLine;
                message += Environment.NewLine;
                MessageBox.Show(message);
                
                SQLDataAccessHelper1 objsQLDataAccessHelper1 = new SQLDataAccessHelper1();
                var ds = objsQLDataAccessHelper1.getDataset(" select emp_id, emp_name from emp where emp_name = '" + txbName.Text + "'");

                SQLDataAccessHelper1 objExecuteNonQuery2 = new SQLDataAccessHelper1();
                int rseult2 = objExecuteNonQuery2.ExecuteNonQuery("insert into emp_details (hobbi_id,emp_id)" + "values ('" + row["hobbi_id"] + "' , '" + ds.Tables[0].Rows[0]["emp_id"] + "' ) ");

            }
            MessageBox.Show("Hobbies Inserted");

            SQLDataAccessHelper1 objsQLDataAccessHelper2 = new SQLDataAccessHelper1();
            var ds1 = objsQLDataAccessHelper2.getDataset(" select emp_id,emp_name,job_id from emp where emp_name = '" + txbName.Text + "'");

            SQLDataAccessHelper1 objExecuteNonQuery3 = new SQLDataAccessHelper1();
            int reult3 = objExecuteNonQuery3.ExecuteNonQuery("insert into Login_master (E_username,E_password,job_id,emp_id)" + "values ('" + txtBEmail.Text + "','" + txtBPassword.Text + "','"+ ds1.Tables[0].Rows[0]["job_id"] +"','"+ ds1.Tables[0].Rows[0]["emp_id"]+"')");

            MessageBox.Show("Insert Login_master Username,Password & Job_id");

            cleardata();
            fillgridview();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gender = cmbGender.GetItemText(cmbGender.SelectedItem);
            SQLDataAccessHelper1 objExecuteNonQuery1 = new SQLDataAccessHelper1();
            int reult1 = objExecuteNonQuery1.ExecuteNonQuery(" UPDATE emp SET emp_name = '" + txbName.Text + "',address = '"
                                            + txbAdrress.Text + "',hiredate = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                                            "',deptno  = '" + cmbDept_Name.SelectedValue + "',gender ='" + gender + "',salary = '" + txtBSalary.Text + "'," +
                                            "Email_id='" + txtBEmail.Text + "',E_password = '" + txtBPassword.Text + "',Mobile_no = '" + txtBPhone_no.Text + "',job_id='"+cmbBJob.SelectedValue+"' where emp_id = " + Emp_id);

            MessageBox.Show("Record Update successfully");

            SQLDataAccessHelper1 objsQLDataAccessHelper1 = new SQLDataAccessHelper1();
            var ds = objsQLDataAccessHelper1.getDataset(" delete from emp_details where emp_id = " + Emp_id);

            {
                //first method to update hobbi to freshly updeted recod 
                foreach (object item in ckblistHobbi.CheckedItems)
                {

                    string message = "";

                    DataRowView row = item as DataRowView;         //datarowview select checked rows
                    message += "Name : " + row["hobbi_name"];
                    message += Environment.NewLine;                //next line
                    message += "ID: " + row["hobbi_id"];
                    message += Environment.NewLine;
                    message += Environment.NewLine;

                    MessageBox.Show(message);
                    SQLDataAccessHelper1 objsQLDataAccessHelper5 = new SQLDataAccessHelper1();
                    var ds1 = objsQLDataAccessHelper5.getDataset("select emp_id, emp_name from emp where emp_name = '" + txbName.Text + "'");

                    SQLDataAccessHelper1 objExecuteNonQuery2 = new SQLDataAccessHelper1();
                    var ds2 = objExecuteNonQuery2.getDataset("insert into emp_details (hobbi_id,emp_id)" + "values ('" + row["hobbi_id"] + "' , '" + ds1.Tables[0].Rows[0]["emp_id"] + "' )");

                }
                MessageBox.Show("Hobbies Updated");

                SQLDataAccessHelper1 objsQLDataAccessHelper2 = new SQLDataAccessHelper1();
                var ds3 = objsQLDataAccessHelper2.getDataset(" select emp_id,emp_name,job_id from emp where emp_name = '" + txbName.Text + "'");

                SQLDataAccessHelper1 objExecuteNonQuery3 = new SQLDataAccessHelper1();
                int reult3 = objExecuteNonQuery3.ExecuteNonQuery("Update Login_master set E_username ='"+txtBEmail.Text+"', E_password='"+ txtBPassword.Text+"',job_id = '"+ds3.Tables[0].Rows[0]["job_id"]+"' where emp_id = '"+ds3.Tables[0].Rows[0]["emp_id"]+"' and emp_id ="+Emp_id);

                MessageBox.Show("Update Login_master Username,Emp_id,Password & Job_id");
            }
            cleardata();
            fillgridview();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objsQLDataAccessHelper2 = new SQLDataAccessHelper1();
            var ds3 = objsQLDataAccessHelper2.getDataset(" select emp_id,emp_name,job_id from emp where emp_name = '" + txbName.Text + "'");

            SQLDataAccessHelper1 objExecuteNonQuery3 = new SQLDataAccessHelper1();
            int reult3 = objExecuteNonQuery3.ExecuteNonQuery("delete from Login_master where emp_id = '" + ds3.Tables[0].Rows[0]["emp_id"] + "' ");
            MessageBox.Show("Delete  username,password and job_id");

            SQLDataAccessHelper1 objExecuteNonQuery1 = new SQLDataAccessHelper1();
            int result1 = objExecuteNonQuery1.ExecuteNonQuery("Delete from emp where emp_id = " + Emp_id);

            MessageBox.Show("Record Deleted Successfully");

            //first method to update hobbi to freshly updeted recod 
            foreach (object item in ckblistHobbi.CheckedItems)
            {

                DataRowView row = item as DataRowView;

                SQLDataAccessHelper1 objsQLDataAccessHelper1 = new SQLDataAccessHelper1();
                var ds = objsQLDataAccessHelper1.getDataset("select emp_id,emp_name from emp where emp_name = '" + txbName.Text + "'");

                SQLDataAccessHelper1 objExecuteNonQuery2 = new SQLDataAccessHelper1();
                int result2 = objExecuteNonQuery1.ExecuteNonQuery("delete from emp_details where emp_id =" + e_h_id);

            }
            MessageBox.Show("Hobbies deleted");
            

            cleardata();
            fillgridview();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            frm_master_form objmain = new frm_master_form();
            this.Hide();
            objmain.Show();
        }
        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender = cmbGender.GetItemText(cmbGender.SelectedItem);
        }

        private void cmbDept_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLDataAccessHelper1 objExecuteNonQuery2 = new SQLDataAccessHelper1();
            var ds1 = objExecuteNonQuery2.getDataset("select * from dept,Job_master where dept.deptno = job_master.deptno and dept.deptno = '" + cmbDept_Name.SelectedValue + "'");

            cmbBJob.ValueMember = "job_id";
            cmbBJob.DisplayMember = "job_name";
            cmbBJob.DataSource = ds1.Tables[0];
        }
    }
}


