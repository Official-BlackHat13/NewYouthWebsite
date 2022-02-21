using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print_MemberBookings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillUserBookingData();
        }
    }

    private void fillUserBookingData()
    {
        DataTable dt = new DataTable();

        DataSet ds = new DataSet();
        ds = dbFunctions.GetDS("exec SP_GetMembersForPrint @type='memBooking',@uid=" + Request.QueryString["UserID"]);


       // dt = dbFunctions.GetData("SELECT Name,[CivilID],GovernorateName,[Email],[Phone] FROM [V_Members] where UserID= " + Request.QueryString["UserID"]);
        dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            rpPersonaldetails.DataSource = dt;
            rpPersonaldetails.DataBind();
        }


        //dt = dbFunctions.GetData("select * from [V_Booking] where BookingStatus = '1' and UserID=" + Request.QueryString["UserID"] + " order by BookingDate desc");
        //Try

        dt = ds.Tables[1];
        if (dt.Rows.Count != 0)
        {
            rpBookingdetails.DataSource = dt;
            rpBookingdetails.DataBind();
        }
    }



    public string GetBookingStatus(object objID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (objID.ToString() == "1")
        {
            strresult = "Confirmed";
        }
        else
        {
            strresult = "Cancel";
        }

        return strresult;
    }

    public string GetPaymentStatus(object objID)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (objID.ToString() == "True")
        {
            strresult = "Paid";
        }
        else
        {
            strresult = "Not Paid";
        }



        return strresult;
    }
}