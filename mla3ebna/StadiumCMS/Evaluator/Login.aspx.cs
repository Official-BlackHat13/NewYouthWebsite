using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluator_Login : System.Web.UI.Page
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
        if (EvalUsers.Login(TxtUsername.Text.Trim(), TxtPassword.Text.Trim()))
        {
            // CMSUserActivityLog.UpdateUserLastLoginDateByID(CMSCurrentUser.MaleabnaCMSUserID, DateTime.Now);

           // CMSUserActivityLog.CreateUserActivityLog(CMSCurrentUser.MaleabnaCMSUserID, CMSCurrentUser.MaleabnaCMSName, "Login", "App Login Start", DateTime.Now, " ", "", "");
            string str = Session["MaleabnaEvalUserType"].ToString(); 
           
            if (Request.QueryString["redirect"] != null && Request.QueryString["redirect"].ToString() != "")
            {
               

                if (Session["MaleabnaEvalUserType"].ToString().Trim() == "User")
                    Response.Redirect("Eval_Stadium.aspx", false);
                else
                {
                    Response.Redirect(Request.QueryString["redirect"]);
                }
                
            }

            else
            {
                if (Session["MaleabnaEvalUserType"].ToString().Trim() == "User")
                    Response.Redirect("Eval_Stadium.aspx", false);
                else
                {
                    Response.Redirect("Manage_EvalStadium.aspx",false);
                }
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Username or Password');", true);

        }
    }
}