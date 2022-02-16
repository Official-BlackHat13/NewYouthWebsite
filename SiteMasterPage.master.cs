using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // userMenu.Visible = false;


        if (Session["userid"] == null)
        {
            login.Text = "تسجيل الدخول";
            lnkreg.Text = "تسجيل جديد";
        }
        else
        {
            login.Text = "تسجيل الخروج";
            lnkreg.Text = "الملف الشخصي";

        }
    }

    protected void lnkreg_Click(object sender, EventArgs e)
    {
        if (lnkreg.Text.Equals("تسجيل جديد"))

            Response.Redirect("~/User/Register_AR.aspx");

        else if (lnkreg.Text.Equals("الملف الشخصي"))
        {
            Response.Redirect("~/User/user_Profile.aspx");
        }
    }

    protected void login_Click(object sender, EventArgs e)
    {
        if (login.Text.Equals("تسجيل الخروج"))
        {
            Session.Abandon();
            //Session["userid"] = "";
            login.Text = "الدخول";
            
        }
        else
        {
            Response.Redirect("~/User/login.aspx");

        }
    }
}
