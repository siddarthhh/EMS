using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace EmployeeManagementSystem
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData1();
            loadData();
        }
        void loadData1()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from login_table", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                adapter.Fill(dt);
                GridView2.DataSource = dt.Tables[0];
                GridView2.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
        void loadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from emp_detail", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                adapter.Fill(dt);
                GridView1.DataSource = dt.Tables[0];
                GridView1.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from login_table where username='" + TextBox1.Text.Trim() + "'", con);
                SqlCommand cmd1 = new SqlCommand("DELETE from emp_detail where username='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();

            }
            catch { }
        }
    }
}