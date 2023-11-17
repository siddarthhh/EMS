using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = false;
                    LinkButton4.Visible = false;
                    LinkButton5.Visible = false;
                    LinkButton6.Visible = false;
                }
                else if (Session["role"].Equals("employee"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = true;
                    LinkButton4.Visible = true;
                    LinkButton4.Text="Hello " + Session["fullname"].ToString()+"( Employee)";
                    LinkButton5.Visible = false;
                    LinkButton6.Visible = true;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = true;
                    LinkButton3.Visible = true;
                    LinkButton4.Visible = true;
                    LinkButton4.Text = "Hello " + Session["fullname"].ToString()+"( admin)";
                    LinkButton5.Visible = true;
                    LinkButton6.Visible = false;
                }
            }
            catch (Exception ex) 
            {  }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["fullname"] = "";
            Session["username"] = "";
            Session["role"] = "";
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
           Response.Redirect("EmployeeManagement.aspx");
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("employee"))
            {
                Response.Redirect("UserProfile.aspx");
            }
        }
    }
}