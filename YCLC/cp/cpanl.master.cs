using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
public partial class cpanl : System.Web.UI.MasterPage
{
    
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid_Yclid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {
            string organizationID = Session["OrganizationID"].ToString();

            if (!organizationID.Equals("1"))
            {

                

               // below all commented on 19-10-2021

                licontact.Visible = false;
              //liAdd.Visible = true;

              //  liviewAdmin.Visible = false;

              //  liRegisteredAdmin.Visible = false;

            }
            else
            {
               

                //below all commented on 19-10-2021
                 licontact.Visible = true;
                // liAdd.Visible = false;

               // liviewAdmin.Visible = true;

               // liRegisteredAdmin.Visible = true;
            }
            checkPages();
        }
    }
    private string GetPageName()
    {
        return Request.Url.ToString().Split('/').Last();
    }
    private void checkPages()
    {
        var pageName = GetPageName();

        switch (pageName)
        {

            case "YCLC_ViewUsers.aspx":
                liview.Attributes.Add("class", "activeon");           
                break;
            //case "competitionDate.aspx":
            //    limail.Attributes.Add("class", "activeon");
            //    break;
            //case "competitionList.aspx":
            //    lilist.Attributes.Add("class", "activeon");
            //    break;

        }
    }
   
    protected void logout_Click(object sender, EventArgs e)
    {
      
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("profile.aspx");
    }

}
