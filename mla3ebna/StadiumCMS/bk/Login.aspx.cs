using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void lnkLogin_Click(object sender, EventArgs e)
    {
        if (TxtUsername.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('UserName is required');", true);

            return;
        }
        else if (TxtPassword.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password is required');", true);

            return;
        }
        if (CMSUsers.Login(TxtUsername.Text, TxtPassword.Text, "1"))
        {
            CMSUsers.UpdateUserLastLoginDateByID(CMSCurrentUser.MaleabnaCMSUserID, DateTime.Now);

            CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Login", "App Login Start", DateTime.Now, " ", "", "");

            //if (!string.IsNullOrEmpty(Request.QueryString["redirect"]))
            if (Request.QueryString["redirect"] != null && Request.QueryString["redirect"].ToString() != "")
            {
                Response.Redirect(Request.QueryString["redirect"]);
            }

            else
            {
                Response.Redirect("Default.aspx");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Username or Password');", true);

        }
    }
}