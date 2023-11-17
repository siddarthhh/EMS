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
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void sendMail()
        {
            try
            {
                MailMessage message = new MailMessage("sid9790149@gmail.com", "sid9790149@gmail.com", "hi", "dummy mail");
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("sid9790149@gmail.com","1234%^&*");

                client.Send(message);
                Response.Write("<script> alert ('Email sent')</script>");
            }
            catch (Exception ex) { Response.Write("<script> alert ('" + ex.Message + "')</script>"); }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from login_table where username='"+TextBox1.Text.Trim()+"' AND password = '"+TextBox2.Text.Trim()+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Response.Write("<script> alert ('Login Successful');</script>");
                       
                            Session["fullname"] = dr.GetValue(0).ToString();
                            Session["username"] = dr.GetValue(1).ToString();
                            Session["role"] = dr.GetValue(3).ToString();
                       
                    }
                    sendMail();
                    //Response.Redirect("homepage.aspx");

                }
                else
                {
                    Response.Write("<script> alert ('failed') </script>");
                }
            }
            catch(Exception ex ) {
                Response.Write("<script> alert ('" + ex.Message + "')</script>");
            }
        }
    }
}