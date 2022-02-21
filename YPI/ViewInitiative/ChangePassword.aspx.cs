using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewInitiative_ChangePassword : System.Web.UI.Page
{
    public void lnkUpdate_Click(object sender, EventArgs e)
    {
        string cmd;
        DataTable dt = new DataTable();
        cmd = "select [password] from [MYA_PI_AppUsers] where username='" + Session["MYAPIVIAppUsername"] + "'  ";

        dt = dbFunctions_YPI.GetData(cmd);
        string p = "";
        if (!DBNull.Value.Equals(dt.Rows[0]["password"]))
            p = dt.Rows[0]["password"].ToString();

        if (p != "")
        {
            if (txtoldpasswrd.Text == p)
            {
                cmd = "update [MYA_PI_AppUsers] set [password]='" + txtnewpassword.Text + "' where [username]='" + Session["MYAPIVIAppUsername"] + "' ";
                try
                {
                    dbFunctions_YPI.ExecuteQuery(cmd);
                    ViewInitiativeAppUserActivityLog.CreateUserActivityLog(ViewInitiativeAppCurrentUser.MYAPIVIAppUserID, ViewInitiativeAppCurrentUser.MYAPIVIAppName, "ChangePassword", "ChangePassword", DateTime.Now, "", "", "");

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Account Information Updated Successfilly!');", true);
                }
                // Response.Redirect("show_message.aspx?mid=2")
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(ex.Message);", true);

                }
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid  Password!');", true);

        }
        else
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid  Password!');", true);

    }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        ViewInitiativeAppCurrentUser.CheckLoggedIn();
        txtUsername.Text = Session["MYAPIVIAppUsername"].ToString();
    }


    public void lnkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}