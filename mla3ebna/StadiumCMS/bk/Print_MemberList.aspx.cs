using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print_MemberList : System.Web.UI.Page
{
    string[] arr;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            FillData();
        }
    }

    private void  FillData()
    {
        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();
        

        string str=" ";

        if(Request.QueryString["GovernorateId"] != null)
            str = str + ",GovernateID = " + Request.QueryString["GovernorateId"];
        if (Request.QueryString["Name"] != null)
            str = str + ",Name like '%" + Request.QueryString["Name"] +"%'";
        if (Request.QueryString["Phone"] != null)
            str = str + ",Phone like '%" + Request.QueryString["Phone"] + "%'";
        if (Request.QueryString["Status"] != null)
            str = str+ ",Status = " + Request.QueryString["Status"];


        arr = str.Split(',');

        if (str != "")
        {
            str = " where ";
        }
        for (var i = 0; i < arr.Length; i++)
        {
            if (i > 1)
            {
                str = str + " and ";
            }
            str = str + (arr[i]);

        }
        string cmd = "SELECT Name,[CivilID],GovernorateName,[Email],[Phone] FROM [V_Members]" + str;

        dt = dbFunctions.GetData(cmd);
        if (dt.Rows.Count != 0)
        {
            rpdetails.DataSource = dt;
            rpdetails.DataBind();
        }


       

    }
}