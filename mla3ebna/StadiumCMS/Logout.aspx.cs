using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // WebCMSClinicUserActivityLog.CreateUserActivityLog(WebCMSClinicCurrentUser.WebCMSClinicUserID, WebCMSClinicCurrentUser.WebCMSClinicName, "Logout", "CMS Clinic Logout", DateTime.Now, " ", "", "");

       CMSCurrentUser.DeleteUserData();

        Response.Redirect("Default.aspx");
    }
}