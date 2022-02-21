using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_Print_Members : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillData();
        }
    }
    private void fillData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

       // dt = dbFunctions.GetData("select * from [V_Members] where UserID=" + Request.QueryString["UserID"]);
        dt = dbFunctions.GetData("exec SP_GetMembersForPrint @type='members',@uid=" + Request.QueryString["UserID"]);
        //Try


        if (dt.Rows.Count != 0)
        {
          
          
            labName.Text = dt.Rows[0]["Name"].ToString();

            labCivilID.Text = dt.Rows[0]["CivilID"].ToString();

            labEmail.Text = dt.Rows[0]["Email"].ToString();

            labMobile.Text = dt.Rows[0]["Phone"].ToString();

            LabGovernorate.Text = dt.Rows[0]["GovernorateName"].ToString();

            LabUsername.Text = dt.Rows[0]["UserName"].ToString();

            LabStatus.Text = GetMemberStatus(dt.Rows[0]["Status"].ToString());
        }
    }

    public string GetMemberStatus(string Status)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (Status.ToString() == "True")
        {
            strresult = "Enable";
        }
        else
        {
            strresult = "Disable";
        }



        return strresult;
    }
}