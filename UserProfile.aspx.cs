using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    public partial class UserProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                if (checkUserExists())
                {
                    //SqlCommand cmd = new SqlCommand("Insert into emp_detail" +
                    //    "(username,fullName,dateOfBirth,contactNo,emailId,state,city,pincode,address)" +
                    //    " values (@username,@fullName,@dateOfBirth,@contactNo,@emailId,@state,@city,@pincode,@address)", con);

                    //cmd.Parameters.AddWithValue("@username", Session["username"]);
                    //cmd.Parameters.AddWithValue("@fullName", TextBox1.Text.Trim());
                    //cmd.Parameters.AddWithValue("@dateOfBirth", TextBox2.Text.Trim());
                    //cmd.Parameters.AddWithValue("@contactNo", TextBox3.Text.Trim());
                    //cmd.Parameters.AddWithValue("@emailId", TextBox4.Text.Trim());
                    //cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    //cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                    //cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                    //cmd.Parameters.AddWithValue("@address", TextBox7.Text.Trim());
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    Response.Write("<script> alert ('Updated Successfully')</script>");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into emp_detail" +
                        "(username,fullName,dateOfBirth,contactNo,emailId,state,city,pincode,address)" +
                        " values (@username,@fullName,@dateOfBirth,@contactNo,@emailId,@state,@city,@pincode,@address)", con);

                    cmd.Parameters.AddWithValue("@username", Session["username"]);
                    cmd.Parameters.AddWithValue("@fullName", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateOfBirth", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@contactNo", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@emailId", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", TextBox7.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script> alert ('Inserted Successfully')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert ('" + ex.Message + "')</script>");
            }
        }
        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from emp_detail where username='" + Session["username"] + "'", con);
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
       
    }
}