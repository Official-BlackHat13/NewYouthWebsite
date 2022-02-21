using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print_BookingReport : System.Web.UI.Page
{
    string[] arr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            fillData();

        }
    }

    private void fillData()
    {
        string cmd;
        DataTable dt;

        string str = "";
        

        if (Request.QueryString["StartDate"] != null)
        {
            if (Request.QueryString["EndDate"] != null)
                str = str + ",BookingDate between '" + Request.QueryString["StartDate"] + "' and '" + Request.QueryString["EndDate"] + "'";
            else
                str = str + ",BookingDate = '" + Request.QueryString["StartDate"] + "'";
        }
        else
        {
             if (Request.QueryString["EndDate"] != null)
                 str = str + ",BookingDate = '" + Request.QueryString["EndDate"] + "'";
        }

      
        
        if (Request.QueryString["StadiumID"] != null)
            str = str + ",StadiumID = " + Request.QueryString["StadiumID"];

        if (Request.QueryString["BookingStatus"] != null)
            str = str + ",BookingStatus = " + Request.QueryString["BookingStatus"];
        else
            str = str + ",BookingStatus = 1 "; // this is by default only status =1 users


        if (Request.QueryString["BookingDate"] != null)
            str = str + ",BookingDate= '" + Request.QueryString["BookingDate"] + "'";       // from default page



        if (Request.QueryString["GovernorateID"] != null)
            str = str + ",GovernorateID= '" + Request.QueryString["GovernorateID"] + "'";      


        if (Request.QueryString["AreaID"] != null)
            str = str + ",AreaID = " + Request.QueryString["AreaID"];


        if (Request.QueryString["schoolID"] != null)
            str = str + ",schoolID = " + Request.QueryString["schoolID"];



        if (Request.QueryString["StadiumID"] != null)
            str = str + ",StadiumID = " + Request.QueryString["StadiumID"];



        if (Request.QueryString["BookingTime"] != null)
            str = str + ",BookingTime ='" + Request.QueryString["BookingTime"] +"'";


        if (Request.QueryString["CivilID"] != null)
            str = str + ",CivilID like '%" + Request.QueryString["CivilID"] +"%'";


        if (Request.QueryString["Email"] != null)
            str = str + ",Email like '%" + Request.QueryString["Email"]+"%'";

        if (Request.QueryString["Phone"] != null)
            str = str + ",Phone like '%" + Request.QueryString["Phone"]+ "%'";
  
       



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


        if (Request.QueryString["Day"] != null)
        {
            if(str != "")
                 str = str + " and DATENAME(WEEKDAY, BookingDate) = '" + Request.QueryString["Day"] + "'";
            else
                str = "where DATENAME(WEEKDAY, BookingDate) = '" + Request.QueryString["Day"] + "'";   
        }



      

        cmd = "select * from [V_BookingReport] " + str;

        dt = dbFunctions.GetData(cmd);

        if (dt.Rows.Count != 0)
        {
            rpdetails.DataSource = dt;
            rpdetails.DataBind();
        }
        else
        {
            rpdetails.DataSource = "";
            rpdetails.DataBind();
        }


       
    }




}