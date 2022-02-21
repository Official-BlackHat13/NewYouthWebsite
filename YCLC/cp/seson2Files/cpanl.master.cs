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
        if (Session["userid_Adminid"] == null)
        {
            Response.Redirect("Index.aspx");
        }
        if (!IsPostBack)
        {
           
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

}
