using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WF_Reg_form_Project
{
    class SQLDataAccessHelper1
    {   
            public static int Emplyoee_id;
        public int getemp_id
            {
                get { return Emplyoee_id; }
                set { Emplyoee_id = value; }
            }
        
        public static SqlConnection UserSqlConnection()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            var connection = new SqlConnection(connectionstring);
            connection.Open();
            return connection;
        }

        public int ExecuteNonQuery(string comm)
        {
            int affectedrow = 0;
            using (var connection = SQLDataAccessHelper1.UserSqlConnection())

            using (var command = new SqlCommand(comm, connection))
            {
                affectedrow = command.ExecuteNonQuery();
            }
            return affectedrow;
        }

        public DataSet getDataset(string commandText)
        {
            using (var connection = SQLDataAccessHelper1.UserSqlConnection())

            using (var command = new SqlCommand(commandText, connection))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
        }
        public DataTable getdataread(string commandText)
        {
            using (var connection = SQLDataAccessHelper1.UserSqlConnection())

            using (var command = new SqlCommand(commandText, connection))
            {
                SqlDataReader dr;
                dr = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }

        public int Deptno_Query()
        {
            var conn = SQLDataAccessHelper1.UserSqlConnection();
            using (var cmd = new SqlCommand("SELECT emp.emp_id,dept.deptno FROM emp,dept WHERE emp.deptno = dept.deptno AND emp_id="+Emplyoee_id,conn))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                int Dept_no = int.Parse(dt.Rows[0]["deptno"].ToString().TrimEnd());
                conn.Close();
                return Dept_no;
            }
        }
    }
}

