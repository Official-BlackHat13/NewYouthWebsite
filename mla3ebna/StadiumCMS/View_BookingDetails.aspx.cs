using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StadiumCMS_View_BookingDetails : System.Web.UI.Page
{
    public string StrPrintbtn, StrGalleryDiv, StrVideoDiv;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CMSCurrentUser.CheckLoggedIn();
            // lnkDelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete?')";
            fillData();


            StrPrintbtn = " <a class='' href='javascript:void(0);'  onclick='openWinPrint(" + Request.QueryString["BookingID"] + ")'><i class='fa fa-print'></i><span>&nbsp;طباعه &nbsp;</span></a>";
        }
    }
    private void fillData()
    {
        DateTime strdate;

        DataTable dt = new DataTable();

        DataTable Userdt = new DataTable();

        dt = dbFunctions.GetData("select * from [V_Booking] where BookingID=" + Request.QueryString["BookingID"]);


        if (dt.Rows.Count != 0)
        {
            LabBookingID.Text = dt.Rows[0]["BookingID"].ToString();

            LabFullName.Text = dt.Rows[0]["UserFullName"].ToString();

            LabStadiumName.Text = dt.Rows[0]["StadiumName"].ToString();

            strdate = DateTime.Parse(dt.Rows[0]["BookingDate"].ToString());

            LabBookingDate.Text = strdate.ToString("dd/MM/yyyy");

            LabBookingTime.Text = dt.Rows[0]["BookingTime"].ToString();

            LabBookingStatus.Text = GetBookingStatus(dt.Rows[0]["BookingStatus"].ToString());

            LabPaymentStatus.Text = GetPaymentStatus(dt.Rows[0]["PaymentStatus"].ToString());

            fillBookingUserData(dt.Rows[0]["UserID"].ToString());



        }





        dt = dbFunctions.GetData("select * from [MYA_Maleabna_BookingPaymentDetails] where BookingID=" + Request.QueryString["BookingID"]);


        if (dt.Rows.Count != 0)
        {
            LabPaymentID.Text = dt.Rows[0]["PaymentID"].ToString();

            LabTranID.Text = dt.Rows[0]["TranID"].ToString();

            LabRef.Text = dt.Rows[0]["Ref"].ToString();

            LabAuth.Text = dt.Rows[0]["Auth"].ToString();

            LabTrackID.Text = dt.Rows[0]["TrackID"].ToString();

            strdate = DateTime.Parse(dt.Rows[0]["PaymentDate"].ToString());

            LabPaymentDate.Text = strdate.ToString("dd/MM/yyyy");
        }
    }

    private void fillBookingUserData(string UserID)
    {
        DataTable dt = new DataTable();
        dt = dbFunctions.GetData("select * from [V_Members] where UserID=" + UserID);
        if (dt.Rows.Count != 0)
        {
            LabCivilID.Text = dt.Rows[0]["CivilID"].ToString();

            LabEmail.Text = dt.Rows[0]["Email"].ToString();

            LabPhone.Text = dt.Rows[0]["Phone"].ToString();
        }
    }

        public string GetBookingStatus(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (s.ToString() == "1")
        {
            strresult = "Confirmed";
        }
        else
        {
            strresult = "Cancel";
        }



        return strresult;
    }

    public string GetPaymentStatus(string s)
    {
        string cmd, strresult;
        DataTable dt;

        strresult = "";

        if (s.ToString() == "True")
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