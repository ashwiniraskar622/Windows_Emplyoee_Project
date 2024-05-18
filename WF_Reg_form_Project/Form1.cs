using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WF_Reg_form_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                frm_master_form objfrm = new frm_master_form();
                DataTable dt = new DataTable();
                SQLDataAccessHelper1 objgetdatareader = new SQLDataAccessHelper1();
                dt = objgetdatareader.getdataread("select * from Login_master where E_username = '" + txtusername.Text + "'AND  E_password = '" + txtPassword.Text + "' ");
                int emp_id = int.Parse(dt.Rows[0]["emp_id"].ToString());
                objgetdatareader.getemp_id = emp_id;


                if (dt.Rows.Count > 0)
                {
                    this.Hide();

                    objfrm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Password");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
