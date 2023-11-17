using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void Button1_Click1(object sender, EventArgs e)
        {
            if(checkUserExists()) {
                Response.Write("<script> alert ('UserName already exist')</script>");
            }
            else
            {
                signUpNewUser();
              
            }
        }

       

        bool checkUserExists() {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from login_table" +
                    " where username='"+TextBox2.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); 
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                { return true; }
                else
                { return false; }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "')</script>");
                return false;
            }
        }
        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into login_table(FullName,username,password,role)" +
                    "values (@FullName,@username,@password,@role)", con);

                cmd.Parameters.AddWithValue("@FullName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@username", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@role", DropDownList1.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert ('Employee added successfully')</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "')</script>");
            }
        }
    }
}