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

        DataTable Userdt = new DataTable();


        dt = dbFunctions.GetData("SELECT Name,[CivilID],GovernorateName,[Email],[Phone] FROM [V_Members] where UserID= " + Request.QueryString["UserID"]);
        if (dt.Rows.Count != 0)
        {
            rpPersonaldetails.DataSource = dt;
            rpPersonaldetails.DataBind();
        }


        dt = dbFunctions.GetData("select StadiumName,format(BookingDate,'dd/MM/yyyy') as BookingDate,BookingTime,BookingStatus,PaymentStatus,format(CreatedAt,'dd/MM/yyyy') as CreatedAt from [V_Booking] where BookingStatus = '1' and UserID=" + Request.QueryString["UserID"] + " order by BookingDate desc");
        //Try


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